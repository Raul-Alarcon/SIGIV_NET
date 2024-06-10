using SIGIV.GUI.Opciones;
using SIGIV.GUI.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGIV.GUI.RolesOpciones
{
    public partial class GestionRolesOpciones : Form
    {
        public GestionRolesOpciones()
        {
            InitializeComponent();
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            AgregarUsuarios agregarUsuarios = new AgregarUsuarios();
            agregarUsuarios.ShowDialog();
        }

        private void btnAgregarOpciones_Click(object sender, EventArgs e)
        {
            AgregarOpcion agregarOpcion = new AgregarOpcion();
            agregarOpcion.ShowDialog();
        }
    }
}
