using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AccesoDatos
{
    public class AD_Cliente
    {

        private string _cadenaConexion;

        public AD_Cliente(string cadenaConexion) 
        { 
            _cadenaConexion= cadenaConexion;

        }

        public Cliente ObtenerCliente(string condicion)
        {
            Cliente cliente = new Cliente();
            SqlConnection cnn = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            comando.Connection = cnn;
            SqlDataReader datos;
            string sentencia = "Select id, nombre, apellido, telefono from Clientes";
            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = $"{sentencia} where {condicion}";
            }
            comando.CommandText = sentencia;
            try
            {
                cnn.Open();
                datos = comando.ExecuteReader();
                if (datos.HasRows)
                {
                    datos.Read();


                    cliente.Id = datos.GetInt32(0);
                    cliente.Nombre = datos.GetString(1);
                    cliente.Apellido = datos.GetString(2);
                    cliente.Telefono = datos.GetString(3);
                    cliente.Existe = true;
                }
                cnn.Close();
            }
            catch (Exception E)
            {

                throw E;
            }

            return cliente;
        }
    }

   
}
