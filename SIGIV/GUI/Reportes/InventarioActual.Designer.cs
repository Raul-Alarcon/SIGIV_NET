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
            this.SuspendLayout();
            // 
            // crvReporteInventarioActual
            // 
            this.crvReporteInventarioActual.ActiveViewIndex = -1;
            this.crvReporteInventarioActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReporteInventarioActual.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvReporteInventarioActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvReporteInventarioActual.Location = new System.Drawing.Point(0, 0);
            this.crvReporteInventarioActual.Name = "crvReporteInventarioActual";
            this.crvReporteInventarioActual.Size = new System.Drawing.Size(912, 505);
            this.crvReporteInventarioActual.TabIndex = 1;
            this.crvReporteInventarioActual.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // InventarioActual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 505);
            this.Controls.Add(this.crvReporteInventarioActual);
            this.Name = "InventarioActual";
            this.Text = "InventarioActual";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReporteInventarioActual;
    }
}