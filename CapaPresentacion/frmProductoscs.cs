using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using System.Windows.Forms;
using LogicaCapas;

namespace CapaPresentacion
{
    public partial class frmProductoscs : Form
    {
        private Producto EntidadBuscada = new Producto();
        public frmProductoscs()
        {
            InitializeComponent();
        }

        private void limpiar()
        {
            txtID.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtCantidad.Value = 0;
            txtPrecio.Text = string.Empty;
        }

        //Entidad
        private Producto GenerarEntidad() {
            //variable que retorna
            Producto entidad;
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                entidad = EntidadBuscada;
            }
            else {
                entidad = new Producto();
            }
            entidad.Descripcion = txtDescripcion.Text;
            entidad.Cantidad = (int)txtCantidad.Value;
            entidad.Precio = Convert.ToDecimal(txtPrecio.Text);
            return entidad;
        }
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (int)e.KeyChar == 8 || (int)e.KeyChar == 44)//acapte un digito o espacio acepta
            {

                e.Handled = false;

            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
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
                    grdLista.DataSource= lista;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Producto producto;
            LN_Producto logica = new LN_Producto(Configuracion.getConnectionString);
            decimal precio;
            int retorno;
            try
            {
                if (!string.IsNullOrEmpty(txtDescripcion.Text) && !string.IsNullOrEmpty(txtPrecio.Text))
                {
                    if (decimal.TryParse(txtPrecio.Text, out precio))
                    {
                        producto = GenerarEntidad();
                        //TODO: Llamar a los métodos de insertar y modificar.
                        retorno = logica.Insertar(producto);
                        if (retorno > 0)
                        {
                            if (retorno == 1)
                            {
                                MessageBox.Show("El producto se registró satisfactoriamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (retorno == 2)
                            {
                                MessageBox.Show("El producto se modificó satisfactoriamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            limpiar();
                            //TODO: Actualizar la tabla
                            CargarProductos();
                        }
                        else
                        {
                            MessageBox.Show("No fue posible realizar la operación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (producto.Existe)
                        {
                            //TODO: Modificar el producto
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        MessageBox.Show("El precio requiere un valor númerico", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("La descripción y el precio son datos requeridos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void frmProductoscs_Load(object sender, EventArgs e)
        {
            try
            {
                CargarProductos("");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void grdLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = 0;
            try
            {
                id = Convert.ToInt32(grdLista.SelectedRows[0].Cells[0].Value);
                BuscarProducto(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BuscarProducto(int id)
        {
            Producto producto = new Producto();
            LN_Producto logica = new LN_Producto();
            logica.CadenaConexion = Configuracion.getConnectionString;
            string condicion = $"Id={id} ";
            try
            {
                producto = logica.ObtenerProducto(condicion);
                if (producto.Existe )
                {
                    txtID.Text = producto.Id.ToString();
                    txtDescripcion.Text = producto.Descripcion.ToString();
                    txtCantidad.Value = producto.Cantidad;
                    txtPrecio.Text = producto.Precio.ToString();
                    EntidadBuscada = producto;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
