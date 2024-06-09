using SIGIV.GUI.Cargos;
using SIGIV.GUI.CategoriaProductos;
using SIGIV.GUI.Clientes;
using SIGIV.GUI.Departamentos;
using SIGIV.GUI.Distritos;
using SIGIV.GUI.Empleados;
using SIGIV.GUI.Facturas;
using SIGIV.GUI.Municipios;
using SIGIV.GUI.Paises; 
using SIGIV.GUI.ProductosNuevos;
using SIGIV.GUI.Proveedores;
using SIGIV.GUI.Roles;
using SIGIV.GUI.Reportes;
using SIGIV.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIGIV.GUI.FormasPago;
using SIGIV.GUI.Productos;
using System.Web.UI.WebControls;

namespace SIGIV
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login.Login()); // Descomente para el login
            //Application.Run(new GestionFacturas());
        }
    }
}
