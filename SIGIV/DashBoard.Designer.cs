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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashBoard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ContentLayout = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCerrarSession = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lnlUser = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.Home = new System.Windows.Forms.TabPage();
            this.Empleados = new System.Windows.Forms.TabPage();
            this.Usuarios = new System.Windows.Forms.TabPage();
            this.Clientes = new System.Windows.Forms.TabPage();
            this.Facturas = new System.Windows.Forms.TabPage();
            this.Proveedores = new System.Windows.Forms.TabPage();
            this.Pedidos = new System.Windows.Forms.TabPage();
            this.Productos = new System.Windows.Forms.TabPage();
            this.Reportes = new System.Windows.Forms.TabPage();
            this.Configuraciones = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.materialTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ContentLayout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 129);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 656);
            this.panel1.TabIndex = 13;
            // 
            // ContentLayout
            // 
            this.ContentLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentLayout.Location = new System.Drawing.Point(0, 0);
            this.ContentLayout.Name = "ContentLayout";
            this.ContentLayout.Size = new System.Drawing.Size(1004, 656);
            this.ContentLayout.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnCerrarSession);
            this.panel3.Controls.Add(this.lnlUser);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1004, 35);
            this.panel3.TabIndex = 11;
            // 
            // btnCerrarSession
            // 
            this.btnCerrarSession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarSession.AutoSize = true;
            this.btnCerrarSession.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSession.ImageKey = "Cerrarsesion2.png";
            this.btnCerrarSession.ImageList = this.imageList1;
            this.btnCerrarSession.Location = new System.Drawing.Point(929, -1);
            this.btnCerrarSession.Name = "btnCerrarSession";
            this.btnCerrarSession.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCerrarSession.Size = new System.Drawing.Size(40, 38);
            this.btnCerrarSession.TabIndex = 1;
            this.btnCerrarSession.UseVisualStyleBackColor = true;
            this.btnCerrarSession.Click += new System.EventHandler(this.btnCerrarSession_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Clientes1.png");
            this.imageList1.Images.SetKeyName(1, "Empleados1.png");
            this.imageList1.Images.SetKeyName(2, "Factura1.png");
            this.imageList1.Images.SetKeyName(3, "Home1.png");
            this.imageList1.Images.SetKeyName(4, "Pedidos1.png");
            this.imageList1.Images.SetKeyName(5, "Productos.png");
            this.imageList1.Images.SetKeyName(6, "Proveedores1.png");
            this.imageList1.Images.SetKeyName(7, "Reportes.png");
            this.imageList1.Images.SetKeyName(8, "Usuarios1.png");
            this.imageList1.Images.SetKeyName(9, "Cerrarsesion.png");
            this.imageList1.Images.SetKeyName(10, "Configuraciones.png");
            this.imageList1.Images.SetKeyName(11, "Cerrarsesion2.png");
            // 
            // lnlUser
            // 
            this.lnlUser.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lnlUser.AutoSize = true;
            this.lnlUser.Location = new System.Drawing.Point(780, 10);
            this.lnlUser.Name = "lnlUser";
            this.lnlUser.Size = new System.Drawing.Size(35, 13);
            this.lnlUser.TabIndex = 0;
            this.lnlUser.Text = "label1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1004, 65);
            this.panel2.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.materialTabControl1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1004, 30);
            this.panel4.TabIndex = 0;
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.Home);
            this.materialTabControl1.Controls.Add(this.Empleados);
            this.materialTabControl1.Controls.Add(this.Usuarios);
            this.materialTabControl1.Controls.Add(this.Clientes);
            this.materialTabControl1.Controls.Add(this.Facturas);
            this.materialTabControl1.Controls.Add(this.Proveedores);
            this.materialTabControl1.Controls.Add(this.Pedidos);
            this.materialTabControl1.Controls.Add(this.Productos);
            this.materialTabControl1.Controls.Add(this.Reportes);
            this.materialTabControl1.Controls.Add(this.Configuraciones);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialTabControl1.ImageList = this.imageList1;
            this.materialTabControl1.Location = new System.Drawing.Point(0, 0);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(1004, 33);
            this.materialTabControl1.TabIndex = 0;
            this.materialTabControl1.SelectedIndexChanged += new System.EventHandler(this.materialTabControl1_SelectedIndexChanged_1);
            // 
            // Home
            // 
            this.Home.ImageKey = "Home1.png";
            this.Home.Location = new System.Drawing.Point(4, 39);
            this.Home.Name = "Home";
            this.Home.Padding = new System.Windows.Forms.Padding(3);
            this.Home.Size = new System.Drawing.Size(996, 0);
            this.Home.TabIndex = 0;
            this.Home.Text = "Home";
            this.Home.UseVisualStyleBackColor = true;
            // 
            // Empleados
            // 
            this.Empleados.ImageKey = "Empleados1.png";
            this.Empleados.Location = new System.Drawing.Point(4, 39);
            this.Empleados.Name = "Empleados";
            this.Empleados.Padding = new System.Windows.Forms.Padding(3);
            this.Empleados.Size = new System.Drawing.Size(980, 0);
            this.Empleados.TabIndex = 1;
            this.Empleados.Text = "Empleados";
            this.Empleados.UseVisualStyleBackColor = true;
            // 
            // Usuarios
            // 
            this.Usuarios.ImageKey = "Usuarios1.png";
            this.Usuarios.Location = new System.Drawing.Point(4, 39);
            this.Usuarios.Name = "Usuarios";
            this.Usuarios.Size = new System.Drawing.Size(980, 0);
            this.Usuarios.TabIndex = 2;
            this.Usuarios.Text = "Usuarios";
            this.Usuarios.UseVisualStyleBackColor = true;
            // 
            // Clientes
            // 
            this.Clientes.ImageKey = "Clientes1.png";
            this.Clientes.Location = new System.Drawing.Point(4, 39);
            this.Clientes.Name = "Clientes";
            this.Clientes.Size = new System.Drawing.Size(980, 0);
            this.Clientes.TabIndex = 3;
            this.Clientes.Text = "Clientes";
            this.Clientes.UseVisualStyleBackColor = true;
            // 
            // Facturas
            // 
            this.Facturas.ImageKey = "Factura1.png";
            this.Facturas.Location = new System.Drawing.Point(4, 39);
            this.Facturas.Name = "Facturas";
            this.Facturas.Size = new System.Drawing.Size(980, 0);
            this.Facturas.TabIndex = 4;
            this.Facturas.Text = "Facturas";
            this.Facturas.UseVisualStyleBackColor = true;
            // 
            // Proveedores
            // 
            this.Proveedores.ImageKey = "Proveedores1.png";
            this.Proveedores.Location = new System.Drawing.Point(4, 39);
            this.Proveedores.Name = "Proveedores";
            this.Proveedores.Size = new System.Drawing.Size(980, 0);
            this.Proveedores.TabIndex = 5;
            this.Proveedores.Text = "Proveedores";
            this.Proveedores.UseVisualStyleBackColor = true;
            // 
            // Pedidos
            // 
            this.Pedidos.ImageKey = "Pedidos1.png";
            this.Pedidos.Location = new System.Drawing.Point(4, 39);
            this.Pedidos.Name = "Pedidos";
            this.Pedidos.Size = new System.Drawing.Size(980, 0);
            this.Pedidos.TabIndex = 6;
            this.Pedidos.Text = "Pedidos";
            this.Pedidos.UseVisualStyleBackColor = true;
            // 
            // Productos
            // 
            this.Productos.ImageKey = "Productos.png";
            this.Productos.Location = new System.Drawing.Point(4, 39);
            this.Productos.Name = "Productos";
            this.Productos.Size = new System.Drawing.Size(980, 0);
            this.Productos.TabIndex = 7;
            this.Productos.Text = "Productos";
            this.Productos.UseVisualStyleBackColor = true;
            // 
            // Reportes
            // 
            this.Reportes.ImageKey = "Reportes.png";
            this.Reportes.Location = new System.Drawing.Point(4, 39);
            this.Reportes.Name = "Reportes";
            this.Reportes.Size = new System.Drawing.Size(980, 0);
            this.Reportes.TabIndex = 8;
            this.Reportes.Text = "Reportes";
            this.Reportes.UseVisualStyleBackColor = true;
            // 
            // Configuraciones
            // 
            this.Configuraciones.ImageKey = "Configuraciones.png";
            this.Configuraciones.Location = new System.Drawing.Point(4, 39);
            this.Configuraciones.Name = "Configuraciones";
            this.Configuraciones.Padding = new System.Windows.Forms.Padding(3);
            this.Configuraciones.Size = new System.Drawing.Size(980, 0);
            this.Configuraciones.TabIndex = 9;
            this.Configuraciones.Text = "Configuraciones";
            this.Configuraciones.UseVisualStyleBackColor = true;
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 788);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.DrawerAutoHide = false;
            this.DrawerAutoShow = true;
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControl1;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DashBoard";
            this.Text = " SIGIV";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.materialTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lnlUser;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage Home;
        private System.Windows.Forms.TabPage Empleados;
        private System.Windows.Forms.TabPage Usuarios;
        private System.Windows.Forms.TabPage Clientes;
        private System.Windows.Forms.TabPage Facturas;
        private System.Windows.Forms.TabPage Proveedores;
        private System.Windows.Forms.TabPage Pedidos;
        private System.Windows.Forms.TabPage Productos;
        private System.Windows.Forms.TabPage Reportes;
        private System.Windows.Forms.Panel ContentLayout;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnCerrarSession;
        private System.Windows.Forms.TabPage Configuraciones;
    }
}