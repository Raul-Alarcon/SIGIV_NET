using SIGIV.CLS;
using SIGIV.GUI.Auth.Usuarios;
using SIGIV.GUI.Cargos;
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
    public partial class GestionEmpleados : Form
    {
        public GestionEmpleados()
        {
            InitializeComponent();
        }

        override async protected void OnLoad(EventArgs e)
        {
            try
            {
                await CargarEmpleados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private async Task CargarEmpleados()
        {
            dgvEmpleados.DataSource = await CLS.EmpleadoCLS.GetAllAsync();
        }

        private void btnAgregarCargo_Click(object sender, EventArgs e)
        {
            GestionCargo gestionCargo = new GestionCargo();
            gestionCargo.ShowDialog();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarEmpleado agregar = new AgregarEmpleado();
            var result = agregar.ShowDialog();
            if (result == DialogResult.OK)
            {
                await CargarEmpleados();
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEmpleados.SelectedRows.Count == 0)throw new ArgumentException("Debe seleccionar un empleado");
                var dto = (CLS.DTO.EmpleadoDTO)dgvEmpleados.CurrentRow.DataBoundItem;
                if (MessageBox.Show("¿Está seguro de eliminar el empleado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool success = await EmpleadoCLS.DeleteByIdAsync(dto.ID);
                    if (!success)throw new ArgumentException("Error al eliminar el empleado");
                    await CargarEmpleados();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEmpleados.SelectedRows.Count == 0) throw new ArgumentException("Debe seleccionar un empleado");
                var dto = (CLS.DTO.EmpleadoDTO)dgvEmpleados.CurrentRow.DataBoundItem;
                var empleado = await EmpleadoCLS.GetByIdAsync(dto.ID);
                AgregarEmpleado agregar = new AgregarEmpleado(empleado);
                var result = agregar.ShowDialog();
                if (result == DialogResult.OK)
                {
                    await CargarEmpleados();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                GestionUsuarios form;
                if (this.dgvEmpleados.SelectedRows.Count > 0)
                {
                    var dto = (CLS.DTO.EmpleadoDTO)dgvEmpleados.CurrentRow.DataBoundItem;
                    form = new GestionUsuarios(dto.ID); 
                }
                else
                {
                    form = new GestionUsuarios(); 
                } 
                form.ShowDialog();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
        }
    }
}
