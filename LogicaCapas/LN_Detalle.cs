using AccesoDatos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaCapas
{
    public class LN_Detalle
    {
        private string _cadenaConexion;

        public LN_Detalle(string cadenaConexion) 
        {
            _cadenaConexion = cadenaConexion;
        }
        public List<Detalle> ListarDetalles(string condicion = "")
        {
            List<Detalle> resultado;
            AD_Detalle AccesoDatos = new AD_Detalle(_cadenaConexion);

            try
            {
                resultado = AccesoDatos.ListarDetalles(condicion);
            }
            catch (Exception e)
            {

                throw e;
            }

            return resultado;
        }
    }
}
