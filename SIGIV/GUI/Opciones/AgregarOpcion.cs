using SIGIV.CLS;
using SIGIV.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGIV.GUI.Opciones
{
    public partial class AgregarOpcion : Form
    {
        private OpcionCLS opcionSeleccionada = null;
        public AgregarOpcion()
        {
            InitializeComponent();
            this.rbAgregar.CheckedChanged += rbOperaciones_CheckedChanged;
            this.rbActualizar.CheckedChanged += rbOperaciones_CheckedChanged;
            this.rbEliminar.CheckedChanged += rbOperaciones_CheckedChanged;

            this.lbOpciones.SelectedValueChanged += LbCargos_SelectedValueChanged; ;

        }

        private void LbCargos_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rbActualizar.Checked || this.rbEliminar.Checked)
                {
                    opcionSeleccionada = (OpcionCLS)this.lbOpciones.SelectedItem;
                    this.txtOpciones.Text = opcionSeleccionada.opcion;
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbOperaciones_CheckedChanged(object sender, EventArgs e)
        {
            this.txtOpciones.Enabled = true;
            if (this.rbEliminar.Checked) this.txtOpciones.Enabled = false;

            if (this.rbEliminar.Checked || this.rbActualizar.Checked)
            {
                if (this.lbOpciones.Items.Count > 0)
                {
                    opcionSeleccionada = (OpcionCLS)this.lbOpciones.SelectedItem;
                    this.txtOpciones.Text = opcionSeleccionada.opcion;
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
            else if (rbEliminar.Checked)
            {
                btnAceptar.Text = "Eliminar";
            }

            if (this.rbAgregar.Checked) this.txtOpciones.Text = string.Empty;
        }

        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                await CargarOpciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarOpciones()
        {
            List<OpcionCLS> listaOpciones = await OpcionCLS.GetALLAsync();
            lbOpciones.DataSource = listaOpciones;
            lbOpciones.DisplayMember = "opcion";
            lbOpciones.ValueMember = "id";
        }

        private async Task Eliminar()
        {
            if (opcionSeleccionada == null) throw new Exception("Debe seleccionar una Opcion");

            if (MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool result = await opcionSeleccionada.DeleteAsync();
                if (!result) throw new Exception("El registro no pudo ser eliminado");

                MessageBox.Show("Registro eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtOpciones.Text = string.Empty;
                this.opcionSeleccionada = null;
                await CargarOpciones();
            }
        }

        private async Task Modificar()
        {
            if (opcionSeleccionada == null) throw new Exception("Debe seleccionar una Opcion para modificar");

            OpcionCLS opcion = new OpcionCLS();
            opcion.id = opcionSeleccionada.id;
            opcion.opcion = this.txtOpciones.Text;

            opcion.Validar();
            bool result = await opcion.UpdateAsync();
            if (!result) throw new Exception("El registro no pudo ser actualizado");

            MessageBox.Show("Registro actualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txtOpciones.Text = string.Empty;
            this.rbAgregar.Checked = true;
            await CargarOpciones();
        }

        private async Task Guardar()
        {
            OpcionCLS opcion = new OpcionCLS();
            opcion.opcion = this.txtOpciones.Text;

            opcion.Validar();
            bool result = await opcion.SaveAsync();
            if (!result) throw new Exception("El registro no pudo ser guardado");

            MessageBox.Show("Registro guardado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txtOpciones.Text = string.Empty;
            await CargarOpciones();
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rbAgregar.Checked) await Guardar();

                if (this.rbActualizar.Checked) await Modificar();

                if (this.rbEliminar.Checked) await Eliminar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
