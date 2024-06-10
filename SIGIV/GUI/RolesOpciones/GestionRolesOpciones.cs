using SIGIV.CLS;
using SIGIV.CLS.Auth;
using SIGIV.CLS.DTO;
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
        private List<RolCLS> roles = new List<RolCLS>();
        private List<OpcionCLS> opciones = new List<OpcionCLS>();
        private List<UsuarioDTO> usuarios = new List<UsuarioDTO>();
        private List<OpcionCLS> opcionesSeleccionadas = new List<OpcionCLS>();

        public GestionRolesOpciones()
        {
            InitializeComponent();
            this.cmbUsuarios.SelectedValueChanged += CmbUsuarios_SelectedValueChanged;
        }

        private async void CmbUsuarios_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //if (cmbUsuarios.SelectedValue != null)
                //{
                //    int idUsuario = (int)cmbUsuarios.SelectedValue;
                //    UsuarioDTO usuario = usuarios.Where(usu => usu.id == idUsuario).FirstOrDefault();
                //    if (usuario != null)
                //    {
                //        int idRol = usuario.idRol;
                //        cmbRoles.SelectedValue = idRol;
                //        opcionesSeleccionadas = await OpcionCLS.GetOpcionesByRol(idRol);

                //        this.listOpcionesSeleccionadas.DataSource = null;
                //        this.listOpcionesSeleccionadas.DataSource = opciones;
                //        this.listOpcionesSeleccionadas.DisplayMember = "opcion";
                //        this.listOpcionesSeleccionadas.ValueMember = "id";

                //    }
                //}
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: No se pudo cargar la información de los roles y opciones. " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                await CargarOpciones();
                await CargarRoles();
                await CargarUsuarios();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: No se pudo cargar la información de los roles y opciones. " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private async Task CargarUsuarios()
        {
            var usuarios = await UsuarioCLS.GetUsuarioDTOsAsync();
            this.usuarios = usuarios;
            usuarios = usuarios.Select( usu => new CLS.DTO.UsuarioDTO
            {
                id = usu.id,
                usuario = usu.usuario +" --- "+ usu.Empleado,
            }).ToList();

            cmbUsuarios.DataSource = usuarios;
            cmbUsuarios.DisplayMember = "usuario";
            cmbUsuarios.ValueMember = "id";
        }

        private async Task CargarRoles()
        {
            this.roles = await RolCLS.GetAsync();
            cmbRoles.DataSource = roles;
            cmbRoles.DisplayMember = "nombre";
            cmbRoles.ValueMember = "id";
        }

        private async Task CargarOpciones()
        {
            this.opciones = await OpcionCLS.GetALLAsync();
            listOpciones.DataSource = opciones;
            listOpciones.DisplayMember = "opcion";
            listOpciones.ValueMember = "id";
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

        private async void btnRecargar_Click(object sender, EventArgs e)
        {
            try
            {
                await CargarOpciones();
                await CargarRoles();
                await CargarUsuarios();
            }
            catch (Exception  exc)
            {
                MessageBox.Show("Error: No se pudo recargar la información de los roles y opciones. " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
