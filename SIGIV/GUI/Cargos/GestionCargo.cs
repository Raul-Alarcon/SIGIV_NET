using SIGIV.CLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGIV.GUI.Cargos
{
    public partial class GestionCargo : Form
    {
        private CargosCLS cargoSeleccionado = null;
        public GestionCargo()
        {
            InitializeComponent();
            this.rbAgregar.CheckedChanged += rbOperaciones_CheckedChanged;
            this.rbElimiar.CheckedChanged += rbOperaciones_CheckedChanged;
            this.rbActualizar.CheckedChanged += rbOperaciones_CheckedChanged;

            this.lbCargos.SelectedValueChanged += LbCargos_SelectedValueChanged; ;
        }

        private void LbCargos_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rbElimiar.Checked || this.rbActualizar.Checked)
                {
                    cargoSeleccionado = (CargosCLS)this.lbCargos.SelectedItem;
                    this.txtCargo.Text = cargoSeleccionado.Nombre;
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbOperaciones_CheckedChanged(object sender, EventArgs e)
        {
            this.txtCargo.Enabled = true;
            if (this.rbElimiar.Checked) this.txtCargo.Enabled = false;

            if (this.rbElimiar.Checked || this.rbActualizar.Checked)
            {
                if (this.lbCargos.Items.Count > 0)
                {
                    cargoSeleccionado = (CargosCLS)this.lbCargos.SelectedItem;
                    this.txtCargo.Text = cargoSeleccionado.Nombre;
                }
            }

            if (this.rbAgregar.Checked) this.txtCargo.Text = string.Empty;
        }

        override async protected void OnLoad(EventArgs e)
        {
            try
            {
                await CargarCargos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los cargos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private async Task CargarCargos()
        {
            var cargos = await new CLS.CargosCLS().GetAllCargos();
            lbCargos.DataSource = cargos;
            lbCargos.DisplayMember = "Nombre";
            lbCargos.ValueMember = "Id";
            // para saber que item se selecciono el displaymember es pa mostrar y el valuemember es para saber que valor tiene
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rbAgregar.Checked) await Guardar();

                if (this.rbActualizar.Checked) await Modificar();
                if (this.rbElimiar.Checked) await Eliminar();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ha ocurrido un error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task Eliminar()
        {
            if (cargoSeleccionado == null) throw new Exception("Debe seleccionar un Cargo");

            if (MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool result = await cargoSeleccionado.DeleteAsync();
                if (!result) throw new Exception("El registro no pudo ser eliminado");

                MessageBox.Show("Registro eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtCargo.Text = string.Empty;
                this.cargoSeleccionado = null;
                await CargarCargos();
            }
        }

        private async Task Modificar()
        {
            if (cargoSeleccionado == null) throw new Exception("Debe seleccionar un cargo para modificar");

            CargosCLS cargo = new CargosCLS();
            cargo.Id = cargoSeleccionado.Id;
            cargo.Nombre = this.txtCargo.Text;

            cargo.validar();
            bool result = await cargo.UpdateAsync();
            if (!result) throw new Exception("El registro no pudo ser actualizado");

            MessageBox.Show("Registro actualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txtCargo.Text = string.Empty;
            await CargarCargos();
        }

        private async Task Guardar()
        {
            CargosCLS cargo = new CargosCLS();
            cargo.Nombre = this.txtCargo.Text;

            cargo.validar();
            bool result = await cargo.SaveAsync();
            if (!result) throw new Exception("El registro no pudo ser guardado");

            MessageBox.Show("Registro guardado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txtCargo.Text = string.Empty;
            await CargarCargos();
        }
    }
}
