using SIGIV.CLS;
using SIGIV.CLS.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGIV.GUI.Pedidos
{
    public partial class GestionPedidos : Form
    {
        private List<ProductoFacturaDTO> productosPedidos = new List<ProductoFacturaDTO>();
        private List<PedidoDTO> pedidos = new List<PedidoDTO>();
        private List<ProductoDTO> productos = new List<ProductoDTO>();
        private PedidoDTO pedidoSeleccionado = null;
        private ProductoFacturaDTO productoSeleccionado = null;
        public GestionPedidos()
        {
            InitializeComponent();
            this.txbBuscarProducto.TextChanged += TxbBuscarProducto_TextChanged;
            txbBuscarPedidos.TextChanged += TxbBuscarPedidos_TextChanged;
            dgvProductosEnStock.SelectionChanged += DgvProductosEnStock_SelectionChanged;
            txtIva.Text = "13%";
            dgvProductosPedidos.SelectionChanged += DgvProductosPedidos_SelectionChanged;
        }

        private void DgvProductosPedidos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if(dgvProductosPedidos.Rows.Count > 0)
                {
                    decimal subTotal = productosPedidos.Sum( p => (p.Precio * p.Cantidad));
                    decimal iva = subTotal * 0.13m;
                    decimal total = subTotal + iva;
                    txtSubTotal.Text = subTotal.ToString("0.00");
                    txtTotal.Text = total.ToString("0.00");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvProductosEnStock_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if(dgvProductosEnStock.CurrentRow == null) return;
                if (dgvProductosEnStock.CurrentRow.DataBoundItem is ProductoDTO productoDTO)
                { 
                    txtbProductoSeleccionado.Text = $"{productoDTO.Producto} Precio: {productoDTO.Precio}";
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxbBuscarPedidos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txbBuscarPedidos.Text == "")
                {
                    dgvPedidos.DataSource = pedidos;
                }
                else
                {
                    string query = txbBuscarPedidos.Text.ToLower();

                    var filtro = pedidos.Where(p => p.Proveedor.ToLower().Contains(query) ||
                        p.Fecha_Pedido.ToString().Contains(query) ||
                        p.Fecha_Pedido.ToString().Contains(query)).ToList();

                    dgvPedidos.DataSource = filtro;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxbBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txbBuscarProducto.Text == "")
                {
                    dgvProductosEnStock.DataSource = productos;
                }
                else
                {
                    string query = txbBuscarProducto.Text.ToLower();

                    var filtro = productos.Where(p => p.Producto.ToLower().Contains(query) ||
                        p.Categoria.ToLower().Contains(query) ||
                        p.Precio.ToString().Contains(query)).ToList();

                    dgvProductosEnStock.DataSource = filtro;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                await CargarPedidos();
                await CargarProveedores();
                await CargarProductos();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e); 
        }

        private async Task CargarPedidos()
        {
            pedidos = await PedidoCLS.GetAsync();
            dgvPedidos.DataSource = pedidos;
        }

        private async Task CargarProductos()
        {
            productos = await ProductoCLS.GetAllAsync();
            dgvProductosEnStock.DataSource = productos;
        }

        private async Task CargarProveedores()
        {
            var proveedores = await ProveedorCLS.GetAllContactosAsync();
            
            proveedores = proveedores.Select( prov => new CLS.DTO.ContactoProveedorDTO
            {
                ID = prov.ID,
                Nombre = prov.Compania + " - " + prov.Nombre 
            }).ToList();

            cmbProveedores.DataSource = proveedores;
            cmbProveedores.DisplayMember = "Nombre";
            cmbProveedores.ValueMember = "ID";
        }

        private void txbAgregarAlPedido_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvProductosEnStock.CurrentRow ==  null) throw new Exception("Debe seleccionar un producto");
                if (dgvProductosEnStock.CurrentRow.DataBoundItem is ProductoDTO productoDTO)
                {

                    if (txbCantidad.Text == "") throw new Exception("Debe ingresar una cantidad");
                    if (productosPedidos.Exists(p => p.ID == productoDTO.ID)) throw new Exception("El producto ya fue agregado al pedido");

                    var producto = new ProductoFacturaDTO
                    {
                        ID = productoDTO.ID,
                        Producto = productoDTO.Producto,
                        Precio = productoDTO.Precio,
                        Cantidad = Convert.ToInt32(txbCantidad.Text),
                    };

                    
                    productosPedidos.Add(producto);
                    dgvProductosPedidos.DataSource = null;
                    dgvProductosPedidos.DataSource = productosPedidos;
                    dgvProductosPedidos.Refresh();
                    txbCantidad.Text = "";
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvProductosPedidos.CurrentRow == null) throw new Exception("Debe seleccionar un producto");
                if (dgvProductosPedidos.CurrentRow.DataBoundItem is ProductoFacturaDTO productoFacturaDTO)
                {
                    productosPedidos.Remove(productoFacturaDTO);
                    dgvProductosPedidos.DataSource = null;
                    dgvProductosPedidos.DataSource = productosPedidos;
                    dgvProductosPedidos.Refresh();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnHacerPedido_Click(object sender, EventArgs e)
        {
            try
            {
                if (productosPedidos.Count == 0) throw new Exception("Debe agregar productos al pedido");
                if (cmbProveedores.SelectedValue == null) throw new Exception("Debe seleccionar un proveedor");

                PedidoCLS pedido = new PedidoCLS
                {
                    idProveedor = (int)cmbProveedores.SelectedValue,
                    fechaPedido = dtpFechaPedido.Value, 
                    comentario = txbComentario.Text,
                    productos = productosPedidos 
                };

                bool succes = await pedido.HacerPedidoAsync();
                if (!succes) throw new Exception("Ocurrio un error al realizar el pedido");

                MessageBox.Show("Pedido realizado correctamente", "Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarPedidos();
                productosPedidos.Clear();
                dgvProductosPedidos.DataSource = null;
                dgvProductosPedidos.Refresh();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnProcesarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvPedidos.CurrentRow == null) throw new Exception("Debe seleccionar un pedido");
                if (dgvPedidos.CurrentRow.DataBoundItem is PedidoDTO pedidoDTO)
                { 

                    if (pedidoDTO.Estado == "Procesada") throw new Exception("El pedido ya fue procesado");
                    PedidoCLS pedido = new PedidoCLS
                    {
                        idPedido = pedidoDTO.Id, 
                    };

                    bool result = await pedido.RecibirPedidoAsync();
                    if (!result) throw new Exception("Ocurrio un error al procesar el pedido");
                    await pedido.GetProductosAsync();

                    if(pedido.productos.Count <= 0 ) throw new Exception("No se encontraron productos en el pedido");

                    result  = await  pedido.ProcesarProductos();

                    if(!result) throw new Exception("Ocurrio un error al procesar los productos");
                    MessageBox.Show("Pedido procesado correctamente", "Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarPedidos();
                    await CargarProductos();

                    productosPedidos.Clear();
                    dgvProductosPedidos.DataSource = null;
                    dgvProductosPedidos.Refresh();
                }
            }
            catch (Exception exc)
            { 
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnElimiarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPedidos.CurrentRow == null) throw new Exception("Debe seleccionar un pedido");
                if (dgvPedidos.CurrentRow.DataBoundItem is PedidoDTO pedidoDTO)
                {
                    if(MessageBox.Show("¿Está seguro de eliminar el pedido?", "Eliminar Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool result = await PedidoCLS.DeleteAsync(pedidoDTO.Id);
                        if (!result) throw new Exception("Ocurrio un error al eliminar el pedido");
                        MessageBox.Show("Pedido eliminado correctamente", "Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await CargarPedidos();
                    
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPedidos.CurrentRow == null) throw new Exception("Debe seleccionar un pedido");
                if (dgvPedidos.CurrentRow.DataBoundItem is PedidoDTO pedidoDTO)
                {
                    var productos = await PedidoCLS.GetProductosAsync(pedidoDTO.Id);
                    productosPedidos = productos;
                    dgvProductosPedidos.DataSource = null;
                    dgvProductosPedidos.DataSource = productos;
                    dgvProductosPedidos.Refresh();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
