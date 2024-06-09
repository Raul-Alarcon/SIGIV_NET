using SIGIV.CLS;
using SIGIV.CLS.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Mapping;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGIV.GUI.Facturas
{
    public partial class AgregarFacturas : Form
    {
        private List<ClienteDTO> clientes;
        private List<ProductoDTO> productos;
        public AgregarFacturas()
        {
            InitializeComponent();
            txtBusquedaCliente.TextChanged += TxtBusquedaCliente_TextChanged;
            txtBuscarProducto.TextChanged += TxtBuscarProducto_TextChanged;
        }

        private void TxtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var busqueda = txtBuscarProducto.Text.ToLower();
                var productosFiltrados = productos.Where(p => p.Producto.ToLower().Contains(busqueda) ||
                        p.Descripcion.ToLower().Contains(busqueda)).ToList();

                dgvProductos.DataSource = productosFiltrados;

                if (txtBuscarProducto.Text.Count() == 0)
                {
                    dgvProductos.DataSource = productos;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBusquedaCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var busqueda = txtBusquedaCliente.Text.ToLower();
                var clientesFiltrados = clientes.Where(c => c.Nombres.ToLower().Contains(busqueda) ||
                        c.Apellidos.ToLower().Contains(busqueda)).ToList();

                dgvClientes.DataSource = clientesFiltrados;

                if (txtBusquedaCliente.Text.Count() == 0)
                {
                    dgvClientes.DataSource = clientes;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                await CargarFormasDePago();
                await CargarProdutos();
                await CargarClientes();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e); 
        }

        private async Task CargarClientes()
        {
            this.clientes = await ClienteCLS.GetAllDTOAsync();
            dgvClientes.DataSource = clientes;
        }

        private async Task CargarProdutos()
        {
            this.productos = await ProductoCLS.GetAllAsync();
            dgvProductos.DataSource = productos; 
        }

        private async Task CargarFormasDePago()
        {
            var formas = await FormasDePagoCLS.GetAsync();
            cbFormaPago.DataSource = formas;
            cbFormaPago.DisplayMember = "tipo";
            cbFormaPago.ValueMember = "id";
        }
    }
}
