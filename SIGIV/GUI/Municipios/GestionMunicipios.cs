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

namespace SIGIV.GUI.Municipios
{
    public partial class GestionMunicipios : Form
    {
        private MunicipiosCLS municipioSeleccionado;

        public GestionMunicipios()
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
                cbDepartamentos.Enabled = true;
                btnEjecutar.Text = "Guardar";
            }
            else if (rbModificar.Checked)
            {
                txbNombre.Enabled = true;
                cbDepartamentos.Enabled = true;
                btnEjecutar.Text = "Actualizar";
            }
            else if (rbEliminar.Checked)
            {
                txbNombre.Enabled = false;
                cbDepartamentos.Enabled = false;
                btnEjecutar.Text = "Eliminar";
            }
            if (rbModificar.Checked || rbEliminar.Checked)
            {
                if (dtgDatos.SelectedRows.Count > 0)
                {
                    var municipioSeleccionadoDTO = (MunicipiosDTO)dtgDatos.CurrentRow.DataBoundItem;
                    municipioSeleccionado = await MunicipiosCLS.GetByIdAsync(municipioSeleccionadoDTO.id);
                    txbNombre.Text = municipioSeleccionado.Municipio;
                    cbDepartamentos.SelectedValue = municipioSeleccionado.idDepartamento;
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
                    var municipioSeleccionadoDTO = (MunicipiosDTO)dtgDatos.CurrentRow.DataBoundItem;
                    municipioSeleccionado = await MunicipiosCLS.GetByIdAsync(municipioSeleccionadoDTO.id);
                    txbNombre.Text = municipioSeleccionadoDTO.Municipio;
                    cbDepartamentos.SelectedValue = municipioSeleccionado.idDepartamento;
                }
            }
        }

        protected async override void OnLoad(EventArgs e)
        {
            try
            {
                await CargarDepartamentos();
                await Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
            
        }

        private async Task Cargar()
        {
            List<MunicipiosDTO> municipios = await MunicipiosCLS.GetAllDTOAsync();
            dtgDatos.DataSource = municipios;   
        }

        private async Task CargarDepartamentos()
        {
            List<DepartamentoDTO> departamentos = await DepartamentosCLS.GetAllDTOAsync();
            departamentos = departamentos.Select(x => new DepartamentoDTO
            {
                ID = x.ID,
                Departamento = x.Departamento + " - " + x.Pais
            }).ToList();
            cbDepartamentos.DataSource = departamentos;
            cbDepartamentos.DisplayMember = "Departamento";
            cbDepartamentos.ValueMember = "ID";
        }

        private async Task Guardar()
        {
            bool success = false;
            MunicipiosCLS municipio = new MunicipiosCLS
            {
                Municipio = txbNombre.Text,
                idDepartamento = Convert.ToInt32(cbDepartamentos.SelectedValue)
            };
            municipio.Validar();
            success = await municipio.SaveAsync();
            if (!success) throw new Exception("Error al guardar el municipio");
            MessageBox.Show("Municipio guardado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await Cargar();
            txbNombre.Text = string.Empty;
            rbNuevo.Checked = true;
        }
        
        private async Task Actualizar()
        {
            bool success = false;
            MunicipiosCLS municipio = new MunicipiosCLS
            {
                id = municipioSeleccionado.id,
                Municipio = txbNombre.Text,
                idDepartamento = Convert.ToInt32(cbDepartamentos.SelectedValue)
            };
            municipio.Validar();
            success = await municipio.UpdateAsync();
            if (!success) throw new Exception("Error al actualizar el municipio");
            MessageBox.Show("Municipio actualizado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await Cargar();
            txbNombre.Text = string.Empty;
            rbNuevo.Checked = true;
        }

        private async Task Eliminar()
        {
            bool success = false;
            MunicipiosCLS municipio = new MunicipiosCLS
            {
                id = municipioSeleccionado.id
            };
            success = await municipio.DeleteAsync();
            if (!success) throw new Exception("Error al eliminar el municipio");
            MessageBox.Show("Municipio eliminado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                else if (rbModificar.Checked && municipioSeleccionado != null)
                {
                    await Actualizar();
                }
                else if (rbEliminar.Checked && municipioSeleccionado != null)
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
