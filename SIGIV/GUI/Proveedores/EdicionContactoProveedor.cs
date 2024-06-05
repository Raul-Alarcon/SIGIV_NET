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
        // necesitas una variable de tipo contactoProveedorCls
        public EdicionContactoProveedor() // le pasas el proveedorCls
        {
            InitializeComponent();
            // inicializas tu variable
        }


        protected override void OnLoad(EventArgs e)
        {
            // utiliza en try
            // cargas el contacto del proveedorCls
            base.OnLoad(e); 
        }
    }
}
