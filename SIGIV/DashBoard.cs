using MaterialSkin;
using MaterialSkin.Controls;
using SIGIV.CLS.Auth;
using SIGIV.GUI.Auth.Usuarios;
using SIGIV.GUI.Clientes;
using SIGIV.GUI.Empleados;
using SIGIV.GUI.Facturas;
using SIGIV.GUI.Pedidos;
using SIGIV.GUI.Productos;
using SIGIV.GUI.Proveedores;
using SIGIV.GUI.Reportes;
using SIGIV.GUI.Usuarios;
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
    public partial class DashBoard : MaterialForm
    { 
        public DashBoard()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            this.FormBorderStyle = FormBorderStyle.None;
            materialSkinManager.AddFormToManage(this);

            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Green800,
                Primary.Purple800,
                Primary.Purple800,
                Accent.Blue100,
                TextShade.WHITE);


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


        //private void buttonSiderBard_Click(object sender, EventArgs e)
        //{
        //    if(sender is Button button)
        //    {
        //        switch (button.Name)
        //        {
        //            case "home":
        //                MessageBox.Show("Esta sera la navegacion");
        //                break;
        //            case "empleados":
        //                ShowContent(new GUI.Empleados.GestionEmpleados());
        //                break;
        //            case "usuarios":
        //                ShowContent(new GUI.Usuarios.AgregarUsuarios());
        //                break;
        //            case "clientes":
        //                ShowContent(new GUI.Clientes.GestionCliente());
        //                break;
        //            case "proveedores":
        //                ShowContent(new GUI.Proveedores.GestionProveedores());
        //                break;
        //            case "productos":
        //                ShowContent(new GUI.Productos.GestionProductos());
        //                break;
        //            case "facturas":
        //                ShowContent(new GUI.Facturas.GestionFacturas());
        //                break;
        //            case "pedidos":
        //                ShowContent(new GUI.Pedidos.GestionPedidos());
        //                break;
        //            //case "reportes":
        //               // ShowContent(new GUI.Reportes.GestionReportes());
        //              //  break;
        //            case "settings":
        //                ShowContent(new GUI.Usuarios.AgregarUsuarios());
        //                break;
        //            default: break; 
        //        }
        //    }
        //}

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

        private void materialTabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (materialTabControl1.SelectedIndex == 0)
            {
                MessageBox.Show("Esta sera la navegacion");
            }
            else if (materialTabControl1.SelectedIndex == 1)
            {
                ShowContent(new GestionEmpleados());
            }
            else if (materialTabControl1.SelectedIndex == 2)
            {
                ShowContent(new AgregarUsuarios());
            }
            else if (materialTabControl1.SelectedIndex == 3)
            {
                ShowContent(new GestionCliente());
            }
            else if (materialTabControl1.SelectedIndex == 4)
            {
                ShowContent(new AgregarFacturas());
            }
            else if (materialTabControl1.SelectedIndex == 5)
            {
                ShowContent(new GestionProveedores());
            }
            else if (materialTabControl1.SelectedIndex == 6)
            {
                ShowContent(new GestionProductos());
            }
            else if (materialTabControl1.SelectedIndex == 7)
            {
                ShowContent(new ClienteFrecuente());
            }
            else if(materialTabControl1.SelectedIndex == 8)
            {
                ShowContent(new GestionUsuarios());
                
            }

        }
    }
}
