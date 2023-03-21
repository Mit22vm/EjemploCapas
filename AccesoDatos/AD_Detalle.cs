using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Linq;

namespace AccesoDatos
{
    public class AD_Detalle
    {
        private string _cadenaConexion;

        public AD_Detalle(string cadenaConexion) 
        {
            _cadenaConexion = cadenaConexion;
        }

        public List<Detalle> ListarDetalles(string condicion = "")
        {
            DataSet datos = new DataSet();
            SqlConnection cnn = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;

            List<Detalle> detalles = new List<Detalle>();
            string sentencia = "Select ID, VENTAID,PRODUCTOID,DESCRIPCION, CANTIDAD, PRECIOVENTA,SUBTOTAL from DetallesVenta";
            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = $"{sentencia} where {condicion}";
            }
            try
            {
                adapter = new SqlDataAdapter(sentencia, cnn);
                adapter.Fill(datos, "Detalle");
                //ling lenguaje de c# para manejo de consultas
                //Permite hacer consulta a una serie de datos de un contenedor
                //Por cada data row que tenga en el registro 
                detalles = (from DataRow registro in datos.Tables["Detalle"].Rows
                             select new Detalle()
                             {
                                 Id = Convert.ToInt32(registro[0]), //tambien se puede poner el nombre de la tabla
                                 VentaId = Convert.ToInt32(registro[1]),
                                 ProductoId = Convert.ToInt32(registro[2]),
                                 Descripcion = registro[3].ToString(),
                                 Cantidad = Convert.ToInt32(registro[4]),
                                 PrecioVenta = Convert.ToDecimal(registro[5]),
                                 Subtotal = Convert.ToDecimal(registro[6])
                                 
                             }
                             ).ToList();
            }
            catch (Exception e)
            {

                throw e;
            }

            return detalles;
        }

        public Detalle ObtenerDetalle(string condicion = "")
        {
            DataSet datos = new DataSet();
            SqlConnection cnn = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            Detalle detalle = new Detalle();

            string sentencia = "Select ID, VENTAID,PRODUCTOID,DESCRIPCION, CANTIDAD, PRECIOVENTA,SUBTOTAL from DetallesVenta";
            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = $"{sentencia} where {condicion}";
            }
            try
            {
                adapter = new SqlDataAdapter(sentencia, cnn);
                adapter.Fill(datos, "Detalle");
                //ling lenguaje de c# para manejo de consultas
                //Permite hacer consulta a una serie de datos de un contenedor
                //Por cada data row que tenga en el registro 
                detalle = (from DataRow registro in datos.Tables["Detalle"].Rows
                            select new Detalle()
                            {
                                Id = Convert.ToInt32(registro[0]), //tambien se puede poner el nombre de la tabla
                                VentaId = Convert.ToInt32(registro[1]),
                                ProductoId = Convert.ToInt32(registro[2]),
                                Descripcion = registro[3].ToString(),
                                Cantidad = Convert.ToInt32(registro[4]),
                                PrecioVenta = Convert.ToDecimal(registro[5]),
                                Subtotal = Convert.ToDecimal(registro[6])

                            }
                             ).FirstOrDefault();
            }
            catch (Exception e)
            {

                throw e;
            }

            return detalle;
        }

        public bool Eliminar(int id)
        {
            bool resultado = false;
            SqlConnection cnn = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia;
            comando.Connection = cnn;

            sentencia = "Delete Detalle where id=@Id";

            comando.CommandText = sentencia;
            comando.Parameters.AddWithValue("@Id", id);

            try
            {
                cnn.Open();
                if (comando.ExecuteNonQuery() > 0)
                {
                    resultado = true;
                }
                cnn.Close();
            }
            catch (Exception e)
            {

                throw e;
            }


            return resultado;
        }
    }
}
