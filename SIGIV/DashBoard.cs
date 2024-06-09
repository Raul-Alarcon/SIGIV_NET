using MaterialSkin;
using MaterialSkin.Controls;
using SIGIV.CLS.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Windows.Forms;

namespace SIGIV
{
    public partial class DashBoard : Form
    { 
        public DashBoard()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            //this.FormBorderStyle = FormBorderStyle.None;
            //materialSkinManager.AddFormToManage(this);

            //materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            //materialSkinManager.ColorScheme = new ColorScheme(
            //    Primary.Brown800, 
            //    Primary.Brown800, 
            //    Primary.Brown800, 
            //    Accent.Blue100, 
            //    TextShade.WHITE); 

           
        }

        override protected void OnFormClosing(FormClosingEventArgs e)
        {
            Login.Login.Instance.Close();
        }

        public override void Refresh()
        {
            try
            {
                var usuario = UserManager.GetSesion();
                lnlUser.Text = usuario.usuario;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.Refresh();
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                var usuario = UserManager.GetSesion(); 
                lnlUser.Text = usuario.usuario;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            base.OnLoad(e); 
        }


        private void buttonSiderBard_Click(object sender, EventArgs e)
        {
            if(sender is Button button)
            {
                switch (button.Name)
                {
                    case "home":
                        MessageBox.Show("Esta sera la navegacion");
                        break;
                    case "empleados":
                        ShowContent(new GUI.Empleados.GestionEmpleados());
                        break;
                    case "usuarios":
                        ShowContent(new GUI.Usuarios.AgregarUsuarios());
                        break;
                    case "clientes":
                        ShowContent(new GUI.Clientes.GestionCliente());
                        break;
                    case "proveedores":
                        ShowContent(new GUI.Proveedores.GestionProveedores());
                        break;
                    case "productos":
                        ShowContent(new GUI.Productos.GestionProductos());
                        break;
                    case "facturas":
                        ShowContent(new GUI.Facturas.GestionFacturas());
                        break;
                    case "pedidos":
                        ShowContent(new GUI.Pedidos.GestionPedidos());
                        break;
                    case "reportes":
                        ShowContent(new GUI.Reportes.ClienteFrecuente());
                        break;
                    case "settings":
                        ShowContent(new GUI.Usuarios.AgregarUsuarios());
                        break;
                    default: break; 
                }
            }
        }

        private void ShowContent(Form content)
        { 
            content.TopLevel = false;
            content.FormBorderStyle = FormBorderStyle.None;
            content.Dock = DockStyle.Fill;
            ContentLayout.Controls.Add(content);
            ContentLayout.Tag = content;
            content.BringToFront();
            content.Show();
        }

        private void btnCerrarSession_Click(object sender, EventArgs e)
        {
            try
            {

                var forms = Application.OpenForms;

                
               if (UserManager.CerrarSesion())
               {
                    Login.Login.dashBoard = this;
                    Login.Login.dashBoard.Hide(); 

                    Login.Login.Instance.Show(); 
               }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
