using SIGIV.GUI.Cargos;
using SIGIV.GUI.CategoriaProductos;
using SIGIV.GUI.Departamentos;
using SIGIV.GUI.Empleados;
using SIGIV.GUI.Paises;
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
            Application.Run(new GestionDepartamentos());
        }
    }
}
