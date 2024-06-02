namespace SIGIV.GUI.Productos
{
    partial class GestionProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionProductos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbNombre = new System.Windows.Forms.TextBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txbStock = new System.Windows.Forms.TextBox();
            this.txbPrecio = new System.Windows.Forms.TextBox();
            this.btnRegistrarStock = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbModificar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tscBuscar = new System.Windows.Forms.ToolStripComboBox();
            this.dtgDatos = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15);
            this.panel1.Size = new System.Drawing.Size(852, 406);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnRegistrarStock);
            this.groupBox1.Controls.Add(this.txbPrecio);
            this.groupBox1.Controls.Add(this.txbStock);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.cmbCategoria);
            this.groupBox1.Controls.Add(this.txbNombre);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 376);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formulario";
            // 
            // txbNombre
            // 
            this.txbNombre.Location = new System.Drawing.Point(26, 41);
            this.txbNombre.Name = "txbNombre";
            this.txbNombre.Size = new System.Drawing.Size(273, 20);
            this.txbNombre.TabIndex = 0;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(26, 90);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(173, 21);
            this.cmbCategoria.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(26, 217);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(273, 100);
            this.textBox3.TabIndex = 3;
            // 
            // txbStock
            // 
            this.txbStock.Location = new System.Drawing.Point(26, 145);
            this.txbStock.Name = "txbStock";
            this.txbStock.Size = new System.Drawing.Size(121, 20);
            this.txbStock.TabIndex = 4;
            // 
            // txbPrecio
            // 
            this.txbPrecio.Location = new System.Drawing.Point(215, 91);
            this.txbPrecio.Name = "txbPrecio";
            this.txbPrecio.Size = new System.Drawing.Size(84, 20);
            this.txbPrecio.TabIndex = 5;
            // 
            // btnRegistrarStock
            // 
            this.btnRegistrarStock.Location = new System.Drawing.Point(164, 145);
            this.btnRegistrarStock.Name = "btnRegistrarStock";
            this.btnRegistrarStock.Size = new System.Drawing.Size(135, 23);
            this.btnRegistrarStock.TabIndex = 6;
            this.btnRegistrarStock.Text = "Registrar Stock";
            this.btnRegistrarStock.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(224, 339);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Categoria";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Precio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Stock";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Descripcion";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgDatos);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(337, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(500, 376);
            this.panel2.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.tsbModificar,
            this.toolStripSeparator2,
            this.tsbEliminar,
            this.toolStripSeparator3,
            this.tscBuscar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(500, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbModificar
            // 
            this.tsbModificar.Image = ((System.Drawing.Image)(resources.GetObject("tsbModificar.Image")));
            this.tsbModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbModificar.Name = "tsbModificar";
            this.tsbModificar.Size = new System.Drawing.Size(78, 22);
            this.tsbModificar.Text = "Modificar";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEliminar.Image")));
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(70, 22);
            this.tsbEliminar.Text = "Eliminar";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tscBuscar
            // 
            this.tscBuscar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tscBuscar.Name = "tscBuscar";
            this.tscBuscar.Size = new System.Drawing.Size(200, 25);
            // 
            // dtgDatos
            // 
            this.dtgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgDatos.Location = new System.Drawing.Point(0, 25);
            this.dtgDatos.Name = "dtgDatos";
            this.dtgDatos.Size = new System.Drawing.Size(500, 351);
            this.dtgDatos.TabIndex = 1;
            // 
            // GestionProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 406);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "GestionProductos";
            this.Text = "GestionProductos";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnRegistrarStock;
        private System.Windows.Forms.TextBox txbPrecio;
        private System.Windows.Forms.TextBox txbStock;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.TextBox txbNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbModificar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox tscBuscar;
        private System.Windows.Forms.DataGridView dtgDatos;
    }
}