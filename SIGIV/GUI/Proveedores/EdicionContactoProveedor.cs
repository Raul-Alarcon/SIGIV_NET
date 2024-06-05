using SIGIV.CLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGIV.GUI.Proveedores
{
    public partial class EdicionContactoProveedor : Form
    {
        // creas tu variable de tipo proveedorCls
        private ProveedorCLS proveedorSeleccionado = null;
        // necesitas una variable de tipo contactoProveedorCls
        private ContactoProveedorCLS contactoProveedor = new ContactoProveedorCLS();
        public EdicionContactoProveedor(ProveedorCLS proveedorSeleccionado) // le pasas el proveedorCls
        {
            InitializeComponent();
            // inicializas tu variable
            this.proveedorSeleccionado = proveedorSeleccionado;
        }


        protected async override void OnLoad(EventArgs e)
        {
            // utiliza en try
            // cargas el contacto del proveedorCls
            try
            {
                await CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e); 
        }

        private async Task CargarDatos()
        {
            this.contactoProveedor = await this.proveedorSeleccionado.GetContactoAsync();
            if (this.contactoProveedor.id > 0 )
            {
                // si el id es mayor a 0 es porque ya tiene un contacto
                // entonces llenas los campos con los datos del contacto
                txbnombresContacto.Text = this.contactoProveedor.nombresContacto;
                txbApellidosContacto.Text = this.contactoProveedor.ApellidosContacto;
                txbcargoContacto.Text = this.contactoProveedor.cargoContacto;
                txbtelefonoContacto.Text = this.contactoProveedor.telefonoContacto;
                txbeMailContacto.Text = this.contactoProveedor.eMailContacto;
                txbobservacion.Text = this.contactoProveedor.observacion;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (contactoProveedor.id > 0)
                {
                    await ActualizarContacto();
                }
                else
                {
                    await RegistrarContacto();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task RegistrarContacto()
        {
            ContactoProveedorCLS contacto = new ContactoProveedorCLS
            {
                nombresContacto = txbnombresContacto.Text,
                ApellidosContacto = txbApellidosContacto.Text,
                cargoContacto = txbcargoContacto.Text,
                telefonoContacto = txbtelefonoContacto.Text,
                eMailContacto = txbeMailContacto.Text,
                observacion = txbobservacion.Text,
                idProveedor = proveedorSeleccionado.id
            };
            contacto.validar();
            var contactoRegistrado = await contacto.SaveAsync();
            if (contactoRegistrado)
            {
                MessageBox.Show("Contacto registrado correctamente", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al registrar el contacto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ActualizarContacto()
        {
            contactoProveedor.idProveedor = proveedorSeleccionado.id;
            contactoProveedor.nombresContacto = txbnombresContacto.Text;
            contactoProveedor.ApellidosContacto = txbApellidosContacto.Text;
            contactoProveedor.cargoContacto = txbcargoContacto.Text;
            contactoProveedor.telefonoContacto = txbtelefonoContacto.Text;
            contactoProveedor.eMailContacto = txbeMailContacto.Text;
            contactoProveedor.observacion = txbobservacion.Text;
            contactoProveedor.validar();
            var contactoActualizado = await contactoProveedor.UpdateAsync();
            if (contactoActualizado)
            {
                MessageBox.Show("Contacto actualizado correctamente", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al actualizar el contacto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
