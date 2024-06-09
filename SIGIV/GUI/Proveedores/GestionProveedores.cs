using SIGIV.CLS;
using SIGIV.CLS.DTO;
using SIGIV.GUI.Pedidos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGIV.GUI.Proveedores
{
    public partial class GestionProveedores : Form
    {
        private ProveedorCLS proveedorSeleccionado;
        public GestionProveedores()
        {
            InitializeComponent();
            dtgDatos.SelectionChanged += DgvProveedores_SelectionChanged;
            rbnEliminar.CheckedChanged += RbOperacion_CheckedChanged;
            rbnModificar.CheckedChanged += RbOperacion_CheckedChanged;
            rbnNuevo.CheckedChanged += RbOperacion_CheckedChanged;
        }

        private async void RbOperacion_CheckedChanged(object sender, EventArgs e)
        {
            txbCompania.Text = string.Empty;
            txbNIT.Text = string.Empty;
            txbTelefono.Text = string.Empty;
            txbCorreo.Text = string.Empty;
            txbWeb.Text = string.Empty;
            txbGiro.Text = string.Empty;
            if (rbnNuevo.Checked)
            {
                txbCompania.Enabled = true;
                txbNIT.Enabled = true;
                txbTelefono.Enabled = true;
                txbCorreo.Enabled = true;
                txbWeb.Enabled = true;
                txbGiro.Enabled = true;
                btnGuardar.Text = "Guardar";
            }
            else if (rbnModificar.Checked)
            {
                txbCompania.Enabled = true;
                txbNIT.Enabled = true;
                txbTelefono.Enabled = true;
                txbCorreo.Enabled = true;
                txbWeb.Enabled = true;
                txbGiro.Enabled = true;
                btnGuardar.Text = "Actualizar";
            }
            else if (rbnEliminar.Checked)
            {
                txbCompania.Enabled = false;
                txbNIT.Enabled = false;
                txbTelefono.Enabled = false;
                txbCorreo.Enabled = false;
                txbWeb.Enabled = false;
                txbGiro.Enabled = false;
                btnGuardar.Text = "Eliminar";
            }
            if (rbnModificar.Checked || rbnEliminar.Checked)
            {
                if (dtgDatos.SelectedRows.Count > 0)
                {
                    var dto = (ProveedorDTO)dtgDatos.CurrentRow.DataBoundItem;
                    proveedorSeleccionado = await ProveedorCLS.GetByIDAsync(dto.ID);
                    txbCompania.Text = proveedorSeleccionado.compania;
                    txbNIT.Text = proveedorSeleccionado.nit;
                    txbTelefono.Text = proveedorSeleccionado.telefono;
                    txbCorreo.Text = proveedorSeleccionado.correo;
                    txbWeb.Text = proveedorSeleccionado.web;
                    txbGiro.Text = proveedorSeleccionado.giro;
                }
            }
        }

        private async void DgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            txbCompania.Text = string.Empty;
            txbNIT.Text = string.Empty;
            txbTelefono.Text = string.Empty;
            txbCorreo.Text = string.Empty;
            txbWeb.Text = string.Empty;
            txbGiro.Text = string.Empty;
            if (rbnModificar.Checked || rbnEliminar.Checked)
            {
                if (dtgDatos.SelectedRows.Count > 0)
                {
                    var dto = (ProveedorDTO)dtgDatos.CurrentRow.DataBoundItem;
                    proveedorSeleccionado = await ProveedorCLS.GetByIDAsync(dto.ID);
                    txbCompania.Text = proveedorSeleccionado.compania;
                    txbNIT.Text = proveedorSeleccionado.nit;
                    txbTelefono.Text = proveedorSeleccionado.telefono;
                    txbCorreo.Text = proveedorSeleccionado.correo;
                    txbWeb.Text = proveedorSeleccionado.web;
                    txbGiro.Text = proveedorSeleccionado.giro;
                }
            }
        }

        protected async override void OnLoad(EventArgs e)
        {
            try
            {
                await CargarProveedores();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private async Task CargarProveedores()
        {
            List<ProveedorDTO> proveedores = await ProveedorCLS.GetAllDTOAsync();
            dtgDatos.DataSource = proveedores;
        }

        private async Task Guardar()
        {
            bool success = false;
            ProveedorCLS proveedor = new ProveedorCLS
            {
                compania = txbCompania.Text,
                nit = txbNIT.Text,
                telefono = txbTelefono.Text,
                correo = txbCorreo.Text,
                web = txbWeb.Text,
                giro = txbGiro.Text
            };
            proveedor.validar();
            success = await proveedor.AddAsync();
            if(!success) throw new Exception("Error al guardar Proveedor");
            MessageBox.Show("Proveedor guardado exitosamente", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await CargarProveedores();
            txbCompania.Text = string.Empty;
            txbNIT.Text = string.Empty;
            txbTelefono.Text = string.Empty;
            txbCorreo.Text = string.Empty;
            txbWeb.Text = string.Empty;
            txbGiro.Text = string.Empty;
            rbnNuevo.Checked = true;
            proveedorSeleccionado = null;
        }

        private async Task Actualizar()
        {
            bool success = false;
            ProveedorCLS proveedor = new ProveedorCLS
            {
                id = proveedorSeleccionado.id,
                compania = txbCompania.Text,
                nit = txbNIT.Text,
                telefono = txbTelefono.Text,
                correo = txbCorreo.Text,
                web = txbWeb.Text,
                giro = txbGiro.Text
            };
            proveedor.validar();
            success = await proveedor.UpdateAsync();
            if (!success) throw new Exception("Error al actualizar Proveedor");
            MessageBox.Show("Proveedor actualizado exitosamente", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await CargarProveedores();
            txbCompania.Text = string.Empty;
            txbNIT.Text = string.Empty;
            txbTelefono.Text = string.Empty;
            txbCorreo.Text = string.Empty;
            txbWeb.Text = string.Empty;
            txbGiro.Text = string.Empty;
            rbnNuevo.Checked = true;
            proveedorSeleccionado = null;
        }

        private async Task Eliminar()
        {
            bool success = false;
            ProveedorCLS proveedor = new ProveedorCLS
            {
                id = proveedorSeleccionado.id
            };
            success = await proveedor.DeleteAsync();
            if (!success) throw new Exception("Error al eliminar Proveedor");
            MessageBox.Show("Proveedor eliminado exitosamente", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await CargarProveedores();
            txbCompania.Text = string.Empty;
            txbNIT.Text = string.Empty;
            txbTelefono.Text = string.Empty;
            txbCorreo.Text = string.Empty;
            txbWeb.Text = string.Empty;
            txbGiro.Text = string.Empty;
            rbnNuevo.Checked = true;
            proveedorSeleccionado = null;
        }

        private async void btnAgregarContacto_Click(object sender, EventArgs e)
        {
            // pasamos el proveedor seleccionado a la otra vista
            try
            {
                var dto = (ProveedorDTO)dtgDatos.CurrentRow.DataBoundItem;
                proveedorSeleccionado = await ProveedorCLS.GetByIDAsync(dto.ID);
                EdicionContactoProveedor FormularioProveedor = new EdicionContactoProveedor(proveedorSeleccionado);
                FormularioProveedor.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAgregarDireccion_Click(object sender, EventArgs e)
        {
            try
            {
                var dto = (ProveedorDTO)dtgDatos.CurrentRow.DataBoundItem;
                proveedorSeleccionado = await ProveedorCLS.GetByIDAsync(dto.ID);

                // pasamos el proveedor seleccionado a la otra vista
                DireccionEdicionProveedor FormularioDireccion = new DireccionEdicionProveedor(proveedorSeleccionado);
                FormularioDireccion.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbnNuevo.Checked)
                {
                    await Guardar();
                }
                else if (rbnModificar.Checked && proveedorSeleccionado != null)
                {
                    await Actualizar();
                }
                else if (rbnEliminar.Checked && proveedorSeleccionado != null)
                {
                    await Eliminar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GestionPedidos pedidos = new GestionPedidos();
            pedidos.ShowDialog();
        }
    }
}
