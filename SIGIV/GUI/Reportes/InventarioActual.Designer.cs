namespace SIGIV.GUI.Reportes
{
    partial class InventarioActual
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
            this.crvReporteInventarioActual = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crvReporteInventarioActual
            // 
            this.crvReporteInventarioActual.ActiveViewIndex = -1;
            this.crvReporteInventarioActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReporteInventarioActual.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvReporteInventarioActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvReporteInventarioActual.Location = new System.Drawing.Point(3, 16);
            this.crvReporteInventarioActual.Name = "crvReporteInventarioActual";
            this.crvReporteInventarioActual.Size = new System.Drawing.Size(906, 486);
            this.crvReporteInventarioActual.TabIndex = 1;
            this.crvReporteInventarioActual.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.crvReporteInventarioActual);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(912, 505);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reporte de Inventario Acual";
            // 
            // InventarioActual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 505);
            this.Controls.Add(this.groupBox1);
            this.Name = "InventarioActual";
            this.Text = "InventarioActual";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReporteInventarioActual;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}