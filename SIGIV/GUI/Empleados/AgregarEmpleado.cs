using SIGIV.CLS;
using SIGIV.DataLayer;
using SIGIV.GUI.Clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGIV.GUI.Empleados
{
    public partial class AgregarEmpleado : Form
    {
        private EmpleadoCLS empleado = null;
        public AgregarEmpleado(EmpleadoCLS empleado = null)
        {
            InitializeComponent();
            this.empleado = empleado;
        }

        override async protected void OnLoad(EventArgs e)
        {
            try
            {
                await CargarCargos();
                CargarDatosEmpleado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);

        }

        private void CargarDatosEmpleado()
        {
            if (empleado == null) return;
            this.txtNombre.Text = empleado.nombresEmpleado;
            this.txtApellidos.Text = empleado.apellidosEmpleado;
            this.dtpFechaNacimiento.Value = empleado.fechaNacimiento;
            this.txtDui.Text = empleado.dui;
            this.txtIsss.Text = empleado.ISSS;
            this.txtTelefono.Text = empleado.telefono;
            this.txtCorreo.Text = empleado.eMail;
            this.cmbCargos.SelectedValue = empleado.idCargo;
        }

        private async Task CargarCargos()
        {
            var cargos = await  CargosCLS.GetAllAsync();
            this.cmbCargos.DataSource = cargos;
            this.cmbCargos.DisplayMember = "Nombre";
            this.cmbCargos.ValueMember = "Id";
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (empleado == null) await Guardar();

                if (empleado != null) await Modificar();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ha ocurrido un error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task Modificar()
        {
            EmpleadoCLS empleado = new EmpleadoCLS
            {
                idEmpleado = this.empleado.idEmpleado,
                nombresEmpleado = this.txtNombre.Text,
                apellidosEmpleado = this.txtApellidos.Text,
                fechaNacimiento = this.dtpFechaNacimiento.Value,
                dui = this.txtDui.Text,
                ISSS = this.txtIsss.Text,
                telefono = this.txtTelefono.Text,
                eMail = this.txtCorreo.Text,
                idCargo = (int)this.cmbCargos.SelectedValue

            };
            empleado.validar();
            bool result = await empleado.UpdateAsync();
            if (!result) throw new Exception("El registro no pudo ser Actualizado");
            MessageBox.Show("Registro Actualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private async Task Guardar()
        {
            EmpleadoCLS empleado = new EmpleadoCLS
            {
                nombresEmpleado = this.txtNombre.Text,
                apellidosEmpleado = this.txtApellidos.Text,
                fechaNacimiento = this.dtpFechaNacimiento.Value,
                dui = this.txtDui.Text,
                ISSS = this.txtIsss.Text,
                telefono = this.txtTelefono.Text,
                eMail = this.txtCorreo.Text,
                idCargo = (int)this.cmbCargos.SelectedValue

            };
            empleado.validar();
            bool result = await empleado.AddAsync();
            if (!result) throw new Exception("El registro no pudo ser guardado");
            MessageBox.Show("Registro guardado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
