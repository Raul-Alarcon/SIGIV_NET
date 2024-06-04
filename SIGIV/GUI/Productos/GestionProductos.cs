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

namespace SIGIV.GUI.Productos
{
    public partial class GestionProductos : Form
    {
        int idProductoSeleccionado = 0;
        int idStockSeleccionado = 0;
        public GestionProductos()
        {
            InitializeComponent();
            dtgDatos.SelectionChanged += DtgDatos_SelectionChanged;
        }

        private void DtgDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgDatos.SelectedRows.Count > 0)
            {
                ProductoDTO producto = (ProductoDTO)dtgDatos.CurrentRow.DataBoundItem;
                
                idProductoSeleccionado = producto.ID;
            }
        }

        protected async override void OnLoad(EventArgs e)
        {
            try 
            {
                await CargarCategorias();
                await CargarProductos();
            } 
            catch 
            {
                MessageBox.Show("Error al cargar los productos");
            }

            base.OnLoad(e);
        }

        private async Task CargarCategorias()
        {
            List<CategoriaProuctoCLS> categorias = await CategoriaProuctoCLS.GetAllAsync();
            cmbCategoria.DataSource = categorias;
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "Id";
        }

        private async Task CargarProductos()
        { 
            List<ProductoDTO> productos = await ProductoCLS.GetAllAsync();
            dtgDatos.DataSource = productos;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idProductoSeleccionado <= 0)
                {
                    await GuardarNuevoProducto();
                }
                else
                {
                    await ActualizarProducto();
                }
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el producto: " + ex.Message);
            }
        }

        private async Task ActualizarProducto()
        {
            StockCLS stock = new StockCLS
            {
                idStok = idStockSeleccionado,
                cantidadStok = int.Parse(txbStock.Text),
                descripcion = "Producto en stock"
            };
            bool resultStock = await stock.UpdateAsync();
            if (resultStock)
            {
                ProductoCLS producto = new ProductoCLS
                {
                    id = idProductoSeleccionado,
                    producto = txbNombre.Text,
                    descripcion = txbDescripcion.Text,
                    precio = decimal.Parse(txbPrecio.Text),
                    idCategoria = (int)cmbCategoria.SelectedValue,
                    idStok = stock.idStok
                };
                bool result = await producto.UpdateAsync();
                if (result)
                {
                    MessageBox.Show("Producto actualizado correctamente");
                    idStockSeleccionado = 0;
                    idProductoSeleccionado = 0;
                    txbStock.Text = String.Empty;
                    txbPrecio.Text = String.Empty;
                    txbDescripcion.Text = String.Empty;
                    txbNombre.Text = String.Empty;
                    await CargarProductos();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el producto");
                }
            }
        }

        private async Task GuardarNuevoProducto()
        {
            StockCLS stock = new StockCLS
            {

                cantidadStok = int.Parse(txbStock.Text),
                descripcion = "Producto en stock"
            };
            StockCLS stockResult = await stock.AddAsync();
            if (stockResult.idStok > 0)
            {
                ProductoCLS producto = new ProductoCLS
                {
                    producto = txbNombre.Text,
                    descripcion = txbDescripcion.Text,
                    precio = decimal.Parse(txbPrecio.Text),
                    idCategoria = (int)cmbCategoria.SelectedValue,
                    idStok = stockResult.idStok
                };
                bool result = await producto.AddAsync();
                if (result)
                {
                    MessageBox.Show("Producto guardado correctamente");
                    idStockSeleccionado = 0;
                    idProductoSeleccionado = 0;
                    txbStock.Text = String.Empty;
                    txbPrecio.Text = String.Empty;
                    txbDescripcion.Text = String.Empty;
                    txbNombre.Text = String.Empty;
                    await CargarProductos();
                }
                else
                {
                    MessageBox.Show("Error al guardar el producto");
                }
            }
        }

        private async void tsbModificar_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoCLS producto = await ProductoCLS.GetByIDAsync(idProductoSeleccionado);
                txbNombre.Text = producto.producto;
                txbDescripcion.Text = producto.descripcion;
                txbPrecio.Text = producto.precio.ToString();
                txbStock.Text = producto.cantidadStok.ToString();
                cmbCategoria.SelectedValue = producto.idCategoria;
                idStockSeleccionado = producto.idStok;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el producto: " + ex.Message);
            }
        }

        private async void tsbEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgDatos.SelectedRows.Count > 0)
                {
                    ProductoDTO producto = (ProductoDTO)dtgDatos.CurrentRow.DataBoundItem;
                   if (MessageBox.Show("¿Está seguro de eliminar el producto?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                      
                        bool result = await ProductoCLS.DeleteAsync(producto.ID);
                        if (result)
                        {
                            MessageBox.Show("Producto eliminado correctamente");
                            await CargarProductos();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el producto");
                        }
                    }
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el producto: " + ex.Message);
            }
        }
    }
}
