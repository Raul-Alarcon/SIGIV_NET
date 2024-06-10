using SIGIV.GUI.CategoriaProductos;
using SIGIV.GUI.Departamentos;
using SIGIV.GUI.Distritos;
using SIGIV.GUI.Municipios;
using SIGIV.GUI.Paises;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGIV.GUI.View
{
    public partial class Configuraciones : Form
    {
        public Configuraciones()
        {
            InitializeComponent();
        }

        private void btnPaises_Click(object sender, EventArgs e)
        {
            GestionPaises paises = new GestionPaises();
            paises.ShowDialog();
        }

        private void btnDeptos_Click(object sender, EventArgs e)
        {
            GestionDepartamentos gestionDepartamentos = new GestionDepartamentos();
            gestionDepartamentos.ShowDialog();
        }

        private void btnMunicipios_Click(object sender, EventArgs e)
        {
            GestionMunicipios gestionMunicipios = new GestionMunicipios();
            gestionMunicipios.ShowDialog();
        }

        private void btnDistritos_Click(object sender, EventArgs e)
        {
            GestionDistritos distritos = new GestionDistritos();
            distritos.ShowDialog();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            GestionCategoriaProductos gestionCategoriaProductos = new GestionCategoriaProductos();
            gestionCategoriaProductos.ShowDialog();
        }
    }
}
