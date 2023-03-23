using Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;

namespace AccesoDatos
{
    public class AD_Ventas
    {
        private string _cadenaConexion;
        private int idVenta;

        public int IdVenta
        {
            get
            { return IdVenta; }
        }

        public AD_Ventas(string cadenaConexion) 
        {
            _cadenaConexion= cadenaConexion;
        }

        public int Insertar(Venta venta, Detalle detalle)
        {
            int resultado = 0;
            //variables
            SqlConnection cnn = new SqlConnection(_cadenaConexion);
            SqlCommand cmd = new SqlCommand();
            string sentencia;
            int idventa = 0;
            Venta busqueda;
            AD_Detalle AD_Det = new AD_Detalle(_cadenaConexion);
            cmd.Connection = cnn;
            cnn.Open();
            SqlTransaction trans = cnn.BeginTransaction();
            idVenta = venta.Id;

            //para abrir conexion

            try
            {
                cmd.Transaction = trans;
                busqueda = ObtenerVenta($"v.id= {venta.Id}");
                if (!busqueda.Existe)
                {
                    //abro 

                    sentencia = "Insert into Ventas(fecha,tipo,clienteId,estado) values (@fecha,@tipo,@clienteId,@estado) select SCOPE_IDENTITY()";
                    //Se le asigna al command
                    cmd.CommandText = sentencia;
                    cmd.Parameters.AddWithValue("@fecha", venta.Fecha);
                    cmd.Parameters.AddWithValue("@tipo", venta.Tipo);
                    cmd.Parameters.AddWithValue("@clienteId", venta.ClienteId);
                    cmd.Parameters.AddWithValue("@estado", venta.Estado);
                    idventa = Convert.ToInt32(cmd.ExecuteScalar());

                    sentencia = "Insert into Detalle(ventaId, productoId, cantidad, precioventa) values (@ventaId, @productoId, @cantidad,@precioventa)";

                    cmd.CommandText = sentencia;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ventaId", idventa);
                    cmd.Parameters.AddWithValue("@productoId", detalle.ProductoId);
                    cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                    cmd.Parameters.AddWithValue("@precioventa", detalle.PrecioVenta);
                    cmd.ExecuteNonQuery();
                    trans.Commit();

                    resultado = 1; //inserto venta y detalle
                }
                else
                {
                    if (busqueda.Estado.ToUpper().Trim() == "PENDIENTE")
                    {
                        sentencia = "Update Ventas set clienteId=@clienteId, Tipo=@tipo where id=@Id";
                        //Se le asigna al command
                        cmd.CommandText = sentencia;
                        cmd.Parameters.AddWithValue("@Id", venta.Id);
                        cmd.Parameters.AddWithValue("@tipo", venta.Tipo);
                        cmd.Parameters.AddWithValue("@clienteId", venta.ClienteId);

                        cmd.ExecuteNonQuery();


                        if (AD_Det.ObtenerDetalle($"Id={detalle.Id} and ventaId= {venta.Id}").Existe)
                        {
                            sentencia = "Update Detalle set productoid= @productoId, cantidad=@cantidad, precioVenta=@precioventa where id=@Id";
                            cmd.CommandText = sentencia;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@ventaId", idventa);
                            cmd.Parameters.AddWithValue("@productoId", detalle.ProductoId);
                            cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                            cmd.Parameters.AddWithValue("@precioventa", detalle.PrecioVenta);
                            cmd.Parameters.AddWithValue("@Id", detalle.Id);
                            cmd.ExecuteNonQuery();

                            resultado = 2; //actualizoventa y detalle
                        }
                        else
                        {
                            sentencia = "Insert into Detalle(ventaId, productoId, cantidad, precioventa) values (@ventaId, @productoId, @cantidad,@precioventa)";

                            cmd.CommandText = sentencia;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@ventaId", idventa);
                            cmd.Parameters.AddWithValue("@productoId", detalle.ProductoId);
                            cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                            cmd.Parameters.AddWithValue("@precioventa", detalle.PrecioVenta);
                            cmd.ExecuteNonQuery();

                            resultado = 3; //actualizo venta e inserto detalle
                        }

                    }
                    else
                    {
                        resultado = 4; //no se puede actualizar porque la venta esta cancelada
                    }
                    trans.Commit();

                }
           
                cnn.Close();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            

            return resultado;
        }

        public Venta ObtenerVenta(string condicion = "")
        {
            DataSet datos = new DataSet();
            SqlConnection cnn = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            Venta venta = new Venta();

            string sentencia = "Select v.iD, clienteid, Concat(nombre, ' ',apellido) as NombreCliente, fecha,tipo, estado from Ventas v inner join Clientes c on v.clienteid=c.id";
            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = $"{sentencia} where {condicion}";
            }
            try
            {
                adapter = new SqlDataAdapter(sentencia, cnn);
                adapter.Fill(datos, "Ventas");
                //ling lenguaje de c# para manejo de consultas
                //Permite hacer consulta a una serie de datos de un contenedor
                //Por cada data row que tenga en el registro 
                if (datos.Tables[0].Rows.Count > 0)
                {
                    venta = (from DataRow registro in datos.Tables[0].Rows
                             select new Venta()
                             {
                                 Id = Convert.ToInt32(registro[0]), //tambien se puede poner el nombre de la tabla
                                 ClienteId = Convert.ToInt32(registro[1]),
                                 NombreCliente = registro[2].ToString(),
                                 Fecha = Convert.ToDateTime(registro[3]),
                                 Tipo = registro[4].ToString(),
                                 Estado = registro[5].ToString(),
                                 Existe = true


                             }
                             ).FirstOrDefault();
                }
                
            }
            catch (Exception e)
            {

                throw e;
            }

            return venta;
        }
    }
}
