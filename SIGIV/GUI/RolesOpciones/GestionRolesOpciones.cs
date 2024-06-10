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
                if (cmbUsuarios.SelectedValue != null)
                {

                    if (cmbUsuarios.SelectedValue is int idUsuario)
                    {
                        UsuarioDTO usuario = usuarios.Where(usu => usu.id == idUsuario).FirstOrDefault();
                        if (usuario != null)
                        {
                            int idRol = usuario.idRol;
                            cmbRoles.SelectedValue = idRol;
                            opcionesSeleccionadas = await OpcionCLS.GetOpcionesAsignadasByRol(idRol);

                            this.listOpcionesSeleccionadas.DataSource = null;
                            this.listOpcionesSeleccionadas.DataSource = opcionesSeleccionadas;
                            this.listOpcionesSeleccionadas.DisplayMember = "opcion";
                            this.listOpcionesSeleccionadas.ValueMember = "id";

                        }
                    } 
                    
                }
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

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listOpciones.SelectedValue == null) throw new Exception("Error: No se ha seleccionado ninguna opción.");
                

                OpcionCLS opcion = opciones.Where(opc => opc.id == (int)listOpciones.SelectedValue).FirstOrDefault();
                if (opcion == null) throw new Exception("Error: No se ha encontrado la opción seleccionada.");
                if(opcionesSeleccionadas.Exists(op => op.id == opcion.id)) throw new Exception("Error: La opción seleccionada ya ha sido agregada.");

                if(cmbRoles.SelectedValue == null) throw new Exception( "Error: No se ha seleccionado ningún rol.");       
                if(cmbRoles.SelectedValue is int idRol)
                {
                    bool success = await opcion.AsignarARol(idRol);
                    if (!success) throw new Exception("Error: No se pudo asignar la opción al rol.");
                    opcionesSeleccionadas.Add(opcion);

                    this.listOpcionesSeleccionadas.DataSource = null;
                    this.listOpcionesSeleccionadas.DataSource = opcionesSeleccionadas;
                    this.listOpcionesSeleccionadas.DisplayMember = "opcion";
                    this.listOpcionesSeleccionadas.ValueMember = "id";
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: No se pudo guardar la información de los roles y opciones. " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listOpcionesSeleccionadas.SelectedValue == null) throw new Exception("Error: No se ha seleccionado ninguna opción.");


                OpcionCLS opcion = opcionesSeleccionadas.Where(opc => opc.id == (int)listOpcionesSeleccionadas.SelectedValue).FirstOrDefault();
                if (opcion == null) throw new Exception("Error: No se ha encontrado la opción seleccionada."); 

                if (cmbRoles.SelectedValue == null) throw new Exception("Error: No se ha seleccionado ningún rol.");
                if (cmbRoles.SelectedValue is int idRol)
                {
                    bool success = await opcion.QuitarOpcionAsignadoByIdRol(idRol);
                    if (!success) throw new Exception("Error: No se pudo quitar la opción al rol.");
                    opcionesSeleccionadas.Remove(opcion);

                    this.listOpcionesSeleccionadas.DataSource = null;
                    this.listOpcionesSeleccionadas.DataSource = opcionesSeleccionadas;
                    this.listOpcionesSeleccionadas.DisplayMember = "opcion";
                    this.listOpcionesSeleccionadas.ValueMember = "id";

                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: No se pudo guardar la información de los roles y opciones. " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAsignarRolUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if(cmbRoles.SelectedValue == null) throw new Exception("Error: No se ha seleccionado ningún rol.");
                if(cmbUsuarios.SelectedValue ==  null) throw new Exception("Error: No se ha seleccionado ningún usuario.");
                if (cmbRoles.SelectedValue is int idRol)
                {
                    RolCLS rol = this.roles.Find(_rol => _rol.id == idRol);
                    if (cmbUsuarios.SelectedValue is int idUsuario)
                    {
                       bool success = await rol.AsignaUsuario(idUsuario);
                       if (!success) throw new Exception("Error: No se pudo asignar el rol al usuario.");
                        await CargarUsuarios();
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: No se pudo guardar la información de los roles y opciones. " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
