using SIGIV.CLS.DTO.Reportes;
using SIGIV.DataLayer;
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
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
        }

        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            try
            {
                var ventas = await VentasMensualesReporte.GetDataSourse(dtpInicio.Value, dtpInicio.Value);
                VentasMensualesProducto ventasMensuales = new VentasMensualesProducto();
                ventasMensuales.SetDataSource(ventas);

                ventasMensuales.SetParameterValue("fechaInicio", dtpInicio.Value);
                ventasMensuales.SetParameterValue("fechaFinal", dtpFinal.Value);
                crvVentas.ReportSource = ventasMensuales;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
