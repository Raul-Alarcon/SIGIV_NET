namespace SIGIV.GUI.View
{
    partial class Configuraciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuraciones));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.btnDistritos = new System.Windows.Forms.Button();
            this.btnMunicipios = new System.Windows.Forms.Button();
            this.btnDeptos = new System.Windows.Forms.Button();
            this.btnPaises = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15);
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCategorias);
            this.panel2.Controls.Add(this.btnDistritos);
            this.panel2.Controls.Add(this.btnMunicipios);
            this.panel2.Controls.Add(this.btnDeptos);
            this.panel2.Controls.Add(this.btnPaises);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(15, 15);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(785, 420);
            this.panel2.TabIndex = 0;
            // 
            // btnCategorias
            // 
            this.btnCategorias.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategorias.FlatAppearance.BorderSize = 0;
            this.btnCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategorias.Location = new System.Drawing.Point(10, 257);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(765, 43);
            this.btnCategorias.TabIndex = 5;
            this.btnCategorias.Text = "Gestion Categorias";
            this.btnCategorias.UseVisualStyleBackColor = true;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // btnDistritos
            // 
            this.btnDistritos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDistritos.FlatAppearance.BorderSize = 0;
            this.btnDistritos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDistritos.Location = new System.Drawing.Point(10, 214);
            this.btnDistritos.Name = "btnDistritos";
            this.btnDistritos.Size = new System.Drawing.Size(765, 43);
            this.btnDistritos.TabIndex = 4;
            this.btnDistritos.Text = "Gestion Distritos";
            this.btnDistritos.UseVisualStyleBackColor = true;
            this.btnDistritos.Click += new System.EventHandler(this.btnDistritos_Click);
            // 
            // btnMunicipios
            // 
            this.btnMunicipios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMunicipios.FlatAppearance.BorderSize = 0;
            this.btnMunicipios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMunicipios.Location = new System.Drawing.Point(10, 171);
            this.btnMunicipios.Name = "btnMunicipios";
            this.btnMunicipios.Size = new System.Drawing.Size(765, 43);
            this.btnMunicipios.TabIndex = 3;
            this.btnMunicipios.Text = "Gestion Municipios";
            this.btnMunicipios.UseVisualStyleBackColor = true;
            this.btnMunicipios.Click += new System.EventHandler(this.btnMunicipios_Click);
            // 
            // btnDeptos
            // 
            this.btnDeptos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDeptos.FlatAppearance.BorderSize = 0;
            this.btnDeptos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeptos.Location = new System.Drawing.Point(10, 128);
            this.btnDeptos.Name = "btnDeptos";
            this.btnDeptos.Size = new System.Drawing.Size(765, 43);
            this.btnDeptos.TabIndex = 2;
            this.btnDeptos.Text = "Gestion Departamentos";
            this.btnDeptos.UseVisualStyleBackColor = true;
            this.btnDeptos.Click += new System.EventHandler(this.btnDeptos_Click);
            // 
            // btnPaises
            // 
            this.btnPaises.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPaises.BackgroundImage")));
            this.btnPaises.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPaises.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPaises.FlatAppearance.BorderSize = 0;
            this.btnPaises.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaises.Location = new System.Drawing.Point(10, 85);
            this.btnPaises.Name = "btnPaises";
            this.btnPaises.Size = new System.Drawing.Size(765, 43);
            this.btnPaises.TabIndex = 1;
            this.btnPaises.Text = "Gestion Paises";
            this.btnPaises.UseVisualStyleBackColor = true;
            this.btnPaises.Click += new System.EventHandler(this.btnPaises_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.label1.Size = new System.Drawing.Size(765, 75);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configuraciones";
            // 
            // Configuraciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Configuraciones";
            this.Text = "Configuraciones";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDistritos;
        private System.Windows.Forms.Button btnMunicipios;
        private System.Windows.Forms.Button btnDeptos;
        private System.Windows.Forms.Button btnPaises;
        private System.Windows.Forms.Button btnCategorias;
    }
}