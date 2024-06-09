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

namespace SIGIV.GUI.FormasPago
{
    public partial class GestonFormasPago : Form
    {
        private FormasDePagoCLS FormasDePagoCLS;
        public GestonFormasPago()
        {
            InitializeComponent();
            this.rbAgregar.CheckedChanged += rbOperaciones_CheckedChanged;
            this.rbEliminar.CheckedChanged += rbOperaciones_CheckedChanged;
            this.rbActualizar.CheckedChanged += rbOperaciones_CheckedChanged;

            this.lbRFormas.SelectedValueChanged += LbCargos_SelectedValueChanged; ;
        }

        private void LbCargos_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rbEliminar.Checked || this.rbActualizar.Checked)
                {
                    FormasDePagoCLS = (FormasDePagoCLS)this.lbRFormas.SelectedItem;
                    this.txtforma.Text = FormasDePagoCLS.tipo;
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbOperaciones_CheckedChanged(object sender, EventArgs e)
        {
            this.txtforma.Enabled = true;
            if (this.rbEliminar.Checked) this.txtforma.Enabled = false;

            if (this.rbEliminar.Checked || this.rbActualizar.Checked)
            {
                if (this.lbRFormas.Items.Count > 0)
                {
                    FormasDePagoCLS = (FormasDePagoCLS)this.lbRFormas.SelectedItem;
                    this.txtforma.Text = FormasDePagoCLS.tipo;
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

            if (this.rbAgregar.Checked) this.txtforma.Text = string.Empty;
        }

        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                await CargarFormas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private async Task CargarFormas()
        {
            List<FormasDePagoCLS> listaPaises = await FormasDePagoCLS.GetAsync();
            lbRFormas.DataSource = listaPaises;
            lbRFormas.DisplayMember = "tipo";
            lbRFormas.ValueMember = "id";
        }

        private async Task Eliminar()
        {
            if (FormasDePagoCLS == null) throw new Exception("Debe seleccionar un Pais");

            if (MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool result = await FormasDePagoCLS.DeleteAsync();
                if (!result) throw new Exception("El registro no pudo ser eliminado");

                MessageBox.Show("Registro eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtforma.Text = string.Empty;
                this.FormasDePagoCLS = null;
                this.rbAgregar.Checked = true;
                await CargarFormas();
            }
        }

        private async Task Modificar()
        {
            if (FormasDePagoCLS == null) throw new Exception("Debe seleccionar un pais para modificar");

            FormasDePagoCLS forma = new FormasDePagoCLS();
            forma.id = FormasDePagoCLS.id;
            forma.tipo = this.txtforma.Text;

            forma.Validar();
            bool result = await forma.UpdateAsync();
            if (!result) throw new Exception("El registro no pudo ser actualizado");

            MessageBox.Show("Registro actualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txtforma.Text = string.Empty;
            this.rbAgregar.Checked = true;
            await CargarFormas();
        }

        private async Task Guardar()
        {
            FormasDePagoCLS forma = new FormasDePagoCLS();
            forma.tipo = this.txtforma.Text;

            forma.Validar();
            bool result = await forma.SaveAsync();
            if (!result) throw new Exception("El registro no pudo ser guardado");

            MessageBox.Show("Registro guardado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txtforma.Text = string.Empty;
            await CargarFormas();
        }

        private async void btnEjecutar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rbAgregar.Checked) await Guardar();

                if (this.rbActualizar.Checked) await Modificar();
                if (this.rbEliminar.Checked) await Eliminar();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ha ocurrido un error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
