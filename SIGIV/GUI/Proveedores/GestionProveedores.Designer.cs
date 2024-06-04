namespace SIGIV.GUI.Proveedores
{
    partial class GestionProveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionProveedores));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgDatos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAgregarDireccion = new System.Windows.Forms.Button();
            this.btnAgregarContacto = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.Operaciones = new System.Windows.Forms.GroupBox();
            this.rbnModificar = new System.Windows.Forms.RadioButton();
            this.rbnEliminar = new System.Windows.Forms.RadioButton();
            this.rbnNuevo = new System.Windows.Forms.RadioButton();
            this.txbGiro = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbWeb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbCorreo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbTelefono = new System.Windows.Forms.TextBox();
            this.txbNIT = new System.Windows.Forms.TextBox();
            this.txbCompania = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txbBuscar = new System.Windows.Forms.ToolStripTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.Operaciones.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15);
            this.panel1.Size = new System.Drawing.Size(679, 460);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgDatos);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(15, 288);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(649, 157);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado de Compañia";
            // 
            // dtgDatos
            // 
            this.dtgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgDatos.Location = new System.Drawing.Point(3, 16);
            this.dtgDatos.Name = "dtgDatos";
            this.dtgDatos.Size = new System.Drawing.Size(643, 138);
            this.dtgDatos.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnAgregarDireccion);
            this.groupBox1.Controls.Add(this.btnAgregarContacto);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.Operaciones);
            this.groupBox1.Controls.Add(this.txbGiro);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txbWeb);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txbCorreo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txbTelefono);
            this.groupBox1.Controls.Add(this.txbNIT);
            this.groupBox1.Controls.Add(this.txbCompania);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(649, 273);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formulario";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(390, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Hacer Apedido";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnAgregarDireccion
            // 
            this.btnAgregarDireccion.Location = new System.Drawing.Point(266, 237);
            this.btnAgregarDireccion.Name = "btnAgregarDireccion";
            this.btnAgregarDireccion.Size = new System.Drawing.Size(100, 23);
            this.btnAgregarDireccion.TabIndex = 15;
            this.btnAgregarDireccion.Text = "Agregar Direccion";
            this.btnAgregarDireccion.UseVisualStyleBackColor = true;
            this.btnAgregarDireccion.Click += new System.EventHandler(this.btnAgregarDireccion_Click);
            // 
            // btnAgregarContacto
            // 
            this.btnAgregarContacto.Location = new System.Drawing.Point(160, 237);
            this.btnAgregarContacto.Name = "btnAgregarContacto";
            this.btnAgregarContacto.Size = new System.Drawing.Size(100, 23);
            this.btnAgregarContacto.TabIndex = 14;
            this.btnAgregarContacto.Text = "Agregar Contacto";
            this.btnAgregarContacto.UseVisualStyleBackColor = true;
            this.btnAgregarContacto.Click += new System.EventHandler(this.btnAgregarContacto_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(38, 237);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 23);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // Operaciones
            // 
            this.Operaciones.Controls.Add(this.rbnModificar);
            this.Operaciones.Controls.Add(this.rbnEliminar);
            this.Operaciones.Controls.Add(this.rbnNuevo);
            this.Operaciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.Operaciones.Location = new System.Drawing.Point(519, 16);
            this.Operaciones.Name = "Operaciones";
            this.Operaciones.Size = new System.Drawing.Size(127, 254);
            this.Operaciones.TabIndex = 12;
            this.Operaciones.TabStop = false;
            this.Operaciones.Text = "Operacciones";
            // 
            // rbnModificar
            // 
            this.rbnModificar.AutoSize = true;
            this.rbnModificar.Location = new System.Drawing.Point(21, 94);
            this.rbnModificar.Name = "rbnModificar";
            this.rbnModificar.Size = new System.Drawing.Size(68, 17);
            this.rbnModificar.TabIndex = 2;
            this.rbnModificar.Text = "Modificar";
            this.rbnModificar.UseVisualStyleBackColor = true;
            // 
            // rbnEliminar
            // 
            this.rbnEliminar.AutoSize = true;
            this.rbnEliminar.Location = new System.Drawing.Point(21, 132);
            this.rbnEliminar.Name = "rbnEliminar";
            this.rbnEliminar.Size = new System.Drawing.Size(61, 17);
            this.rbnEliminar.TabIndex = 1;
            this.rbnEliminar.Text = "Eliminar";
            this.rbnEliminar.UseVisualStyleBackColor = true;
            // 
            // rbnNuevo
            // 
            this.rbnNuevo.AutoSize = true;
            this.rbnNuevo.Checked = true;
            this.rbnNuevo.Location = new System.Drawing.Point(21, 55);
            this.rbnNuevo.Name = "rbnNuevo";
            this.rbnNuevo.Size = new System.Drawing.Size(57, 17);
            this.rbnNuevo.TabIndex = 0;
            this.rbnNuevo.TabStop = true;
            this.rbnNuevo.Text = "Nuevo";
            this.rbnNuevo.UseVisualStyleBackColor = true;
            // 
            // txbGiro
            // 
            this.txbGiro.Location = new System.Drawing.Point(315, 195);
            this.txbGiro.Name = "txbGiro";
            this.txbGiro.Size = new System.Drawing.Size(175, 20);
            this.txbGiro.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(312, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Giro";
            // 
            // txbWeb
            // 
            this.txbWeb.Location = new System.Drawing.Point(38, 195);
            this.txbWeb.Name = "txbWeb";
            this.txbWeb.Size = new System.Drawing.Size(258, 20);
            this.txbWeb.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Sitio Web";
            // 
            // txbCorreo
            // 
            this.txbCorreo.Location = new System.Drawing.Point(38, 145);
            this.txbCorreo.Name = "txbCorreo";
            this.txbCorreo.Size = new System.Drawing.Size(452, 20);
            this.txbCorreo.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Correo Electronico";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Telefono Compañia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "NIT Compañia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "NombreCompañia";
            // 
            // txbTelefono
            // 
            this.txbTelefono.Location = new System.Drawing.Point(219, 91);
            this.txbTelefono.Name = "txbTelefono";
            this.txbTelefono.Size = new System.Drawing.Size(271, 20);
            this.txbTelefono.TabIndex = 2;
            // 
            // txbNIT
            // 
            this.txbNIT.Location = new System.Drawing.Point(38, 91);
            this.txbNIT.Name = "txbNIT";
            this.txbNIT.Size = new System.Drawing.Size(167, 20);
            this.txbNIT.TabIndex = 1;
            // 
            // txbCompania
            // 
            this.txbCompania.Location = new System.Drawing.Point(38, 40);
            this.txbCompania.Name = "txbCompania";
            this.txbCompania.Size = new System.Drawing.Size(452, 20);
            this.txbCompania.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.txbBuscar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(679, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(148, 22);
            this.toolStripButton1.Text = "Gestion De Proveedores";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // txbBuscar
            // 
            this.txbBuscar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txbBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txbBuscar.Name = "txbBuscar";
            this.txbBuscar.Size = new System.Drawing.Size(200, 25);
            // 
            // GestionProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 485);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "GestionProveedores";
            this.Text = "GestionProveedores";
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Operaciones.ResumeLayout(false);
            this.Operaciones.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbTelefono;
        private System.Windows.Forms.TextBox txbNIT;
        private System.Windows.Forms.TextBox txbCompania;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbGiro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbWeb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbCorreo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox Operaciones;
        private System.Windows.Forms.RadioButton rbnEliminar;
        private System.Windows.Forms.RadioButton rbnNuevo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox txbBuscar;
        private System.Windows.Forms.RadioButton rbnModificar;
        private System.Windows.Forms.Button btnAgregarContacto;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnAgregarDireccion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgDatos;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
    }
}