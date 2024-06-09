using SIGIV.CLS.DTO;
using SIGIV.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS
{
    public class FacturaCLS
    {
        public int id { get; set; }
        public DateTime fechaFactura { get; set; }
        public string comentario { get; set; }
        public int idCliente { get; set; }
        public int idEmpleado { get; set; }
        public decimal iva { get; set; }
      
        public List<ProductoFacturaDTO> productos { get; set; }

        public async Task<bool> SaveAsync()
        {
            bool success = false;
            using(var db = new SIGIVEntities())
            {
                var factura = new Facturas
                {
                    fechaFactura = this.fechaFactura,
                    comentario = this.comentario,
                    idCliente = this.idCliente,
                    idEmpleado = this.idEmpleado,
                };

                db.Facturas.Add(factura);
                int result = await db.SaveChangesAsync();
                if (result > 0)
                {
                    productos.ForEach(producto => { 
                        var DetalleFactura = new DetallesFacturas
                        {
                            idFactura = factura.idFactura,
                            idProducto = producto.ID,
                            cantidad = producto.Cantidad, 
                            iva = this.iva,
                        };
                        db.DetallesFacturas.Add(DetalleFactura);
                    });

                    result = await db.SaveChangesAsync();
                    success = result > 0;
                }
            }

            return success;
        }
    }
}
