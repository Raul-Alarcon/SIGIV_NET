using SIGIV.CLS;
using SIGIV.CLS.DTO;
using SIGIV.GUI.Clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGIV.GUI.Empleados
{
    public partial class DireccionEmpleado : Form
    {
        private EmpleadoCLS EmpleadoSeleccion = null;
        private DireccionEmpleadoCLS direccionEmpleado = new DireccionEmpleadoCLS();
        public DireccionEmpleado(EmpleadoCLS EmpleadoSeleccion)
        {
            InitializeComponent();
            this.EmpleadoSeleccion = EmpleadoSeleccion;
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
            this.direccionEmpleado = await this.EmpleadoSeleccion.GetDireccionAsync();
            if(this.direccionEmpleado.id > 0)
            {
                txbLinea1.Text = this.direccionEmpleado.Linea1;
                txbLinea2.Text = this.direccionEmpleado.Linea2;
                txbCodigoPostal.Text = this.direccionEmpleado.codigoPostal;
                cmbDirecciones.SelectedValue = this.direccionEmpleado.id;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.direccionEmpleado.id > 0)
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

            DireccionEmpleadoCLS direccion = new DireccionEmpleadoCLS
            {
                id = this.direccionEmpleado.id,
                Linea1 = txbLinea1.Text,
                Linea2 = txbLinea2.Text,
                codigoPostal = txbCodigoPostal.Text,
                idEmpleado = this.EmpleadoSeleccion.idEmpleado
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
            direccionEmpleado.idEmpleado = this.EmpleadoSeleccion.idEmpleado;
            direccionEmpleado.Linea1 = txbLinea1.Text;
            direccionEmpleado.Linea2 = txbLinea2.Text;
            direccionEmpleado.codigoPostal = txbCodigoPostal.Text;
            direccionEmpleado.idDireccion = (int)cmbDirecciones.SelectedValue;
            direccionEmpleado.Validar();
            var direccionActualizada = await direccionEmpleado.UpdateAsync();
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
