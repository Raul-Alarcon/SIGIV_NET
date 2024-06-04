using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGIV.GUI.Clientes
{
    public partial class GestionCliente : Form
    {
        public GestionCliente()
        {
            InitializeComponent();
        }

        override async protected void OnLoad(EventArgs e)
        {
            try
            {
                await Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private async Task Cargar()
        {
            dgvClientes.DataSource = await CLS.ClienteCLS.GetAllDTOAsync();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarCliente agregar = new AgregarCliente();
            var result = agregar.ShowDialog();
            if (result == DialogResult.OK)
            {
                await Cargar();
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.SelectedRows.Count == 0) throw new ArgumentException("Debe seleccionar un cliente");
                var dto = (CLS.DTO.ClienteDTO)dgvClientes.CurrentRow.DataBoundItem;
                var cliente = await CLS.ClienteCLS.GetByIdAsync(dto.ID);
                AgregarCliente agregar = new AgregarCliente(cliente);
                var result = agregar.ShowDialog();
                if (result == DialogResult.OK)
                {
                    await Cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.SelectedRows.Count == 0) throw new ArgumentException("Debe seleccionar un cliente");
                var dto = (CLS.DTO.ClienteDTO)dgvClientes.CurrentRow.DataBoundItem;
                if (MessageBox.Show("¿Está seguro que desea eliminar el cliente?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool success = await CLS.ClienteCLS.DeleteAsync(dto.ID);
                    if (!success) throw new ArgumentException("Error al eliminar el cliente");
                    await Cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
