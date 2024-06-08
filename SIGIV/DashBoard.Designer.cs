namespace SIGIV
{
    partial class DashBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashBoard));
            this.materialDrawer1 = new MaterialSkin.Controls.MaterialDrawer();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.materialDrawer3 = new MaterialSkin.Controls.MaterialDrawer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ContentLayout = new System.Windows.Forms.Panel();
            this.sideBard = new SIGIV.Components.DragPanel();
            this.reportes = new System.Windows.Forms.Button();
            this.pedidos = new System.Windows.Forms.Button();
            this.facturas = new System.Windows.Forms.Button();
            this.productos = new System.Windows.Forms.Button();
            this.proveedores = new System.Windows.Forms.Button();
            this.clientes = new System.Windows.Forms.Button();
            this.usuarios = new System.Windows.Forms.Button();
            this.empleados = new System.Windows.Forms.Button();
            this.settings = new System.Windows.Forms.Button();
            this.home = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.sideBard.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // materialDrawer1
            // 
            this.materialDrawer1.AutoHide = false;
            this.materialDrawer1.AutoShow = false;
            this.materialDrawer1.BackgroundWithAccent = false;
            this.materialDrawer1.BaseTabControl = null;
            this.materialDrawer1.Depth = 0;
            this.materialDrawer1.HighlightWithAccent = true;
            this.materialDrawer1.IndicatorWidth = 0;
            this.materialDrawer1.IsOpen = false;
            this.materialDrawer1.Location = new System.Drawing.Point(-250, 206);
            this.materialDrawer1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDrawer1.Name = "materialDrawer1";
            this.materialDrawer1.ShowIconsWhenHidden = false;
            this.materialDrawer1.Size = new System.Drawing.Size(250, 120);
            this.materialDrawer1.TabIndex = 8;
            this.materialDrawer1.Text = "materialDrawer1";
            this.materialDrawer1.UseColors = false;
            // 
            // materialDrawer3
            // 
            this.materialDrawer3.AutoHide = false;
            this.materialDrawer3.AutoShow = false;
            this.materialDrawer3.BackgroundWithAccent = false;
            this.materialDrawer3.BaseTabControl = null;
            this.materialDrawer3.Depth = 0;
            this.materialDrawer3.HighlightWithAccent = true;
            this.materialDrawer3.IndicatorWidth = 0;
            this.materialDrawer3.IsOpen = false;
            this.materialDrawer3.Location = new System.Drawing.Point(-283, 144);
            this.materialDrawer3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDrawer3.Name = "materialDrawer3";
            this.materialDrawer3.ShowIconsWhenHidden = false;
            this.materialDrawer3.Size = new System.Drawing.Size(283, 162);
            this.materialDrawer3.TabIndex = 12;
            this.materialDrawer3.Text = "materialDrawer3";
            this.materialDrawer3.UseColors = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ContentLayout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(64, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 749);
            this.panel1.TabIndex = 13;
            // 
            // ContentLayout
            // 
            this.ContentLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentLayout.Location = new System.Drawing.Point(0, 0);
            this.ContentLayout.Name = "ContentLayout";
            this.ContentLayout.Size = new System.Drawing.Size(843, 749);
            this.ContentLayout.TabIndex = 10;
            // 
            // sideBard
            // 
            this.sideBard.BackColor = System.Drawing.Color.White;
            this.sideBard.BorderRadius = 1;
            this.sideBard.Controls.Add(this.reportes);
            this.sideBard.Controls.Add(this.pedidos);
            this.sideBard.Controls.Add(this.facturas);
            this.sideBard.Controls.Add(this.productos);
            this.sideBard.Controls.Add(this.proveedores);
            this.sideBard.Controls.Add(this.clientes);
            this.sideBard.Controls.Add(this.usuarios);
            this.sideBard.Controls.Add(this.empleados);
            this.sideBard.Controls.Add(this.settings);
            this.sideBard.Controls.Add(this.home);
            this.sideBard.Controls.Add(this.panel2);
            this.sideBard.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideBard.Location = new System.Drawing.Point(0, 0);
            this.sideBard.Name = "sideBard";
            this.sideBard.Shadow = 10;
            this.sideBard.Size = new System.Drawing.Size(64, 749);
            this.sideBard.TabIndex = 10;
            // 
            // reportes
            // 
            this.reportes.BackColor = System.Drawing.Color.Transparent;
            this.reportes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.reportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.reportes.FlatAppearance.BorderSize = 0;
            this.reportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.reportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportes.Image = ((System.Drawing.Image)(resources.GetObject("reportes.Image")));
            this.reportes.Location = new System.Drawing.Point(0, 580);
            this.reportes.Name = "reportes";
            this.reportes.Size = new System.Drawing.Size(64, 64);
            this.reportes.TabIndex = 10;
            this.reportes.UseVisualStyleBackColor = false;
            this.reportes.Click += new System.EventHandler(this.buttonSiderBard_Click);
            // 
            // pedidos
            // 
            this.pedidos.BackColor = System.Drawing.Color.Transparent;
            this.pedidos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pedidos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pedidos.FlatAppearance.BorderSize = 0;
            this.pedidos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pedidos.Image = ((System.Drawing.Image)(resources.GetObject("pedidos.Image")));
            this.pedidos.Location = new System.Drawing.Point(0, 516);
            this.pedidos.Name = "pedidos";
            this.pedidos.Size = new System.Drawing.Size(64, 64);
            this.pedidos.TabIndex = 9;
            this.pedidos.UseVisualStyleBackColor = false;
            this.pedidos.Click += new System.EventHandler(this.buttonSiderBard_Click);
            // 
            // facturas
            // 
            this.facturas.BackColor = System.Drawing.Color.Transparent;
            this.facturas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.facturas.Dock = System.Windows.Forms.DockStyle.Top;
            this.facturas.FlatAppearance.BorderSize = 0;
            this.facturas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.facturas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.facturas.Image = ((System.Drawing.Image)(resources.GetObject("facturas.Image")));
            this.facturas.Location = new System.Drawing.Point(0, 452);
            this.facturas.Name = "facturas";
            this.facturas.Size = new System.Drawing.Size(64, 64);
            this.facturas.TabIndex = 8;
            this.facturas.UseVisualStyleBackColor = false;
            this.facturas.Click += new System.EventHandler(this.buttonSiderBard_Click);
            // 
            // productos
            // 
            this.productos.BackColor = System.Drawing.Color.Transparent;
            this.productos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.productos.Dock = System.Windows.Forms.DockStyle.Top;
            this.productos.FlatAppearance.BorderSize = 0;
            this.productos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.productos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.productos.Image = ((System.Drawing.Image)(resources.GetObject("productos.Image")));
            this.productos.Location = new System.Drawing.Point(0, 388);
            this.productos.Name = "productos";
            this.productos.Size = new System.Drawing.Size(64, 64);
            this.productos.TabIndex = 7;
            this.productos.UseVisualStyleBackColor = false;
            this.productos.Click += new System.EventHandler(this.buttonSiderBard_Click);
            // 
            // proveedores
            // 
            this.proveedores.BackColor = System.Drawing.Color.Transparent;
            this.proveedores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.proveedores.Dock = System.Windows.Forms.DockStyle.Top;
            this.proveedores.FlatAppearance.BorderSize = 0;
            this.proveedores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.proveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.proveedores.Image = ((System.Drawing.Image)(resources.GetObject("proveedores.Image")));
            this.proveedores.Location = new System.Drawing.Point(0, 324);
            this.proveedores.Name = "proveedores";
            this.proveedores.Size = new System.Drawing.Size(64, 64);
            this.proveedores.TabIndex = 6;
            this.proveedores.UseVisualStyleBackColor = false;
            this.proveedores.Click += new System.EventHandler(this.buttonSiderBard_Click);
            // 
            // clientes
            // 
            this.clientes.BackColor = System.Drawing.Color.Transparent;
            this.clientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.clientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.clientes.FlatAppearance.BorderSize = 0;
            this.clientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.clientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clientes.Image = ((System.Drawing.Image)(resources.GetObject("clientes.Image")));
            this.clientes.Location = new System.Drawing.Point(0, 260);
            this.clientes.Name = "clientes";
            this.clientes.Size = new System.Drawing.Size(64, 64);
            this.clientes.TabIndex = 5;
            this.clientes.UseVisualStyleBackColor = false;
            this.clientes.Click += new System.EventHandler(this.buttonSiderBard_Click);
            // 
            // usuarios
            // 
            this.usuarios.BackColor = System.Drawing.Color.Transparent;
            this.usuarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.usuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.usuarios.FlatAppearance.BorderSize = 0;
            this.usuarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.usuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.usuarios.Image = ((System.Drawing.Image)(resources.GetObject("usuarios.Image")));
            this.usuarios.Location = new System.Drawing.Point(0, 196);
            this.usuarios.Name = "usuarios";
            this.usuarios.Size = new System.Drawing.Size(64, 64);
            this.usuarios.TabIndex = 4;
            this.usuarios.UseVisualStyleBackColor = false;
            this.usuarios.Click += new System.EventHandler(this.buttonSiderBard_Click);
            // 
            // empleados
            // 
            this.empleados.BackColor = System.Drawing.Color.Transparent;
            this.empleados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.empleados.Dock = System.Windows.Forms.DockStyle.Top;
            this.empleados.FlatAppearance.BorderSize = 0;
            this.empleados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.empleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.empleados.Image = ((System.Drawing.Image)(resources.GetObject("empleados.Image")));
            this.empleados.Location = new System.Drawing.Point(0, 132);
            this.empleados.Name = "empleados";
            this.empleados.Size = new System.Drawing.Size(64, 64);
            this.empleados.TabIndex = 3;
            this.empleados.UseVisualStyleBackColor = false;
            this.empleados.Click += new System.EventHandler(this.buttonSiderBard_Click);
            // 
            // settings
            // 
            this.settings.BackColor = System.Drawing.Color.Transparent;
            this.settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.settings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.settings.FlatAppearance.BorderSize = 0;
            this.settings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settings.Image = ((System.Drawing.Image)(resources.GetObject("settings.Image")));
            this.settings.Location = new System.Drawing.Point(0, 685);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(64, 64);
            this.settings.TabIndex = 2;
            this.settings.UseVisualStyleBackColor = false;
            this.settings.Click += new System.EventHandler(this.buttonSiderBard_Click);
            // 
            // home
            // 
            this.home.BackColor = System.Drawing.Color.Transparent;
            this.home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.home.Dock = System.Windows.Forms.DockStyle.Top;
            this.home.FlatAppearance.BorderSize = 0;
            this.home.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.home.Image = ((System.Drawing.Image)(resources.GetObject("home.Image")));
            this.home.Location = new System.Drawing.Point(0, 68);
            this.home.Name = "home";
            this.home.Size = new System.Drawing.Size(64, 64);
            this.home.TabIndex = 1;
            this.home.UseVisualStyleBackColor = false;
            this.home.Click += new System.EventHandler(this.buttonSiderBard_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(64, 68);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 749);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.materialDrawer3);
            this.Controls.Add(this.sideBard);
            this.Controls.Add(this.materialDrawer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DashBoard";
            this.Text = " ";
            this.panel1.ResumeLayout(false);
            this.sideBard.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialDrawer materialDrawer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private Components.DragPanel sideBard;
        private MaterialSkin.Controls.MaterialDrawer materialDrawer3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button home;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button settings;
        private System.Windows.Forms.Panel ContentLayout;
        private System.Windows.Forms.Button empleados;
        private System.Windows.Forms.Button usuarios;
        private System.Windows.Forms.Button clientes;
        private System.Windows.Forms.Button facturas;
        private System.Windows.Forms.Button productos;
        private System.Windows.Forms.Button proveedores;
        private System.Windows.Forms.Button reportes;
        private System.Windows.Forms.Button pedidos;
    }
}