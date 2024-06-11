using SIGIV.CLS;
using SIGIV.CLS.DTO;
using SIGIV.DataLayer;
using SIGIV.GUI.Proveedores;
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
    public partial class AgregarCliente : Form
    {
        private ClienteCLS cliente = null;
        public AgregarCliente(ClienteCLS cliente = null)
        {
            InitializeComponent();
            this.cliente = cliente;
        }

        override async protected void OnLoad(EventArgs e)
        {
            try
            {
                await CargarDatosCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e);
        }

        private async Task CargarDatosCliente()
        {
            if (cliente == null) return;
            this.txtNombre.Text = cliente.nombres;
            this.txtApellidos.Text = cliente.apellidos;
            this.txtDui.Text = cliente.dui;
            this.txtTelefono.Text = cliente.telefono;
            this.txtCorreo.Text = cliente.eMail;
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cliente == null) await Guardar();

                if (cliente != null) await Modificar();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task Modificar()
        {
            ClienteCLS cliente = new ClienteCLS
            {
                id = this.cliente.id,
                nombres = txtNombre.Text,
                apellidos = txtApellidos.Text,
                dui = txtDui.Text,
                telefono = txtTelefono.Text,
                eMail = txtCorreo.Text
            };
            cliente.Validar();
            bool resultado = await cliente.UpdateAsync();
            if (!resultado) throw new Exception("No se pudo modificar el cliente");
            MessageBox.Show("Cliente modificado correctamente", "Cliente modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private async Task Guardar()
        {
            ClienteCLS cliente = new ClienteCLS
            {
                nombres = txtNombre.Text,
                apellidos = txtApellidos.Text,
                dui = txtDui.Text,
                telefono = txtTelefono.Text,
                eMail = txtCorreo.Text
            };
            cliente.Validar();
            bool resultado = await cliente.AddAsync();
            if (!resultado)throw new Exception ("No s<e pudo guardar el cliente");
            //MessageBox.Show("Cliente guardado correctamente", "Cliente guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAgregarDireccion_Click(object sender, EventArgs e)
        {
            DireccionCliente direccionCliente = new DireccionCliente(cliente);
            var result = direccionCliente.ShowDialog();
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Dirección guardada correctamente", "Dirección guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
