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
    public partial class ClienteFrecuente : Form
    {
        public ClienteFrecuente()
        {
            InitializeComponent();
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var clientes = await ClientesFrecuentesReporte.GetDataSource(dtpInicio.Value, dtpFinal.Value);
                InformeClienteFrecuente clienteFrecuente = new InformeClienteFrecuente();
                clienteFrecuente.SetDataSource(clientes);
                clienteFrecuente.SetParameterValue("fechaInicio", dtpInicio.Value);
                clienteFrecuente.SetParameterValue("fechaFinal", dtpFinal.Value);
                crvReporteClienteFrecuente.ReportSource = clienteFrecuente;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
