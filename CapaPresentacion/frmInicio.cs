using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CapaPresentacion
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuProductos_Click(object sender, EventArgs e)
        {
            frmProductoscs productos = new frmProductoscs();
            productos.Show(this);
        }

        private void mnuVentas_Click(object sender, EventArgs e)
        {
            FormVentas ventas= new FormVentas();
            ventas.Show(this);
        }
    }
}
