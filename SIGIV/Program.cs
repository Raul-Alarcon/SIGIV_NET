using SIGIV.GUI.Cargos;
using SIGIV.GUI.CategoriaProductos;
using SIGIV.GUI.Clientes;
using SIGIV.GUI.Departamentos;
using SIGIV.GUI.Distritos;
using SIGIV.GUI.Empleados;
using SIGIV.GUI.Facturas;
using SIGIV.GUI.Municipios;
using SIGIV.GUI.Paises;
using SIGIV.GUI.Productos;
using SIGIV.GUI.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Application.Run(new DashBoard());
        }
    }
}
