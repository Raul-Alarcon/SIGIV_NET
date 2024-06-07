using MaterialSkin;
using MaterialSkin.Controls;
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
            this.FormBorderStyle = FormBorderStyle.None;
            //materialSkinManager.AddFormToManage(this);

            //materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            //materialSkinManager.ColorScheme = new ColorScheme(
            //    Primary.Brown800, 
            //    Primary.Brown800, 
            //    Primary.Brown800, 
            //    Accent.Blue100, 
            //    TextShade.WHITE);
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
                    case "settings":
                        ShowContent(new GUI.Usuarios.GestionUsuarios());
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
    }
}
