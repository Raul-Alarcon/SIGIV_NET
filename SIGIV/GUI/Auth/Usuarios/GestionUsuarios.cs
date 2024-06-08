using SIGIV.CLS;
using SIGIV.CLS.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGIV.GUI.Auth.Usuarios
{
    public partial class GestionUsuarios : Form
    {
        private int idEmpleado;
        private UsuarioCLS usuario = new UsuarioCLS();
        public GestionUsuarios(int idEmpleado = 0)
        {
            InitializeComponent();
            this.idEmpleado = idEmpleado;
            this.rbnModificarPassword.Enabled = false;
            this.cmbEmpleados.SelectedValueChanged += CmbEmpleados_SelectedValueChanged;
            rbnModificarPassword.CheckedChanged += RbnModificarPassword_CheckedChanged;
        }

        private void RbnModificarPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbnModificarPassword.Checked)
            {
                this.txbPassword.Enabled = true;
            }
            else
            {
                this.txbPassword.Enabled = false;
            }
        }

        private async void CmbEmpleados_SelectedValueChanged(object sender, EventArgs e)
        {
            if(this.cmbEmpleados.SelectedValue is int id)
            {
                this.rbnModificarPassword.Enabled = false;
                this.txbPassword.Enabled = true;
                this.txbUsuario.Text = string.Empty;

                this.usuario = await UsuarioCLS.GetByIdEmpleadoAsync(id);
                if (this.usuario != null && this.usuario.id > 0)
                { 
                    txbUsuario.Text = this.usuario.usuario;
                    //txbPassword.Text = usuario.clave;
                    this.rbnModificarPassword.Enabled = true;
                    this.cmbRoles.SelectedValue = this.usuario.idRol;
                    this.txbPassword.Enabled = false;
                }
            }
        }

        protected override async void OnLoad(EventArgs e)
        {
            try
            {
               await CargarEmpleados();
                await CargarRoles();
                if(this.idEmpleado > 0)
                {
                   this.cmbEmpleados.Enabled = false;
                   this.cmbEmpleados.SelectedValue = this.idEmpleado;
                    this.txbUsuario.Text = string.Empty;

                    this.usuario = await UsuarioCLS.GetByIdEmpleadoAsync(this.idEmpleado);   
                   if(this.usuario != null && this.usuario.id > 0 ) {                         
                        cmbEmpleados.SelectedValue = this.usuario.idEmpleado;
                        txbUsuario.Text = this.usuario.usuario;
                        //txbPassword.Text = usuario.clave;
                        this.rbnModificarPassword.Enabled = true;
                        this.cmbRoles.SelectedValue = this.usuario.idRol;
                        this.txbPassword.Enabled = false;
                   }   
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error al cargar la vista: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e); 
        }

        private async Task CargarRoles()
        {
            var roles = await RolCLS.GetAsync();
            cmbRoles.DataSource = roles;
            cmbRoles.DisplayMember = "nombre";
            cmbRoles.ValueMember = "id";
        }

        private async Task CargarEmpleados()
        {
            var empleados = await EmpleadoCLS.GetAllAsync(); 
            cmbEmpleados.DataSource = empleados;
            cmbEmpleados.DisplayMember = "Nombres";
            cmbEmpleados.ValueMember = "ID";
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.usuario.id <= 0) await Guardar();
                if (this.usuario.id > 0) await Actualizar();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error al guardar el usuario: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task Actualizar()
        {
            UsuarioCLS usuario = new UsuarioCLS
            {
                id = this.usuario.id,
                idEmpleado = (int)cmbEmpleados.SelectedValue,
                idRol = (int)cmbRoles.SelectedValue,
                usuario = txbUsuario.Text,
                clave = txbPassword.Text
            };

            var _usuario = await usuario.UpdateAsync();
            if(!_usuario)  throw new ArgumentException("Error al actualizar el usuario");
            MessageBox.Show("Usuario actualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private async Task Guardar()
        {

            UsuarioCLS usuario = new UsuarioCLS
            {
                idEmpleado = (int)cmbEmpleados.SelectedValue,
                idRol = (int)cmbRoles.SelectedValue,
                usuario = txbUsuario.Text,
                clave = txbPassword.Text
            };

            var _usuario = await usuario.SaveAsync();
            if(_usuario.id <= 0)  throw new ArgumentException("Error al guardar el usuario");
            MessageBox.Show("Usuario guardado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
