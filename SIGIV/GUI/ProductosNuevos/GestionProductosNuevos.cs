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

namespace SIGIV.GUI.ProductosNuevos
{
    public partial class GestionProductosNuevos : Form
    {
        int idProductoNuevoSeleccionado = 0;
        int idStockSeleccionado = 0;
        public GestionProductosNuevos()
        {
            InitializeComponent();
            dtgDatos.SelectionChanged += DtgDatos_SelectionChanged;
        }

        private void DtgDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgDatos.SelectedRows.Count > 0)
            {
                ProductoNuevoDTO producto = (ProductoNuevoDTO)dtgDatos.CurrentRow.DataBoundItem;

                idProductoNuevoSeleccionado = producto.ID;
            }
        }

        protected async override void OnLoad(EventArgs e)
        {
            try
            {
                await CargarCategorias();
                await CargarProductosNuevos();
            }
            catch
            {
                MessageBox.Show("Error al cargar los productos");
            }

            base.OnLoad(e);
        }

        private async Task CargarProductosNuevos()
        {
            List<ProductoNuevoDTO> productos = await ProductoNuevoCLS.GetAllAsync();
            dtgDatos.DataSource = productos;
        }

        private async Task CargarCategorias()
        {
            List<CategoriaProuctoCLS> categorias = await CategoriaProuctoCLS.GetAllAsync();
            cmbCategoria.DataSource = categorias;
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "Id";
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idProductoNuevoSeleccionado <= 0)
                {
                    await GuardarProductoNuevo();
                }
                else
                {
                    await ActualizarProductoNuevo();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el producto: " + ex.Message);
            }
        }

        private async Task GuardarProductoNuevo()
        {
            StockCLS stock = new StockCLS
            {
                cantidadStok = int.Parse(txbStock.Text),
                descripcion = "Producto en stock"
            };
            StockCLS resultStock = await stock.AddAsync();
            if (resultStock.idStok > 0)
            {
                ProductoNuevoCLS producto = new ProductoNuevoCLS
                {
                    nombreP = txbNombre.Text,
                    descripcion = txbDescripcion.Text,
                    precio = decimal.Parse(txbPrecio.Text),
                    idCategoria = (int)cmbCategoria.SelectedValue
                };
                bool result = await producto.AddAsync();
                if (result)
                {
                    MessageBox.Show("Producto guardado correctamente");
                    txbStock.Text = String.Empty;
                    txbPrecio.Text = String.Empty;
                    txbDescripcion.Text = String.Empty;
                    txbNombre.Text = String.Empty;
                    await CargarProductosNuevos();
                }
                else
                {
                    MessageBox.Show("Error al guardar el producto");
                }
            }
        }

        private async Task ActualizarProductoNuevo()
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
                ProductoNuevoCLS producto = new ProductoNuevoCLS
                {
                    id = idProductoNuevoSeleccionado,
                    nombreP = txbNombre.Text,
                    descripcion = txbDescripcion.Text,
                    precio = decimal.Parse(txbPrecio.Text),
                    idCategoria = (int)cmbCategoria.SelectedValue
                };
                bool result = await producto.UpdateAsync();
                if (result)
                {
                    MessageBox.Show("Producto actualizado correctamente");
                    idStockSeleccionado = 0;
                    idProductoNuevoSeleccionado = 0;
                    txbStock.Text = String.Empty;
                    txbPrecio.Text = String.Empty;
                    txbDescripcion.Text = String.Empty;
                    txbNombre.Text = String.Empty;
                    await CargarProductosNuevos();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el producto");
                }
            }
        }

        private async void tsbModificar_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoNuevoCLS producto = await ProductoNuevoCLS.GetByIDAsync(idProductoNuevoSeleccionado);
                txbNombre.Text = producto.nombreP;
                txbDescripcion.Text = producto.descripcion;
                txbPrecio.Text = producto.precio.ToString();
                cmbCategoria.SelectedValue = producto.idCategoria;
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
                    ProductoNuevoDTO producto = (ProductoNuevoDTO)dtgDatos.CurrentRow.DataBoundItem;
                    if (MessageBox.Show("¿Está seguro de eliminar el producto?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        bool result = await ProductoNuevoCLS.DeleteAsync(producto.ID);
                        if (result)
                        {
                            MessageBox.Show("Producto eliminado correctamente");
                            await CargarProductosNuevos();
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
