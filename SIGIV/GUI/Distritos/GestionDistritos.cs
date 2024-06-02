using SIGIV.CLS;
using SIGIV.CLS.DTO;
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

namespace SIGIV.GUI.Distritos
{
    public partial class GestionDistritos : Form
    {
        private DistritosCLS distritoSeleccionado;
        public GestionDistritos()
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
                cbMunicipios.Enabled = true;
                btnEjecutar.Text = "Guardar";
            }
            else if (rbModificar.Checked)
            {
                txbNombre.Enabled = true;
                cbMunicipios.Enabled = true;
                btnEjecutar.Text = "Actualizar";
            }
            else if (rbEliminar.Checked)
            {
                txbNombre.Enabled = false;
                cbMunicipios.Enabled = false;
                btnEjecutar.Text = "Eliminar";
            }
            if (rbModificar.Checked || rbEliminar.Checked)
            {
                if (dtgDatos.SelectedRows.Count > 0)
                {
                    var distritoSeleccionadoDTO = (DistritosDTO)dtgDatos.CurrentRow.DataBoundItem;
                    distritoSeleccionado = await DistritosCLS.GetByIdAsync(distritoSeleccionadoDTO.ID);
                    txbNombre.Text = distritoSeleccionadoDTO.Distrito;
                    cbMunicipios.SelectedValue = distritoSeleccionado.idMunicipio;
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
                    var distritoSeleccionadoDTO = (DistritosDTO)dtgDatos.CurrentRow.DataBoundItem;
                    distritoSeleccionado = await  DistritosCLS.GetByIdAsync(distritoSeleccionadoDTO.ID);
                    txbNombre.Text = distritoSeleccionadoDTO.Distrito;
                    cbMunicipios.SelectedValue = distritoSeleccionado.idMunicipio;
                }
            }
        }

        override async protected void OnLoad(EventArgs e)
        {
            try
            {
                await CargarMunicipios();
                await Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private async Task CargarMunicipios()
        {
            List<MunicipiosDTO> municipios = await MunicipiosCLS.GetAllDTOAsync();
            municipios = municipios.Select(x => new MunicipiosDTO
            {
                id = x.id,
                Municipio = x.Municipio + " - " + x.Departamento + " - " + x.Pais
            }).ToList();
            cbMunicipios.DataSource = municipios;
            cbMunicipios.ValueMember = "ID";
            cbMunicipios.DisplayMember = "Municipio";
        }

        private async Task Cargar()
        {
            List<DistritosDTO> distritos = await DistritosCLS.GetAllDTOAsync();
            dtgDatos.DataSource = distritos;
        }

        private async Task Guardar()
        {
            bool success = false;
            DistritosCLS distrito = new DistritosCLS
            {
                nombre = txbNombre.Text,
                idMunicipio = Convert.ToInt32(cbMunicipios.SelectedValue)
            };
            distrito.validar();
            success = await distrito.SaveAsync();
            if (!success) throw new Exception("Error al guardar el distrito");
            MessageBox.Show("Distrito guardado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await Cargar();
            txbNombre.Text = string.Empty;
            rbNuevo.Checked = true;
        }

        private async Task Actualizar()
        {
            bool success = false;
            DistritosCLS distrito = new DistritosCLS
            {
                id = distritoSeleccionado.id,
                nombre = txbNombre.Text,
                idMunicipio = Convert.ToInt32(cbMunicipios.SelectedValue)
            };
            distrito.validar();
            success = await distrito.UpdateAsync();
            if (!success) throw new Exception("Error al actualizar el distrito");
            MessageBox.Show("Distrito actualizado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await Cargar();
            txbNombre.Text = string.Empty;
            rbNuevo.Checked = true;
        }

        private async Task Eliminar()
        {
            bool success = false;
            DistritosCLS distrito = new DistritosCLS
            {
                id = distritoSeleccionado.id
            };
            success = await distrito.DeleteAsync();
            if (!success) throw new Exception("Error al eliminar el distrito");
            MessageBox.Show("Distrito eliminado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                else if (rbModificar.Checked && distritoSeleccionado != null)
                {
                    await Actualizar();
                }
                else if (rbEliminar.Checked && distritoSeleccionado != null)
                {
                    await Eliminar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar la acción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
