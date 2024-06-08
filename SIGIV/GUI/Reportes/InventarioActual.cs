using SIGIV.CLS.DTO.Reportes;
using SIGIV.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGIV.GUI.Reportes
{
    public partial class InventarioActual : Form
    {
        public InventarioActual()
        {
            InitializeComponent();
        }
        override async protected void OnLoad(EventArgs e)
        {
            try
            {
                var producto = await InventarioActualReporte.GetDataSource();
                InformeInventarioActual inventarioActual = new InformeInventarioActual();
                inventarioActual.SetDataSource(producto);
                crvReporteInventarioActual.ReportSource = inventarioActual;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }
    }
}
