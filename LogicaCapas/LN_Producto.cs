using System;
using Entidad;
using AccesoDatos;
using System.Collections.Generic;

namespace LogicaCapas
{

    //Capa 2 
    public class LN_Producto
    {

        private string _cadenaConexion;

        public string CadenaConexion
        {
            get => _cadenaConexion;
            set => _cadenaConexion = value;
        }

        public LN_Producto()
        {
            _cadenaConexion = string.Empty;
        }

        public LN_Producto(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public int Insertar(Producto producto)
        {
            int resultado = -1;
            AD_Producto AccesoDatos = new AD_Producto(_cadenaConexion);

            try
            {
                resultado = AccesoDatos.Insertar(producto);
            }
            catch (Exception e)
            {

                throw e;
            }

            return resultado;
        }
        public int InsertarModificar(Producto producto)
        {
            int resultado = -1;
            AD_Producto AccesoDatos = new AD_Producto(_cadenaConexion);

            try
            {
                resultado = AccesoDatos.InsertarModificar(producto);
            }
            catch (Exception e)
            {

                throw e;
            }

            return resultado;
        }

        public Producto ObtenerProducto(string condicion)
        {
            Producto resultado;
            AD_Producto AccesoDatos = new AD_Producto(_cadenaConexion);

            try
            {
                resultado = AccesoDatos.ObtenerProducto(condicion);
            }
            catch (Exception e)
            {

                throw e;
            }

            return resultado;
        }

        public List<Producto> ListarProductos(string condicion= "")
        {
            List<Producto> resultado;
            AD_Producto AccesoDatos = new AD_Producto(_cadenaConexion);

            try
            {
                resultado = AccesoDatos.ListarProductos(condicion);
            }
            catch (Exception e)
            {

                throw e;
            }

            return resultado;
        }

    }
}
