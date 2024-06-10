using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS.DTO
{
    public class ProductoFacturaDTO
    {
        public int ID { get; set; }
        public string Producto { get; set; } 
        public decimal Precio { get; set; } 
        public int Cantidad { get; set; }
    }
}
