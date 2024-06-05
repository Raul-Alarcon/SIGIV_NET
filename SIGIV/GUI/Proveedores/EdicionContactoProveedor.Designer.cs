namespace SIGIV.GUI.Proveedores
{
    partial class EdicionContactoProveedor
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbeMailContacto = new System.Windows.Forms.TextBox();
            this.txbobservacion = new System.Windows.Forms.TextBox();
            this.txbtelefonoContacto = new System.Windows.Forms.TextBox();
            this.txbApellidosContacto = new System.Windows.Forms.TextBox();
            this.txbcargoContacto = new System.Windows.Forms.TextBox();
            this.txbnombresContacto = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15);
            this.panel1.Size = new System.Drawing.Size(424, 450);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txbeMailContacto);
            this.groupBox1.Controls.Add(this.txbobservacion);
            this.groupBox1.Controls.Add(this.txbtelefonoContacto);
            this.groupBox1.Controls.Add(this.txbApellidosContacto);
            this.groupBox1.Controls.Add(this.txbcargoContacto);
            this.groupBox1.Controls.Add(this.txbnombresContacto);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 420);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formulario";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(40, 391);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Comentario";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Email";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(193, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Telefono";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cargo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Apellidos";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombres";
            // 
            // txbeMailContacto
            // 
            this.txbeMailContacto.Location = new System.Drawing.Point(40, 219);
            this.txbeMailContacto.Name = "txbeMailContacto";
            this.txbeMailContacto.Size = new System.Drawing.Size(306, 20);
            this.txbeMailContacto.TabIndex = 5;
            // 
            // txbobservacion
            // 
            this.txbobservacion.Location = new System.Drawing.Point(40, 273);
            this.txbobservacion.Multiline = true;
            this.txbobservacion.Name = "txbobservacion";
            this.txbobservacion.Size = new System.Drawing.Size(306, 100);
            this.txbobservacion.TabIndex = 4;
            // 
            // txbtelefonoContacto
            // 
            this.txbtelefonoContacto.Location = new System.Drawing.Point(196, 165);
            this.txbtelefonoContacto.Name = "txbtelefonoContacto";
            this.txbtelefonoContacto.Size = new System.Drawing.Size(150, 20);
            this.txbtelefonoContacto.TabIndex = 3;
            // 
            // txbApellidosContacto
            // 
            this.txbApellidosContacto.Location = new System.Drawing.Point(40, 112);
            this.txbApellidosContacto.Name = "txbApellidosContacto";
            this.txbApellidosContacto.Size = new System.Drawing.Size(306, 20);
            this.txbApellidosContacto.TabIndex = 2;
            // 
            // txbcargoContacto
            // 
            this.txbcargoContacto.Location = new System.Drawing.Point(40, 165);
            this.txbcargoContacto.Name = "txbcargoContacto";
            this.txbcargoContacto.Size = new System.Drawing.Size(150, 20);
            this.txbcargoContacto.TabIndex = 1;
            // 
            // txbnombresContacto
            // 
            this.txbnombresContacto.Location = new System.Drawing.Point(40, 52);
            this.txbnombresContacto.Name = "txbnombresContacto";
            this.txbnombresContacto.Size = new System.Drawing.Size(306, 20);
            this.txbnombresContacto.TabIndex = 0;
            // 
            // EdicionContactoProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EdicionContactoProveedor";
            this.Text = "Edicion Contacto Proveedor";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txbobservacion;
        private System.Windows.Forms.TextBox txbtelefonoContacto;
        private System.Windows.Forms.TextBox txbApellidosContacto;
        private System.Windows.Forms.TextBox txbcargoContacto;
        private System.Windows.Forms.TextBox txbnombresContacto;
        private System.Windows.Forms.TextBox txbeMailContacto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGuardar;
    }
}