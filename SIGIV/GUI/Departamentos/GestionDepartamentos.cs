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

namespace SIGIV.GUI.Departamentos
{
    public partial class GestionDepartamentos : Form
    {
        private DepartamentosCLS departamentoSeleccionada;

        public GestionDepartamentos()
        {
            InitializeComponent();
            dtgDatos.SelectionChanged += DgvCategorias_SelectionChanged;
            rbEliminar.CheckedChanged += RbOperacion_CheckedChanged;
            rbModificar.CheckedChanged += RbOperacion_CheckedChanged;
            rbNuevo.CheckedChanged += RbOperacion_CheckedChanged;
        }

        private async void RbOperacion_CheckedChanged(object sender, EventArgs e)
        {
            txbNombre.Text = string.Empty;
            if (rbNuevo.Checked)
            {
                txbNombre.Enabled = true;
                cbPaises.Enabled = true;
                btnEjecutar.Text = "Guardar";
            }
            else if (rbModificar.Checked)
            {
                txbNombre.Enabled = true;
                cbPaises.Enabled = true;
                btnEjecutar.Text = "Actualizar";
            }
            else if (rbEliminar.Checked)
            {
                txbNombre.Enabled = false;
                cbPaises.Enabled = false;
                btnEjecutar.Text = "Eliminar";
            }
            if (rbModificar.Checked || rbEliminar.Checked)
            {
                if (dtgDatos.SelectedRows.Count > 0)
                {
                    var dto = (DepartamentoDTO)dtgDatos.CurrentRow.DataBoundItem;
                    departamentoSeleccionada = await DepartamentosCLS.GetByIdAsync(dto.ID);
                    txbNombre.Text = departamentoSeleccionada.nombre;
                    cbPaises.SelectedValue = departamentoSeleccionada.idPais;
                }
            }
        }

        private async void DgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            txbNombre.Text = string.Empty;
            if (rbModificar.Checked || rbEliminar.Checked)
            {
                if (dtgDatos.SelectedRows.Count > 0)
                {
                    var dto = (DepartamentoDTO)dtgDatos.CurrentRow.DataBoundItem;
                    departamentoSeleccionada = await DepartamentosCLS.GetByIdAsync(dto.ID);
                    txbNombre.Text = departamentoSeleccionada.nombre;
                    cbPaises.SelectedValue = departamentoSeleccionada.idPais;
                }
            }
        }

        override protected async void OnLoad(EventArgs e)
        {
            try
            {
                await CargarPaises();
                await Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los Paises: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private async Task CargarPaises()
        {
            List<PaisesCLS> paises = await PaisesCLS.GetAllAsync();
            cbPaises.DataSource = paises;
            cbPaises.DisplayMember = "nombre";
            cbPaises.ValueMember = "id";
        }

        private async Task Cargar()
        {
            List<DepartamentoDTO> departamentos = await DepartamentosCLS.GetAllDTOAsync();
            dtgDatos.DataSource = departamentos;
        }

        private async Task Guardar()
        {
            bool success = false;
            DepartamentosCLS DepartamentosCLS = new DepartamentosCLS
            {
                nombre = txbNombre.Text,
                idPais = Convert.ToInt32(cbPaises.SelectedValue)
            };
            DepartamentosCLS.validar();
            success = await DepartamentosCLS.SaveAsync();
            if (!success) throw new Exception("Error al guardar el departamento");
            MessageBox.Show("Departamento guardado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await Cargar();
            txbNombre.Text = string.Empty;
            rbNuevo.Checked = true;
        }

        private async Task Actualizar()
        {
            bool success = false;
            DepartamentosCLS DepartamentosCLS = new DepartamentosCLS
            {
                id = departamentoSeleccionada.id,
                nombre = txbNombre.Text,
                idPais = Convert.ToInt32(cbPaises.SelectedValue)
            };
            DepartamentosCLS.validar();
            success = await DepartamentosCLS.UpdateAsync();
            if (!success) throw new Exception("Error al actualizar el departamento");
            MessageBox.Show("Departamento actualizada correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await Cargar();
            txbNombre.Text = string.Empty;
            rbNuevo.Checked = true;
        }

        private async Task Eliminar()
        {
            bool success = false;
            DepartamentosCLS DepartamentosCLS = new DepartamentosCLS
            {
                id = departamentoSeleccionada.id
            };
            success = await DepartamentosCLS.DeleteAsync();
            if (!success) throw new Exception("Error al eliminar el departamento");
            MessageBox.Show("Departamento eliminada correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await Cargar();
            txbNombre.Text = string.Empty;
            rbNuevo.Checked = true;
        }

        private async void btnEjecutar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbNuevo.Checked)
                {
                    await Guardar();
                }
                else if (rbModificar.Checked && departamentoSeleccionada != null)
                {
                    await Actualizar();
                }
                else if (rbEliminar.Checked && departamentoSeleccionada != null)
                {
                    await Eliminar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
