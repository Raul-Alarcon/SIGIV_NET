using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGIV.Components
{
    public partial class AccionBar : UserControl
    {
        public AccionBar()
        {
            InitializeComponent();
        }

        [Category("Custom")]
        [Description("The title for AccionBar")]
        public string Titulo
        {
            get { return Title.Text; }
            set { Title.Text = value; }
        } 

        protected virtual void btnClose_Click(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
        }

        protected virtual void btnChangedSizeWindows_Click(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
            {
                if (this.ParentForm.WindowState == FormWindowState.Normal)
                {
                    this.ParentForm.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    this.ParentForm.WindowState = FormWindowState.Normal;
                }
            }

        }

        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.WindowState = FormWindowState.Minimized;
            }
        }
    }
}
