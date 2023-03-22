namespace CapaPresentacion
{
    partial class FormVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblbNumero = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tpBuscar = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(204, 476);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnBuscarCliente);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.lblbNumero);
            this.groupBox1.Location = new System.Drawing.Point(13, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(724, 158);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Facturación";
            // 
            // lblbNumero
            // 
            this.lblbNumero.AutoSize = true;
            this.lblbNumero.Location = new System.Drawing.Point(18, 45);
            this.lblbNumero.Name = "lblbNumero";
            this.lblbNumero.Size = new System.Drawing.Size(103, 16);
            this.lblbNumero.TabIndex = 0;
            this.lblbNumero.Text = "Número Factura";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(127, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 1;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(310, 45);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(345, 22);
            this.txtCliente.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cliente";
            // 
            // tpBuscar
            // 
            this.tpBuscar.ToolTipTitle = "Buscar cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tipo de venta";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "CONTADO",
            "CREDITO"});
            this.comboBox1.Location = new System.Drawing.Point(126, 107);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Código";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Descripción";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(415, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Cantidad";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(502, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Precio";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(418, 183);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(58, 22);
            this.nudCantidad.TabIndex = 7;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(34, 182);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(48, 22);
            this.txtCodigo.TabIndex = 11;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(136, 182);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(181, 22);
            this.txtDescripcion.TabIndex = 12;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(505, 182);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 22);
            this.txtPrecio.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(567, 449);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(637, 443);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 22);
            this.txtTotal.TabIndex = 19;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackgroundImage = global::CapaPresentacion.Properties.Resources.Close_48;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.Location = new System.Drawing.Point(701, 513);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(36, 27);
            this.btnCerrar.TabIndex = 23;
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = global::CapaPresentacion.Properties.Resources.Delete_48;
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.Location = new System.Drawing.Point(651, 513);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(34, 27);
            this.btnEliminar.TabIndex = 22;
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = global::CapaPresentacion.Properties.Resources.Search_48x48;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.Location = new System.Drawing.Point(596, 513);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(39, 27);
            this.btnBuscar.TabIndex = 21;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImage = global::CapaPresentacion.Properties.Resources.save_48;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.Location = new System.Drawing.Point(543, 513);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(37, 27);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.BackgroundImage = global::CapaPresentacion.Properties.Resources.Eliminar;
            this.btnEliminarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarProducto.Location = new System.Drawing.Point(680, 176);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(36, 29);
            this.btnEliminarProducto.TabIndex = 16;
            this.btnEliminarProducto.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = global::CapaPresentacion.Properties.Resources.Agregar;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Location = new System.Drawing.Point(629, 176);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(39, 29);
            this.btnAgregar.TabIndex = 15;
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.BackgroundImage = global::CapaPresentacion.Properties.Resources.Buscar;
            this.btnBuscarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarProducto.Location = new System.Drawing.Point(340, 182);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(39, 22);
            this.btnBuscarProducto.TabIndex = 14;
            this.btnBuscarProducto.UseVisualStyleBackColor = true;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.BackgroundImage = global::CapaPresentacion.Properties.Resources.Buscar;
            this.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarCliente.Location = new System.Drawing.Point(661, 40);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(42, 33);
            this.btnBuscarCliente.TabIndex = 3;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 254);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(724, 150);
            this.dataGridView1.TabIndex = 24;
            // 
            // FormVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 577);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnEliminarProducto);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnBuscarProducto);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.nudCantidad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.Name = "FormVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormVentas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblbNumero;
        private System.Windows.Forms.ToolTip tpBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminarProducto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}