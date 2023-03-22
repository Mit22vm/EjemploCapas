using AccesoDatos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaCapas
{
    public class LN_Ventas
    {

        private string _cadenaConexion;
        private string _mensaje;


        public string Mensaje { 
            get 
            {
                return _mensaje;
            
            }
        }

        public LN_Ventas(string cadenaConexion)
        {
            _cadenaConexion= cadenaConexion;
        }

        public Venta ObtenerVenta(string condicion = "")
        {
            Venta resultado;
            AD_Ventas AccesoDatos = new AD_Ventas(_cadenaConexion);

            try
            {
                resultado = AccesoDatos.ObtenerVenta(condicion);
            }
            catch (Exception e)
            {

                throw e;
            }

            return resultado;
        }

        public int insertar(Venta venta, Detalle detalle)
        {
            int resultado = 0;
            AD_Ventas ADVentas = new AD_Ventas(_cadenaConexion);
            AD_Cliente ADCliente = new AD_Cliente(_cadenaConexion);
            AD_Producto ADProducto = new AD_Producto(_cadenaConexion);
            Producto producto;

            try
            {
                if (ADCliente.ObtenerCliente($"id= {venta.ClienteId}").Existe)
                {
                    producto = ADProducto.ObtenerProducto($"id= {detalle.ProductoId}");

                    if (producto.Existe)
                    {
                        detalle.PrecioVenta = producto.Precio + (producto.Precio * (decimal)0.35);
                        resultado = ADVentas.Insertar(venta, detalle);

                        switch (resultado)
                        {
                            case 1:
                                _mensaje = "Venta ingresada satisfactoriamente";
                                break;
                            case 2:
                                _mensaje = "Venta modificada satisfactoriamente";
                                break;
                            case 3:
                                _mensaje = "Se agrego satisfactoriamente";
                                break;
                            case 4:
                                _mensaje = "No se puede realizar cambios a la venta cancelada";
                                break;

                        }
                    }
                    else
                    {
                        resultado = 6;
                        _mensaje = "Imposible insertar la venta ya que el producto no existe";
                    }
                }
                else
                {
                    resultado = 5; //cliente no existe
                    _mensaje = "Imposible insertar la venta ya que el cliente no existe";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return resultado;
        }
    }
}
