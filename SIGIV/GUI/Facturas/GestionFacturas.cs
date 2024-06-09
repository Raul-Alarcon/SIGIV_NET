using CrystalDecisions.CrystalReports.Engine;
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

namespace SIGIV.GUI.Facturas
{
    public partial class GestionFacturas : Form
    {
        private FacturaDTO facturaSeleccionada;
        private List<FacturaDTO> facturas;
        public GestionFacturas()
        {
            InitializeComponent();
            txtIva.Text = "0.13";
            this.dgvProductos.SelectionChanged += DgvProductos_SelectionChanged;
            this.txtBuscar.TextChanged += TxtBuscar_TextChanged;
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscar.Text.Length > 0)
                {
                    var query = txtBuscar.Text.ToLower();
                    var facturasFiltradas = facturas
                        .Where(factura => factura.Cliente.ToLower().Contains(query) || 
                            factura.Empleado.ToLower().Contains(query))
                            .ToList();

                    dgvFacturas.DataSource = facturasFiltradas;
                }
                else
                {
                    dgvFacturas.DataSource = facturas;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if(dgvProductos.Rows.Count > 0)
                {
                    var produtos = dgvProductos.DataSource as List<ProductoFacturaDTO>;
                    decimal subtotal =  produtos.Sum(producto => (producto.Precio * producto.Cantidad));
                    decimal iva = subtotal * 0.13m;

                    txtSubTotal.Text = subtotal.ToString("0.00");
                    txtTotal.Text = (subtotal + iva).ToString("0.00");
                    nFactura.Text = facturaSeleccionada.Id.ToString();
                    dtpFactura.Value = facturaSeleccionada.Fecha;

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
                await CargarFormaPago();
                await CagarFacturas();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private async Task CagarFacturas()
        {
            this.facturas = await FacturaCLS.GetAsync();
            dgvFacturas.DataSource = this.facturas;
        }

        private async Task CargarFormaPago()
        {
            var formaPago = await FormasDePagoCLS.GetAsync();
            cbFormaPago.DataSource = formaPago;
            cbFormaPago.DisplayMember = "tipo";
            cbFormaPago.ValueMember = "id";
        }

        private async void btnMostar_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvFacturas.CurrentRow == null) throw new Exception(Name = "Debe seleccionar una factura");
                if(dgvFacturas.CurrentRow.DataBoundItem is FacturaDTO dto)
                {
                    var factura = new FacturaCLS { id = dto.Id };

                    var productos = await factura.GetAllProductosAsync();
                    dgvProductos.DataSource = productos;
                    dgvFacturas.Refresh();

                    facturaSeleccionada = dto;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        { 
            try
            {
                var fecha = (DateTime)dtpFecha.Value;

                var facturasFiltradas = facturas
                        .Where(factura => factura.Fecha.Equals(fecha))
                            .ToList();

                dgvFacturas.DataSource = facturasFiltradas;


            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
