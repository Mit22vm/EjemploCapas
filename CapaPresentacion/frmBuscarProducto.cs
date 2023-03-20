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
    public partial class frmBuscarProducto : Form
    {

        //Evento
        public event EventHandler Aceptar;//Este evento se debe disparar y mostrar en el otro formulario

        //Variables globales
        private int id_producto = 0;
        public frmBuscarProducto()
        {
            InitializeComponent();
        }

        private void CargarProductos(string condicion = "")
        {
            LN_Producto logica = new LN_Producto(Configuracion.getConnectionString);
            List<Producto> lista;
            try
            {
                lista = logica.ListarProductos(condicion);
                if (lista.Count > 0)
                {
                    grdLista.DataSource = lista;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SeleccionarProducto()
        {
            try
            {
                if (grdLista.SelectedRows.Count > 0)
                {
                    id_producto = (int)grdLista.SelectedRows[0].Cells[0].Value;
                    Aceptar(id_producto, null);
                    Close();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private void frmBuscarProducto_Load(object sender, EventArgs e)
        {
            try
            {
                CargarProductos(string.Empty);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void grdLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SeleccionarProducto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                SeleccionarProducto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            id_producto = -1;
            Aceptar(id_producto, null);
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string condicion;
            try
            {
                if (!string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    condicion = $"ID = '{txtId.Text}' or DESCRIPCION like '%{txtDescripcion.Text.Trim()}%' ";
                
                }
                else
                {
                    condicion = $"ID = '{txtId.Text}' ";
                }
                CargarProductos(condicion);
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (int)e.KeyChar == 8 )//acapte un digito o espacio acepta
            {

                e.Handled = false;

            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
