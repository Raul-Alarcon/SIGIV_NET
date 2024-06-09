using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGIV.GUI.Facturas
{
    public partial class AgregarFacturas : Form
    {
        public AgregarFacturas()
        {
            InitializeComponent();
        }


        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                await CargarFormasDePago();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e); 
        }

        private async Task CargarFormasDePago()
        {
            throw new NotImplementedException();
        }
    }
}
