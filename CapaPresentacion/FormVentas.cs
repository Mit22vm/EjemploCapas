using Entidad;
using LogicaCapas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormVentas : Form
    {
        public FormVentas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Venta venta = new Venta();
            Detalle detalle = new Detalle();
            LN_Ventas logica = new LN_Ventas(Configuracion.getConnectionString);

            int resultado = 0;
            venta.Id = 2;
            venta.Tipo = "contado";
            venta.Estado = "pendiente";
            venta.ClienteId = 1;
            detalle.ProductoId = 2;
            detalle.Cantidad= 2;
            detalle.Id = 2;
            detalle.VentaId= 2;
            resultado = logica.insertar(venta, detalle);
            MessageBox.Show(logica.Mensaje);

        }
    }
}
