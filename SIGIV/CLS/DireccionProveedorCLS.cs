using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS
{
    public class DireccionProveedorCLS
    {
        public int id { get; set; }
        public string Linea1 { get; set; }
        public string Linea2 { get; set; }
        public int idProveedor { get; set; }
        public int idDireccion { get; set; }

        public string codigoPostal { get; set; }  
         
         
    }
}
