using System;
using Entidad;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos
{
    public class AD_Producto
    {
        private string _cademaConexion;
        private int id_Producto;

        public AD_Producto(string cadenaConexion)
        {
            _cademaConexion = cadenaConexion;
        }

        public int Id_Producto { 

            get => id_Producto;
            set => id_Producto = value;
        }

        /// <summary>
        /// Insertar un producto en la base de datos
        /// </summary>
        /// <param name="producto">Entidad a insertar</param>
        /// <returns>id del producto insertado</returns>
        public int Insertar(Producto producto)
        {
            
            int resultado = 1;
            //variables
            SqlConnection conexion = new SqlConnection(_cademaConexion);
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;//Dice la conexion que utiliza
            string sentencia;

            try
            {
                sentencia = "Insert into Productos(DESCRIPCION, CANTIDAD, PRECIO) values(@Descripcion, @Cantidad, @Precio) select SCOPE_IDENTITY()";
                comando.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                comando.Parameters.AddWithValue("@Cantidad", producto.Cantidad);
                comando.Parameters.AddWithValue("@Precio", producto.Precio);
                //La sentencia se la aplico al comando
                comando.CommandText = sentencia;

                //Abre la conexion
                conexion.Open();

                resultado = Convert.ToInt32(comando.ExecuteScalar());
                conexion.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }

            return resultado;
        }

        public int InsertarModificar(Producto producto)
        {
            int resultado = 1;
            SqlConnection cnn = new SqlConnection(_cademaConexion);
            SqlCommand comando = new SqlCommand(); 
            comando.Connection = cnn;
            string sentencia;

            return resultado;

            try
            {
                sentencia = "SP_INSERTAR_MODIFICAR";
                comando.CommandText= sentencia;
                comando.CommandType= CommandType.StoredProcedure;
                //Parametros de entrada
                comando.Parameters.AddWithValue("@DESCRIPCION", producto.Descripcion); 
                comando.Parameters.AddWithValue("@CANTIDAD", producto.Cantidad); 
                comando.Parameters.AddWithValue("@PRECIO", producto.Precio);
                //Parametros de salida
                comando.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
                comando.Parameters["@ID"].Value = producto.Id;
                comando.Parameters.Add("@RESULTADO", SqlDbType.Int).Direction = ParameterDirection.Output;

                cnn.Open();
                comando.ExecuteNonQuery();
                comando.Dispose();
                id_Producto = Convert.ToInt32(comando.Parameters["@ID"].Value);
                resultado = Convert.ToInt32(comando.Parameters["resultado"].Value);
                cnn.Close();

            }
            catch (Exception)
            {

                throw;
            }
            return resultado;
        }
        public Producto ObtenerProducto(string condicion)
        {
            Producto producto = new Producto();
            SqlConnection cnn = new SqlConnection(_cademaConexion);
            SqlCommand comando = new SqlCommand();
            comando.Connection = cnn;
            SqlDataReader datos;
            string sentencia = "Select id, descripcion, cantidad, precio from Productos";
            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = $"{sentencia} where {condicion}";
            }
            comando.CommandText = sentencia;
                try
                {
                    cnn.Open();
                    datos = comando.ExecuteReader();
                    if ( datos.HasRows )
                    {
                        datos.Read();
                        producto.Id = datos.GetInt32(0);
                        //Descripcion
                        producto.Descripcion = datos.GetString(1);
                        producto.Cantidad = datos.GetInt32(2);
                        producto.Precio = datos.GetDecimal(3);
                        producto.Existe = true;
                    }
                    cnn.Close();
                }
                catch (Exception E)
                {

                    throw;
                }
            
            return producto;
        }

        public List<Producto> ListarProductos(string condicion="")
        {
            DataSet datos = new DataSet();
            SqlConnection cnn = new SqlConnection(_cademaConexion);
            SqlDataAdapter adapter;

            List<Producto> productos = new List<Producto>();
            string sentencia = "Select id, descripcion,cantidad, precio from Productos";
            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = $"{sentencia} where {condicion}";
            }
            try
            {
                adapter = new SqlDataAdapter(sentencia, cnn);
                adapter.Fill(datos, "Productos");
                //ling lenguaje de c# para manejo de consultas
                //Permite hacer consulta a una serie de datos de un contenedor
                //Por cada data row que tenga en el registro 
                productos = (from DataRow registro in datos.Tables[0].Rows
                             select new Producto()
                             {
                                 Id = Convert.ToInt32(registro[0]), //tambien se puede poner el nombre de la tabla
                                 Descripcion = registro[1].ToString(),
                                 Cantidad = Convert.ToInt32(registro[2]),
                                 Precio = Convert.ToDecimal(registro[3])
                             }
                             ).ToList();
            }
            catch (Exception  e)
            {

                throw e;
            }
           
            return productos;
        }
    }
}
