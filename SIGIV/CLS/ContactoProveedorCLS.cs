using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS
{
    public class ContactoProveedorCLS
    {
        public int id { get; set; }
        public string nombresContacto { get; set; }
        public string ApellidosContacto { get; set; }
        public string cargoContacto { get; set; }
        public string telefonoContacto { get; set; }
        public string eMailContacto { get; set; }
        public string observacion { get; set; }
        public int idProveedor { get; set; } 

        // son tareas Task
        // SaveAsync .... etc
       
    }
}
