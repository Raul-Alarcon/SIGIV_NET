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

namespace SIGIV.GUI.Clientes
{
    public partial class DireccionCliente : Form
    {
        private ClienteCLS clienteSeleccionado = null;
        private DireccionClienteCLS direccionCliente = new DireccionClienteCLS();

        public DireccionCliente(ClienteCLS clienteSeleccionado)
        {
            InitializeComponent();
            this.clienteSeleccionado = clienteSeleccionado;
        }

        protected async override void OnLoad(EventArgs e)
        {
            try
            {
                await CargarDistritos();
                await CargarDatos();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private async Task CargarDistritos()
        {
            var distritos = await DistritosCLS.GetAllDTOAsync();

            distritos = distritos.Select(distrito => new DistritosDTO
            {
                ID = distrito.ID,
                Distrito = distrito.Distrito + " - " + distrito.Municipio + " - " + distrito.Departamento + " - " + distrito.Pais
            }).ToList();

            cmbDirecciones.DataSource = distritos;
            cmbDirecciones.DisplayMember = "Distrito";
            cmbDirecciones.ValueMember = "ID";
        }

        private async Task CargarDatos()
        {
            this.direccionCliente = await this.clienteSeleccionado.GetDireccionAsync();
            if(this.direccionCliente.id > 0)
            {
                txbLinea1.Text = this.direccionCliente.Linea1;
                txbLinea2.Text = this.direccionCliente.Linea2;
                txbCodigoPostal.Text = this.direccionCliente.codigoPostal;
                cmbDirecciones.SelectedValue = this.direccionCliente.idDireccion;
            }   
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.direccionCliente.id > 0)
                {
                    await ActualizarDireccion();
                }
                else
                {
                    await RegistrarDireccion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task RegistrarDireccion()
        {
            DireccionClienteCLS direccion = new DireccionClienteCLS
            {
                id = this.direccionCliente.id,
                Linea1 = txbLinea1.Text,
                Linea2 = txbLinea2.Text,
                codigoPostal = txbCodigoPostal.Text,
                idCliente = this.clienteSeleccionado.id
            };
            direccion.Validar();
            var direccionRegistrada = await direccion.SaveAsync();
            if (direccionRegistrada)
            {
                MessageBox.Show("Direccion registrada correctamente", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al registrar la direccion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ActualizarDireccion()
        {
            direccionCliente.idCliente = this.clienteSeleccionado.id;
            direccionCliente.Linea1 = txbLinea1.Text;
            direccionCliente.Linea2 = txbLinea2.Text;
            direccionCliente.codigoPostal = txbCodigoPostal.Text;
            direccionCliente.idDireccion = (int)cmbDirecciones.SelectedValue;
            direccionCliente.Validar();
            var direccionActualizada = await direccionCliente.UpdateAsync();
            if (direccionActualizada)
            {
                MessageBox.Show("Direccion actualizada correctamente", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al actualizar la direccion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
