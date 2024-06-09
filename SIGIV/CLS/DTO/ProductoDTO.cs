using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS.DTO
{
    public class ProductoDTO
    {
        public int ID{ get; set; }
        public string Producto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }
        public string Codigo { get; set; } 
        public int Stok { get; set; }

        public ProductoFacturaDTO ToProductoFacturaDTO()
        {
            return new ProductoFacturaDTO
            {
                ID = ID,
                Producto = Producto,
                Precio = Precio
            };
        }

    }
}
