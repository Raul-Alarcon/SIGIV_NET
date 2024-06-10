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
    public partial class Compras : Form
    {
        public int nf = 12;
        public Compras()
        {
            InitializeComponent();
        }

        override protected async void OnLoad(EventArgs e)
        {
            try
            {
                var compras = await CLS.DTO.Reportes.ComprasReporte.GetDataSource(nf);
                ReporteCompra reporteCompra = new ReporteCompra();
                reporteCompra.SetDataSource(compras);
                crvFactura.ReportSource = reporteCompra;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }
    }
}
