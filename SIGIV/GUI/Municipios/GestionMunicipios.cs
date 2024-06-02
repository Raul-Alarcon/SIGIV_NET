using SIGIV.CLS;
using SIGIV.CLS.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGIV.GUI.Municipios
{
    public partial class GestionMunicipios : Form
    {
        public GestionMunicipios()
        {
            InitializeComponent();
        }

        protected async override void OnLoad(EventArgs e)
        {
            try
            {
                //await CargarDepartamentos();
                await CargarMuncipios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
            
        }

        //private async Task CargarDepartamentos()
        //{
        //    List<DepartamentosCLS> departamentos = await DepartamentosCLS.GetAllAsync();
        //    departamentos.Insert(0, new DepartamentosCLS { idDepartamento = 0, Departamento = "Seleccione un departamento" });
        //    cboDepartamento.DataSource = departamentos;
        //    cboDepartamento.DisplayMember = "Departamento";
        //    cboDepartamento.ValueMember = "idDepartamento";
        //}

        public async Task CargarMuncipios()
        {
            List<MunicipiosDTO> municipios = await MunicipiosCLS.GetAllAsync();
            this.dtgDatos.DataSource = municipios;
        }


    }
}
