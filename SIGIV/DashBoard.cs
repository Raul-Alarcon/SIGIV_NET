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
            //materialSkinManager.AddFormToManage(this);

            //materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            //materialSkinManager.ColorScheme = new ColorScheme(
            //    Primary.Brown800, 
            //    Primary.Brown800, 
            //    Primary.Brown800, 
            //    Accent.Blue100, 
            //    TextShade.WHITE);
        }
    }
}
