using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS.DTO
{
    public class EmpleadoDTO
    {
        public int ID { get; set; }
        public string Nombres { get; set; } 
        public string DUI { get; set; }
        public string ISSS{ get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Cargo { get; set; }
        public System.DateTime FechaNacimiento { get; set; }

    }
}
