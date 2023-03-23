using Entidad;
using LogicaCapas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            txtNumeroFactura.Tag = 0;
            txtCodigo.Tag = 0;
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Venta venta = new Venta();
        //    Detalle detalle = new Detalle();
        //    LN_Ventas logica = new LN_Ventas(Configuracion.getConnectionString);

        //    int resultado = 0;
        //    venta.Id = 2;
        //    venta.Tipo = "contado";
        //    venta.Estado = "pendiente";
        //    venta.ClienteId = 1;
        //    detalle.ProductoId = 2;
        //    detalle.Cantidad= 2;
        //    detalle.Id = 2;
        //    detalle.VentaId= 2;
        //    resultado = logica.insertar(venta, detalle);
        //    MessageBox.Show(logica.Mensaje);

        //}

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmBuscarClientes frm = new FrmBuscarClientes();
            frm.AceptarCliente += new EventHandler(AceptarCliente);
            frm.Show(this);
        }
        //Metodo de buscar cliente
        private void BuscarProducto(int id)
        {
            Producto producto = new Producto();
            LN_Producto logica = new LN_Producto();
            logica.CadenaConexion = Configuracion.getConnectionString;
            string condicion = $"Id={id} ";
            try
            {
                producto = logica.ObtenerProducto(condicion);
                if (producto.Existe)
                {
                    txtCodigo.Text = producto.Id.ToString();
                    txtDescripcion.Tag = producto.Id.ToString();
                    txtDescripcion.Text = producto.Descripcion.ToString();
                    txtPrecio.Text = (producto.Precio*(decimal)1.35).ToString("¢0,###.##");
                    nudCantidad.Focus();
                }
                else
                {
                    txtCodigo.Text = string.Empty;
                    txtDescripcion.Tag = string.Empty;
                    txtDescripcion.Text= string.Empty;  //producto.Descripcion.ToString();
                    txtPrecio.Text = string.Empty;
                    nudCantidad.Value= 1;

                    //MessageBox.Show("Imposible cargar el producto ya que el producto ha tenido cambios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        //Un tag cuanda informacion que solo el programador puede ver,el usuario no
        private void BuscarCliente(int id)
        {
            Cliente cliente;
            LN_Cliente logica = new LN_Cliente(Configuracion.getConnectionString);
           
            string condicion = $"Id={id} ";
            try
            {
                cliente = logica.ObtenerCliente(condicion);
                if (cliente.Existe)
                {
                    txtCliente.Tag = cliente.Id.ToString();
                    txtCliente.Text = $"{cliente.Nombre} {cliente.Apellido}";

                }
                else
                {
                    MessageBox.Show("Imposible cargar el cliente ya que ha sufrido cambios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception e)

            {

                throw e;
            }
        }



        private void AceptarCliente(object id, EventArgs e)
        {
            try
            {
                int id_cliente = (int)id;
                if (id_cliente > -1)
                {
                    BuscarCliente(id_cliente);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            frmBuscarProducto frm = new frmBuscarProducto();
            frm.Aceptar += new EventHandler(Aceptar);
            frm.Show(this);
        }

        private void Aceptar(object id_producto, EventArgs e)
        {
            try
            {
                int id = (int)id_producto;
                if (id > -1)
                {
                    BuscarProducto(id);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            int codigo;
            try
            {
                if (e.KeyChar == 13)
                {
                    if (!string.IsNullOrEmpty(txtCodigo.Text))
                    {
                        if (int.TryParse(txtCodigo.Text, out codigo))
                        {
                            BuscarProducto(codigo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        //Metodo insertar
        private void Insertar()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCliente.Text) && !string.IsNullOrEmpty(cboTipo.Text))
                {
                    if (!string.IsNullOrEmpty(txtDescripcion.Tag.ToString()) && !string.IsNullOrEmpty(nudCantidad.Value.ToString()))
                    {
                        Venta venta = GenerarVenta();
                        Detalle detalle = GenerarDetalle();
                        LN_Ventas logica = new LN_Ventas(Configuracion.getConnectionString);
                        detalle.VentaId = venta.Id;
                        logica.insertar(venta, detalle);
                        txtNumeroFactura.Text = logica.IDVenta.ToString();
                        CargarDetalles(logica.IDVenta);
                        MessageBox.Show(logica.Mensaje);
                        
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un articulo y establecer una cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Faltan datos en el encabezado de la factura", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private Venta GenerarVenta()
        {
            Venta venta= new Venta();

            if (!string.IsNullOrEmpty(txtNumeroFactura.Text))
            {
                venta.Id = Convert.ToInt32(txtNumeroFactura.Text);
            }
            venta.ClienteId = Convert.ToInt32(txtCliente.Tag);
            venta.Tipo = cboTipo.Text;
            venta.Estado = "Pendiene";

            return venta;
        }
        private Detalle GenerarDetalle()
        {
            Detalle detalle = new Detalle();

            if (!string.IsNullOrEmpty(txtCodigo.Tag.ToString()))
            {
              detalle.Id = Convert.ToInt32(txtCodigo.Tag);
            }
            
            detalle.ProductoId = Convert.ToInt32(txtCodigo.Tag);
            detalle.Cantidad = Convert.ToInt32(nudCantidad.Tag);


            return detalle;
        }

        private void CargarDetalles(int idventa)
        {
            LN_Detalle logica = new LN_Detalle(Configuracion.getConnectionString);
            List<Detalle> lista;

            try
            {
                lista = logica.ListarDetalles($"{idventa}");
                grdLista.DataSource = lista;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Insertar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
