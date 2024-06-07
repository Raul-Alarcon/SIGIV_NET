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
            this.accionBar1 = new SIGIV.Components.AccionBar();
            this.sideBard = new SIGIV.Components.DragPanel();
            this.settings = new System.Windows.Forms.Button();
            this.home = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.materialDrawer3 = new MaterialSkin.Controls.MaterialDrawer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ContentLayout = new System.Windows.Forms.Panel();
            this.empleados = new System.Windows.Forms.Button();
            this.sideBard.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
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
            // accionBar1
            // 
            this.accionBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.accionBar1.Location = new System.Drawing.Point(0, 0);
            this.accionBar1.Name = "accionBar1";
            this.accionBar1.Size = new System.Drawing.Size(843, 32);
            this.accionBar1.TabIndex = 9;
            this.accionBar1.Titulo = "DashBoard";
            // 
            // sideBard
            // 
            this.sideBard.BackColor = System.Drawing.Color.White;
            this.sideBard.BorderRadius = 1;
            this.sideBard.Controls.Add(this.empleados);
            this.sideBard.Controls.Add(this.settings);
            this.sideBard.Controls.Add(this.home);
            this.sideBard.Controls.Add(this.panel2);
            this.sideBard.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideBard.Location = new System.Drawing.Point(0, 0);
            this.sideBard.Name = "sideBard";
            this.sideBard.Shadow = 10;
            this.sideBard.Size = new System.Drawing.Size(64, 540);
            this.sideBard.TabIndex = 10;
            // 
            // settings
            // 
            this.settings.BackColor = System.Drawing.Color.Transparent;
            this.settings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("settings.BackgroundImage")));
            this.settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.settings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.settings.FlatAppearance.BorderSize = 0;
            this.settings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settings.Location = new System.Drawing.Point(0, 476);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(64, 64);
            this.settings.TabIndex = 2;
            this.settings.UseVisualStyleBackColor = false;
            this.settings.Click += new System.EventHandler(this.buttonSiderBard_Click);
            // 
            // home
            // 
            this.home.BackColor = System.Drawing.Color.Transparent;
            this.home.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("home.BackgroundImage")));
            this.home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.home.Dock = System.Windows.Forms.DockStyle.Top;
            this.home.FlatAppearance.BorderSize = 0;
            this.home.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.home.Location = new System.Drawing.Point(0, 87);
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
            this.panel2.Size = new System.Drawing.Size(64, 87);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.Location = new System.Drawing.Point(12, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 41);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
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
            this.panel1.Controls.Add(this.accionBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(64, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 540);
            this.panel1.TabIndex = 13;
            // 
            // ContentLayout
            // 
            this.ContentLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentLayout.Location = new System.Drawing.Point(0, 32);
            this.ContentLayout.Name = "ContentLayout";
            this.ContentLayout.Size = new System.Drawing.Size(843, 508);
            this.ContentLayout.TabIndex = 10;
            // 
            // empleados
            // 
            this.empleados.BackColor = System.Drawing.Color.Transparent;
            this.empleados.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("empleados.BackgroundImage")));
            this.empleados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.empleados.Dock = System.Windows.Forms.DockStyle.Top;
            this.empleados.FlatAppearance.BorderSize = 0;
            this.empleados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.empleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.empleados.Location = new System.Drawing.Point(0, 151);
            this.empleados.Name = "empleados";
            this.empleados.Size = new System.Drawing.Size(64, 64);
            this.empleados.TabIndex = 3;
            this.empleados.UseVisualStyleBackColor = false;
            this.empleados.Click += new System.EventHandler(this.buttonSiderBard_Click);
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 540);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.materialDrawer3);
            this.Controls.Add(this.sideBard);
            this.Controls.Add(this.materialDrawer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DashBoard";
            this.Text = " ";
            this.sideBard.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialDrawer materialDrawer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private Components.AccionBar accionBar1;
        private Components.DragPanel sideBard;
        private MaterialSkin.Controls.MaterialDrawer materialDrawer3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button home;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button settings;
        private System.Windows.Forms.Panel ContentLayout;
        private System.Windows.Forms.Button empleados;
    }
}