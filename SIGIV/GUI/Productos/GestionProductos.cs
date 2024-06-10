using BarcodeLib;
using BarcodeStandard;
using SIGIV.CLS;
using SIGIV.CLS.DTO;
using SIGIV.CLS.utils;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        Image imgCode = null;
        public GestionProductos()
        {
            InitializeComponent();
            dtgDatos.SelectionChanged += DtgDatos_SelectionChanged;
            btnArchivarCodigo.Click += btnArchivarCodigo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnQuitarImagen.Click += btnQuitarImagen_Click;
            btnSeleccionarImagen.Click += btnSeleccionarImagen_Click;
            button1.Click += button1_Click;
            tsbEliminar.Click += tsbEliminar_Click;
            tsbModificar.Click += tsbModificar_Click;
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
                if(string.IsNullOrEmpty(txbCodigoBarra.Text)) throw new Exception(Name + "El campo de código de barras no puede estar vacío");
                if (this.imgCode == null)
                {
                    GenerarCodigo();
                }
                ProductoCLS producto = new ProductoCLS
                {
                    id = idProductoSeleccionado,
                    producto = txbNombre.Text,
                    descripcion = txbDescripcion.Text,
                    precio = decimal.Parse(txbPrecio.Text),
                    idCategoria = (int)cmbCategoria.SelectedValue,
                    idStok = stock.idStok,
                    codigo = txbCodigoBarra.Text,
                    imgCodigo = ImgConvert.ImageToBase64(imgCodigoBarra.Image, System.Drawing.Imaging.ImageFormat.Png),
                    img = imgProducto.Image != null ? 
                        ImgConvert.ImageToBase64(imgProducto.Image, System.Drawing.Imaging.ImageFormat.Png) : null
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
                    txbCodigoBarra.Text = String.Empty;
                    imgCodigoBarra.Image = null;
                    imgProducto.Image = null;
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
                if (string.IsNullOrEmpty(txbCodigoBarra.Text)) throw new Exception(Name + "El campo de código de barras no puede estar vacío");
                if (this.imgCode == null)
                {
                    GenerarCodigo();
                }

                ProductoCLS producto = new ProductoCLS
                {
                    producto = txbNombre.Text,
                    descripcion = txbDescripcion.Text,
                    precio = decimal.Parse(txbPrecio.Text),
                    idCategoria = (int)cmbCategoria.SelectedValue,
                    idStok = stockResult.idStok,
                    codigo = txbCodigoBarra.Text,
                    imgCodigo = ImgConvert.ImageToBase64(imgCode, System.Drawing.Imaging.ImageFormat.Png),
                    img = ImgConvert.ImageToBase64(imgProducto.Image, System.Drawing.Imaging.ImageFormat.Png)
                };
                bool result = await producto.AddAsync();
                if (!result) throw new Exception("Error al guardar el producto");

                MessageBox.Show("Producto guardado correctamente");
                idStockSeleccionado = 0;
                idProductoSeleccionado = 0;
                txbStock.Text = String.Empty;
                txbPrecio.Text = String.Empty;
                txbDescripcion.Text = String.Empty;
                txbNombre.Text = String.Empty;
                txbCodigoBarra.Text = String.Empty;
                await CargarProductos();
            }
        }

        private async void tsbModificar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if(idProductoSeleccionado <= 0) throw new Exception("Debe seleccionar un producto");

                ProductoCLS producto = await ProductoCLS.GetByIDAsync(idProductoSeleccionado);
                txbNombre.Text = producto.producto;
                txbDescripcion.Text = producto.descripcion;
                txbPrecio.Text = producto.precio.ToString();
                txbStock.Text = producto.cantidadStok.ToString();
                cmbCategoria.SelectedValue = producto.idCategoria;
                idStockSeleccionado = producto.idStok;
                txbCodigoBarra.Text = producto.codigo;
                imgCodigoBarra.Image = producto.imgCodigo != null ?
                        ImgConvert.Base64ToImage(producto.imgCodigo) : null;

                imgProducto.Image = producto.img != null ? 
                    ImgConvert.Base64ToImage(producto.img) : null;
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                GenerarCodigo();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error al generar el código de barras: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarCodigo()
        {
            if (string.IsNullOrEmpty(txbCodigoBarra.Text)) throw new Exception(Name + "El campo de código de barras no puede estar vacío");
            Barcode code = new Barcode();
            code.IncludeLabel = true;
            code.LabelPosition = LabelPositions.BOTTOMCENTER;
            string stringToCode = $"{txbCodigoBarra.Text}";
            imgCode = code.Encode(TYPE.CODE128, stringToCode, Color.Black, Color.White, 290, 120);
            this.imgCodigoBarra.Image = imgCode;

            
        }

        private void btnArchivarCodigo_Click(object sender, EventArgs e)
        { 
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = $"{txbCodigoBarra.Text}.png";
            saveFileDialog.Filter = "Imagen PNG|*.png";
            saveFileDialog.Title = "Guardar código de barras";
            
            var result = saveFileDialog.ShowDialog();  
            if (result == DialogResult.OK)
            {
                imgCode.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            Image imgProd = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagen PNG|*.png";
            openFileDialog.Title = "Seleccionar imagen";
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                imgProd = Image.FromFile(openFileDialog.FileName);
                this.imgProducto.Image = ImgConvert.RedimencionarImagen(imgProd, 181, 95);
            }
        }

        private void btnQuitarImagen_Click(object sender, EventArgs e)
        {
            this.imgProducto.Image = null;
        }
    }
}
