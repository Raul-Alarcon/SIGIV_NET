using SIGIV.CLS;
using SIGIV.CLS.Auth;
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
        private ClienteDTO clienteSeleccionado = null;
        private ProductoDTO productoSeleccionado = null;
        private List<ProductoFacturaDTO> productosSeleccionados = new List<ProductoFacturaDTO>();
        
        decimal Iva = 0.13m;
        public AgregarFacturas()
        {
            InitializeComponent();
            txtBusquedaCliente.TextChanged += TxtBusquedaCliente_TextChanged;
            txtBuscarProducto.TextChanged += TxtBuscarProducto_TextChanged;

            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
            dgvClientes.SelectionChanged += DtgClientesSeleccionados_SelectionChanged;
            nudContador.Value = 1;
            nudContador.ValueChanged += NudContador_ValueChanged;
            dtgProductosSeleccionados.SelectionChanged += DtgProductosSeleccionados_SelectionChanged;
            txtIva.Text = "13%";
            txtEfectivoRecibido.TextChanged += TxtEfectivoRecibido_TextChanged;
        }

        private void TxtEfectivoRecibido_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(txtEfectivoRecibido.Text != string.Empty)
                {
                    int efectivoRecibido = Convert.ToInt32(txtEfectivoRecibido.Text);
                    decimal total = Convert.ToDecimal(txtTotal.Text);

                    decimal cambio = (efectivoRecibido - total);
                    txtCambio.Text = cambio.ToString("0.0");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void DtgProductosSeleccionados_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if(dtgProductosSeleccionados.Rows.Count > 0)
                {
                    decimal subTotal = productosSeleccionados.Sum(p => (p.Precio * p.Cantidad));
                    txtSubTotal.Text = subTotal.ToString("0.00");
                    txtTotal.Text = (subTotal + (subTotal * Iva)).ToString("0.00");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void NudContador_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(nudContador.Value) > productoSeleccionado.Stok)
                { 
                    nudContador.Value = productoSeleccionado.Stok;
                    throw new Exception("No tienes más productos en stock para la compra.");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DtgClientesSeleccionados_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.CurrentRow.DataBoundItem is ClienteDTO cliente)
                {
                    txtCliente.Text = cliente.Nombres + " " + cliente.Apellidos;
                    clienteSeleccionado = cliente;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.CurrentRow.DataBoundItem is ProductoDTO producto)
                {
                    txtProducto.Text = producto.Producto;
                    productoSeleccionado = producto;
                    this.nudContador.Value = 1;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        #region carga de datos
        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                await CargarFormasDePago();
                await CargarProdutos();
                await CargarClientes();
                //dtgProductosSeleccionados.DataSource = productosSeleccionados;
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
            this.productos = await ProductoCLS.GetAllAsync( producto => producto.DetallesStok.cantidadStok > 0);
            dgvProductos.DataSource = productos; 
        }

        private async Task CargarFormasDePago()
        {
            var formas = await FormasDePagoCLS.GetAsync();
            cbFormaPago.DataSource = formas;
            cbFormaPago.DisplayMember = "tipo";
            cbFormaPago.ValueMember = "id";
        }
        #endregion

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if(productoSeleccionado == null) throw new Exception("Debe seleccionar un producto");

                var producto = productoSeleccionado.ToProductoFacturaDTO();
                producto.Cantidad = Convert.ToInt32(nudContador.Value);

                if(productosSeleccionados.Exists(p => p.ID == productoSeleccionado.ID))
                {
                    int cantidad = productosSeleccionados.Find(p => p.ID == productoSeleccionado.ID).Cantidad;
                    int index = productosSeleccionados.FindIndex(p => p.ID == producto.ID);

                    int total = cantidad + Convert.ToInt32(nudContador.Value);

                    if (total > productoSeleccionado.Stok) throw new Exception("La cantidad de productos en stock no coincide con la venta");
                    productosSeleccionados[index].Cantidad = total;
                }
                else
                {
                    productosSeleccionados.Add(producto); 
                }

                dtgProductosSeleccionados.DataSource = null;
                dtgProductosSeleccionados.DataSource = productosSeleccionados;
                dtgProductosSeleccionados.Refresh();
                nudContador.Value = 1; 
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgProductosSeleccionados.CurrentRow == null) throw new Exception("Seleccione un producto");
                if (dtgProductosSeleccionados.CurrentRow.DataBoundItem is ProductoFacturaDTO producto)
                {
                    this.productosSeleccionados.Remove(producto);
                    this.dtgProductosSeleccionados.DataSource = null;
                    this.dtgProductosSeleccionados.DataSource = productosSeleccionados;
                    this.dtgProductosSeleccionados.Refresh();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (productosSeleccionados.Count <= 0) throw new Exception("Necesitas agragar productos para generar una factura");
                if (clienteSeleccionado == null) throw new Exception("Necesitas seleccionar un cliente para generar una factura");
                if (string.IsNullOrEmpty(txtCambio.Text)) throw new Exception("Al parecer no as digitado el efectivo");
                if (Convert.ToDecimal(txtCambio.Text) < 0) throw new Exception("El efectivo recibido no puede ser menor al total de la factura");

                FacturaCLS factura = new FacturaCLS
                {
                    idCliente = clienteSeleccionado.ID,
                    idEmpleado = UserManager.GetSesion().idEmpleado,// debe ser el empleado en session
                    iva = this.Iva,
                    fechaFactura = dtpFecha.Value,
                    productos = productosSeleccionados
                };

                factura = await factura.SaveAndReturnAsync();
                if (factura.id <= 0) throw new Exception("Ocurrio un error interno al generar la factura, porfavor intentalo mas tarde");

                TransaccionCLS transaccion = new TransaccionCLS
                {
                    idFactura = factura.id,
                    monto = Convert.ToDecimal(this.txtTotal.Text),
                    fechaTransaccion = factura.fechaFactura,
                    idTipoPago = Convert.ToInt32(cbFormaPago.SelectedValue)
                };

                bool succes = await transaccion.SaveAsync(); 
                if (!succes) throw new Exception("No se pudo completar el pago, porfavor intentelo otra vez");
                MessageBox.Show("La factura fue guardada con exito");
                txtCambio.Text = string.Empty;
                txtEfectivoRecibido.Text = string.Empty;
                txtSubTotal.Text = string.Empty;
                txtTotal.Text = string.Empty;

                productosSeleccionados.Clear();
                dtgProductosSeleccionados.DataSource = null; 
                dtgProductosSeleccionados.DataSource = productosSeleccionados;
                await CargarProdutos();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
