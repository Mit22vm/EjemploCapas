﻿using Entidad;
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
    public partial class FrmBuscarClientes : Form
    {
        public event EventHandler AceptarCliente;
        //variable global 
        private int id_cliente = 0;
        public FrmBuscarClientes()
        {
            InitializeComponent();
        }

        private void CargarClientes(string condicion = "")
        {
            LN_Cliente logica = new LN_Cliente(Configuracion.getConnectionString);
            List<Cliente> lista;
            try
            {
                lista = logica.ListarClientes(condicion);
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

        private void SeleccionarCliente()
        {
            try
            {
                if (grdLista.SelectedRows.Count > 0)
                {
                    id_cliente = (int)grdLista.SelectedRows[0].Cells[1].Value;
                    AceptarCliente(id_cliente, null);
                    Close();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string condicion = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text))
                {
                    condicion = $"Concat(NOMBRE,' ', APELLIDO) like '%{txtNombre.Text}%'";
                }
                CargarClientes(condicion);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmBuscarClientes_Load(object sender, EventArgs e)
        {
            try
            {
                CargarClientes("");
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
                SeleccionarCliente();
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
                SeleccionarCliente();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            id_cliente = -1;
            AceptarCliente(id_cliente, null);
            Close();
        }
    }
}
