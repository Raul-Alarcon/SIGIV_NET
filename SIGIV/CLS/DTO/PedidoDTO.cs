using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS.DTO
{
    public class PedidoDTO
    {
        public int Id { get; set; }
        public string Proveedor { get; set; }
        public DateTime Fecha_Pedido { get; set; }
        public string Estado { get; set; }
    }
}
