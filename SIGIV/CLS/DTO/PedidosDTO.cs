
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS.DTO
{
    internal class PedidosDTO
    {
        public int ID { get; set; }
        public int Proveedor { get; set; }
        public DateTime Pedido { get; set; }
        public DateTime Recibido { get; set; }
        public string comentario { get; set; }
    }
}
