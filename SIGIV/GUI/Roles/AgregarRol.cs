using SIGIV.CLS;
using SIGIV.CLS.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGIV.GUI.Roles
{
    public partial class AgregarRol : Form
    {
        private RolCLS rolSeleccionado = null;
        public AgregarRol()
        {
            InitializeComponent();
            this.rbAgregar.CheckedChanged += rbOperaciones_CheckedChanged; 
            this.rbActualizar.CheckedChanged += rbOperaciones_CheckedChanged;

            this.lbRoles.SelectedValueChanged += LbCargos_SelectedValueChanged; ;
        }

        private void LbCargos_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ( this.rbActualizar.Checked)
                {
                    rolSeleccionado = (RolCLS)this.lbRoles.SelectedItem;
                    this.txtRoles.Text = rolSeleccionado.nombre;
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbOperaciones_CheckedChanged(object sender, EventArgs e)
        {
            this.txtRoles.Enabled = true; 
            if (this.rbActualizar.Checked)
            {
                if (this.lbRoles.Items.Count > 0)
                {
                    rolSeleccionado = (RolCLS)this.lbRoles.SelectedItem;
                    this.txtRoles.Text = rolSeleccionado.nombre;
                }
            }
            if (rbAgregar.Checked)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (rbActualizar.Checked)
            {
                btnAceptar.Text = "Actualizar";
            } 

            if (this.rbAgregar.Checked) this.txtRoles.Text = string.Empty;
        }

        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                await CargarRoles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private async Task CargarRoles()
        {
            List<RolCLS> listaPaises = await RolCLS.GetAsync();
            lbRoles.DataSource = listaPaises;
            lbRoles.DisplayMember = "nombre";
            lbRoles.ValueMember = "id";
        }
         
        private async Task Modificar()
        {
            if (rolSeleccionado == null) throw new Exception("Debe seleccionar un pais para modificar");

            RolCLS rol = new RolCLS();
            rol.id = rolSeleccionado.id;
            rol.nombre = this.txtRoles.Text;

            rol.Validar();
            bool result = await rol.UpdateAsync();
            if (!result) throw new Exception("El registro no pudo ser actualizado");

            MessageBox.Show("Registro actualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txtRoles.Text = string.Empty;
            this.rbAgregar.Checked = true;
            await CargarRoles();
        }

        private async Task Guardar()
        {
            RolCLS rol = new RolCLS();
            rol.nombre = this.txtRoles.Text;

            rol.Validar();
            bool result = await rol.SaveAsync();
            if (!result) throw new Exception("El registro no pudo ser guardado");

            MessageBox.Show("Registro guardado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txtRoles.Text = string.Empty;
            this.rbAgregar.Checked = true; 
            await CargarRoles();
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rbAgregar.Checked) await Guardar();

                if (this.rbActualizar.Checked) await Modificar(); 
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ha ocurrido un error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
