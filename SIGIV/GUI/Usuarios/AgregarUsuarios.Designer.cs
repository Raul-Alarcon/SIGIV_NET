namespace SIGIV.GUI.Usuarios
{
    partial class AgregarUsuarios
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
            this.label4 = new System.Windows.Forms.Label();
            this.txbClave = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbUsario = new System.Windows.Forms.TextBox();
            this.cmbIdRol = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbIdEmpleado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgDatos = new System.Windows.Forms.DataGridView();
            this.rbnEditar = new System.Windows.Forms.RadioButton();
            this.rbnEliminar = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15);
            this.panel1.Size = new System.Drawing.Size(429, 488);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txbClave);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txbUsario);
            this.groupBox1.Controls.Add(this.cmbIdRol);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbIdEmpleado);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 197);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar Usuario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(204, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Clave";
            // 
            // txbClave
            // 
            this.txbClave.Location = new System.Drawing.Point(207, 48);
            this.txbClave.Name = "txbClave";
            this.txbClave.Size = new System.Drawing.Size(160, 20);
            this.txbClave.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Usuario";
            // 
            // txbUsario
            // 
            this.txbUsario.Location = new System.Drawing.Point(32, 48);
            this.txbUsario.Name = "txbUsario";
            this.txbUsario.Size = new System.Drawing.Size(160, 20);
            this.txbUsario.TabIndex = 4;
            // 
            // cmbIdRol
            // 
            this.cmbIdRol.FormattingEnabled = true;
            this.cmbIdRol.Location = new System.Drawing.Point(32, 113);
            this.cmbIdRol.Name = "cmbIdRol";
            this.cmbIdRol.Size = new System.Drawing.Size(160, 21);
            this.cmbIdRol.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rol";
            // 
            // cmbIdEmpleado
            // 
            this.cmbIdEmpleado.FormattingEnabled = true;
            this.cmbIdEmpleado.Location = new System.Drawing.Point(207, 113);
            this.cmbIdEmpleado.Name = "cmbIdEmpleado";
            this.cmbIdEmpleado.Size = new System.Drawing.Size(160, 21);
            this.cmbIdEmpleado.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empleado";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(292, 161);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbnEliminar);
            this.groupBox2.Controls.Add(this.rbnEditar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(15, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 53);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gestion Usuario";
            // 
            // dtgDatos
            // 
            this.dtgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgDatos.Location = new System.Drawing.Point(3, 16);
            this.dtgDatos.Name = "dtgDatos";
            this.dtgDatos.Size = new System.Drawing.Size(393, 189);
            this.dtgDatos.TabIndex = 1;
            // 
            // rbnEditar
            // 
            this.rbnEditar.AutoSize = true;
            this.rbnEditar.Location = new System.Drawing.Point(127, 19);
            this.rbnEditar.Name = "rbnEditar";
            this.rbnEditar.Size = new System.Drawing.Size(52, 17);
            this.rbnEditar.TabIndex = 3;
            this.rbnEditar.TabStop = true;
            this.rbnEditar.Text = "Editar";
            this.rbnEditar.UseVisualStyleBackColor = true;
            // 
            // rbnEliminar
            // 
            this.rbnEliminar.AutoSize = true;
            this.rbnEliminar.Location = new System.Drawing.Point(207, 19);
            this.rbnEliminar.Name = "rbnEliminar";
            this.rbnEliminar.Size = new System.Drawing.Size(61, 17);
            this.rbnEliminar.TabIndex = 4;
            this.rbnEliminar.TabStop = true;
            this.rbnEliminar.Text = "Eliminar";
            this.rbnEliminar.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtgDatos);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(15, 265);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(399, 208);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lista Usuarios";
            // 
            // AgregarUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 488);
            this.Controls.Add(this.panel1);
            this.Name = "AgregarUsuarios";
            this.Text = "AgregarUsuarios";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbClave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbUsario;
        private System.Windows.Forms.ComboBox cmbIdRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbIdEmpleado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgDatos;
        private System.Windows.Forms.RadioButton rbnEliminar;
        private System.Windows.Forms.RadioButton rbnEditar;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}