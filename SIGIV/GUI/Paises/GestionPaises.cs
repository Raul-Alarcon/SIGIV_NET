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

namespace SIGIV.GUI.Paises
{
    public partial class GestionPaises : Form
    {
        private PaisesCLS paisSeleccionado;

        public GestionPaises()
        {
            InitializeComponent(); this.rbNuevo.CheckedChanged += rbOperaciones_CheckedChanged;
            this.rbEliminar.CheckedChanged += rbOperaciones_CheckedChanged;
            this.rbModificar.CheckedChanged += rbOperaciones_CheckedChanged;

            this.lstDatos.SelectedValueChanged += LbCargos_SelectedValueChanged; ;
        }

        private void LbCargos_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rbEliminar.Checked || this.rbModificar.Checked)
                {
                    paisSeleccionado = (PaisesCLS)this.lstDatos.SelectedItem;
                    this.txbNombre.Text = paisSeleccionado.nombre;
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbOperaciones_CheckedChanged(object sender, EventArgs e)
        {
            this.txbNombre.Enabled = true;
            if (this.rbEliminar.Checked) this.txbNombre.Enabled = false;

            if (this.rbEliminar.Checked || this.rbModificar.Checked)
            {
                if (this.lstDatos.Items.Count > 0)
                {
                    paisSeleccionado = (PaisesCLS)this.lstDatos.SelectedItem;
                    this.txbNombre.Text = paisSeleccionado.nombre;
                }
            }
            if (rbNuevo.Checked)
            {
                btnEjecutar.Text = "Guardar";
            }
            else if (rbModificar.Checked)
            {
                btnEjecutar.Text = "Actualizar";
            }
            else if (rbEliminar.Checked)
            {
                btnEjecutar.Text = "Eliminar";
            }

            if (this.rbNuevo.Checked) this.txbNombre.Text = string.Empty;
        }

        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                await CargarPais();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private async Task CargarPais()
        {
            List<PaisesCLS> listaPaises = await PaisesCLS.GetAllAsync();
            lstDatos.DataSource = listaPaises;
            lstDatos.DisplayMember = "nombre";
            lstDatos.ValueMember = "id";
        }

        private async Task Eliminar()
        {
            if (paisSeleccionado == null) throw new Exception("Debe seleccionar un Pais");

            if (MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool result = await paisSeleccionado.DeleteAsync();
                if (!result) throw new Exception("El registro no pudo ser eliminado");

                MessageBox.Show("Registro eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txbNombre.Text = string.Empty;
                this.paisSeleccionado = null;
                await CargarPais();
            }
        }

        private async Task Modificar()
        {
            if (paisSeleccionado == null) throw new Exception("Debe seleccionar un pais para modificar");

            PaisesCLS pais = new PaisesCLS();
            pais.id = paisSeleccionado.id;
            pais.nombre = this.txbNombre.Text;

            pais.Validar();
            bool result = await pais.UpdateAsync();
            if (!result) throw new Exception("El registro no pudo ser actualizado");

            MessageBox.Show("Registro actualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txbNombre.Text = string.Empty;
            await CargarPais();
        }

        private async Task Guardar()
        {
            PaisesCLS pais = new PaisesCLS();
            pais.nombre = this.txbNombre.Text;

            pais.Validar();
            bool result = await pais.SaveAsync();
            if (!result) throw new Exception("El registro no pudo ser guardado");

            MessageBox.Show("Registro guardado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txbNombre.Text = string.Empty;
            await CargarPais();
        }

        private async void btnEjecutar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rbNuevo.Checked) await Guardar();

                if (this.rbModificar.Checked) await Modificar();
                if (this.rbEliminar.Checked) await Eliminar();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ha ocurrido un error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
