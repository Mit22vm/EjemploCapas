using System;
using System.Collections.Generic;
using System.Text;

namespace Entidad
{
    public class Detalle
    {
        private int id;
        private int ventaId;
        private int productoId;
        private int cantidad;
        private decimal precioVenta;
        private decimal subtotal;
        private string descripcion;


        public int Id { 
            get => id; 
            set => id = value; 
        }
        public int VentaId { 
            get => ventaId; 
            set => ventaId = value; 
        }
        public int ProductoId { 
            get => productoId; 
            set => productoId = value;
        }
        public int Cantidad { 
            get => cantidad; 
            set => cantidad = value; 
        }
        public decimal PrecioVenta { 
            get => precioVenta; 
            set => precioVenta = value; 
        }
        public decimal Subtotal { 
            get => subtotal; 
            set => subtotal = value; 
        }
        public string Descripcion { 
            get => descripcion; 
            set => descripcion = value; 
        }

        public Detalle()
        {
            id= 0;
            ventaId= 0;
            productoId= 0;
            cantidad= 0;
            precioVenta= 0;
            subtotal= 0;
            descripcion= string.Empty;
            
        }
    }
}
