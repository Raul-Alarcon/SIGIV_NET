using SIGIV.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS
{
    public class DetalleFacturaCLS
    {
        public int idDetalles { get; set; }
        public int idProducto { get; set; }
        public int idFactura { get; set; }
        public int cantidad { get; set; }
        public decimal iva { get; set; }
        public decimal descuento { get; set; }

        public async Task<bool> SaveAsync()
        {
            bool success = false;
            using (SIGIVEntities db = new SIGIVEntities())
            {
                DataLayer.DetallesFacturas detalle = new DataLayer.DetallesFacturas();
                detalle.idProducto = idProducto;
                detalle.idFactura = idFactura;
                detalle.cantidad = cantidad;
                detalle.iva = iva;
                detalle.descuento = descuento;
                db.DetallesFacturas.Add(detalle);
                success = await db.SaveChangesAsync() > 0;
            }
            return success;
        }

        public async Task<bool> UpdateAsync()
        {
            bool success = false;
            using (SIGIVEntities db = new SIGIVEntities())
            {
                DetallesFacturas detalle = await db.DetallesFacturas
                    .Where(x => x.idDetalles == idDetalles)
                        .FirstOrDefaultAsync();

                detalle.idProducto = idProducto;
                detalle.idFactura = idFactura;
                detalle.cantidad = cantidad;
                detalle.iva = iva;
                detalle.descuento = descuento;
                success = await db.SaveChangesAsync() > 0;
            }
            return success;
        }

        public async Task<bool> DeleteAsync()
        {
            bool success = false;
            using (SIGIVEntities db = new SIGIVEntities())
            {
                DataLayer.DetallesFacturas detalle = await db.DetallesFacturas
                    .Where(x => x.idDetalles == idDetalles)
                    .FirstOrDefaultAsync();

                db.DetallesFacturas.Remove(detalle);
                success = await db.SaveChangesAsync() > 0;
            }
            return success;
        }
    }
}
