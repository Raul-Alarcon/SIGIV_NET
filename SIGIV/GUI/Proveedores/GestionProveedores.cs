using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGIV.GUI.Proveedores
{
    public partial class GestionProveedores : Form
    {
        public GestionProveedores()
        {
            InitializeComponent();
        }

        private void btnAgregarContacto_Click(object sender, EventArgs e)
        {
            EdicionContactoProveedor FormularioProveedor = new EdicionContactoProveedor();
            FormularioProveedor.ShowDialog();
        }

        private void btnAgregarDireccion_Click(object sender, EventArgs e)
        {
            DireccionEdicionProveedor FormularioDireccion = new DireccionEdicionProveedor();
            FormularioDireccion.ShowDialog();
        }
    }
}
