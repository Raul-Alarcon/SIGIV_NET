using SIGIV.CLS;
using SIGIV.CLS.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGIV.GUI.Proveedores
{
    public partial class DireccionEdicionProveedor : Form
    {
        private ProveedorCLS proveedorSeleccionado = null;
        private DireccionProveedorCLS direccionProveedor = new DireccionProveedorCLS();
        public DireccionEdicionProveedor(ProveedorCLS proveedorSeleccionado)
        {
            InitializeComponent();
            // resivimos el parametro desde la otra vista
            this.proveedorSeleccionado = proveedorSeleccionado;
        }

        protected async override void OnLoad(EventArgs e)
        {
            try
            {
                await CargarDistritos();
                // vamos a preguntar si el proveedor seleccionado tiene una direccion
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

            distritos = distritos.Select( distrito => new DistritosDTO
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
            this.direccionProveedor = await this.proveedorSeleccionado.GetDireccionAsync();

            if(this.direccionProveedor.id > 0)
            {
                txbLinea1.Text = direccionProveedor.Linea1;
                txbLinea2.Text = direccionProveedor.Linea2;
                txbCodigoPostal.Text = direccionProveedor.codigoPostal.ToString();
                cmbDirecciones.SelectedValue = direccionProveedor.idDireccion;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if(direccionProveedor.id > 0)
                {
                    await ActualizarDireccion();
                }
                else
                {
                    await RegistrarDireccion();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task RegistrarDireccion()
        {
            DireccionProveedorCLS direccion = new DireccionProveedorCLS
            {
                Linea1 = txbLinea1.Text,
                Linea2 = txbLinea2.Text,
                codigoPostal = txbCodigoPostal.Text,
                idProveedor = proveedorSeleccionado.id,
                idDireccion = (int)cmbDirecciones.SelectedValue
            };
            direccion.Validar();
            var direccionRegistrada = await direccion.SaveAsync();
            if(direccionRegistrada)
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
            direccionProveedor.idProveedor = proveedorSeleccionado.id;
            direccionProveedor.Linea1 = txbLinea1.Text;
            direccionProveedor.Linea2 = txbLinea2.Text;
            direccionProveedor.codigoPostal = txbCodigoPostal.Text;
            direccionProveedor.idDireccion = (int)cmbDirecciones.SelectedValue;
            direccionProveedor.Validar();
            var direccionActualizada = await direccionProveedor.UpdateAsync();
            if(direccionActualizada)
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
