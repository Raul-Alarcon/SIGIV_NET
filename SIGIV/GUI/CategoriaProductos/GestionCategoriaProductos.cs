using SIGIV.CLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGIV.GUI.CategoriaProductos
{
    public partial class GestionCategoriaProductos : Form
    {
        private CategoriaProuctoCLS categoriaSeleccionada;
        public GestionCategoriaProductos()
        {
            InitializeComponent();
            dgvCategorias.SelectionChanged += DgvCategorias_SelectionChanged;
            rbEliminar.CheckedChanged += RbOperacion_CheckedChanged;
            rbModificar.CheckedChanged += RbOperacion_CheckedChanged;
            rbNuevo.CheckedChanged += RbOperacion_CheckedChanged;
        }

        private void RbOperacion_CheckedChanged(object sender, EventArgs e)
        {
            txbNombre.Text = string.Empty;
            txbDetalles.Text = string.Empty;
            if (rbNuevo.Checked)
            {
                txbNombre.Enabled = true;
                txbDetalles.Enabled = true;
                btnEjecutar.Text = "Guardar";
            }
            else if (rbModificar.Checked)
            {
                txbNombre.Enabled = true;
                txbDetalles.Enabled = true;
                btnEjecutar.Text = "Actualizar";
            }
            else if (rbEliminar.Checked)
            {
                txbNombre.Enabled = false;
                txbDetalles.Enabled = false;
                btnEjecutar.Text = "Eliminar";
            }
            if (rbModificar.Checked || rbEliminar.Checked)
            {
                if (dgvCategorias.SelectedRows.Count > 0)
                {
                    categoriaSeleccionada = (CategoriaProuctoCLS)dgvCategorias.CurrentRow.DataBoundItem;
                    txbNombre.Text = categoriaSeleccionada.Nombre;
                    txbDetalles.Text = categoriaSeleccionada.detalles;
                }
            }
        }

        private void DgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            txbNombre.Text = string.Empty;
            txbDetalles.Text = string.Empty;
            if (rbModificar.Checked || rbEliminar.Checked)
            {
                if (dgvCategorias.SelectedRows.Count > 0)
                {
                    categoriaSeleccionada = (CategoriaProuctoCLS)dgvCategorias.CurrentRow.DataBoundItem;
                    txbNombre.Text = categoriaSeleccionada.Nombre;
                    txbDetalles.Text = categoriaSeleccionada.detalles;
                }
            }
        }

        override protected async void OnLoad(EventArgs e)
        {
            try
            {
                await CargarCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las categorias: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e); 
        }

        private async Task CargarCategorias()
        {
            List<CategoriaProuctoCLS> categorias = await CategoriaProuctoCLS.GetAllAsync();
            dgvCategorias.DataSource = categorias;
        }

        private async Task Guardar()
        {
            bool success = false;
            CategoriaProuctoCLS categoriaProuctoCLS = new CategoriaProuctoCLS
            {
                Nombre = txbNombre.Text,
                detalles = txbDetalles.Text
            };
            categoriaProuctoCLS.validar();
            success = await categoriaProuctoCLS.SaveAsync();
            if(!success) throw new Exception ("Error al guardar la categoria");
            MessageBox.Show("Categoria guardada correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await CargarCategorias();
            txbNombre.Text = string.Empty;
            txbDetalles.Text = string.Empty;
        }

        private async Task Actualizar()
        {
            bool success = false;
            CategoriaProuctoCLS categoriaProuctoCLS = new CategoriaProuctoCLS
            {
                Id = categoriaSeleccionada.Id,
                Nombre = txbNombre.Text,
                detalles = txbDetalles.Text
            };
            categoriaProuctoCLS.validar();
            success = await categoriaProuctoCLS.UpdateAsync();
            if(!success) throw new Exception ("Error al actualizar la categoria");
            MessageBox.Show("Categoria actualizada correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await CargarCategorias();
            txbNombre.Text = string.Empty;
            txbDetalles.Text = string.Empty;
            rbNuevo.Checked = true;
        }

        private async Task Eliminar()
        {
            bool success = false;
            CategoriaProuctoCLS categoriaProuctoCLS = new CategoriaProuctoCLS
            {
                Id = categoriaSeleccionada.Id
            };
            success = await categoriaProuctoCLS.DeleteAsync();
            if(!success) throw new Exception ("Error al eliminar la categoria");
            MessageBox.Show("Categoria eliminada correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await CargarCategorias();
            txbNombre.Text = string.Empty;
            txbDetalles.Text = string.Empty;
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
                else if (rbModificar.Checked && categoriaSeleccionada!=null)
                {
                    await Actualizar();
                }
                else if (rbEliminar.Checked && categoriaSeleccionada != null)
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
