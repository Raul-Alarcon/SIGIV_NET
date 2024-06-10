using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS.DTO.Reportes
{
    public class ComprasReporte
    {
        //public int idFactura { get; set; }
        //public string Cliente { get; set; }
        //public DateTime fechaFactura { get; set; }
        public string nombreProducto { get; set; }
        public int cantidad { get; set; }
        public string precio1 { get; set; }
        public string subTotal { get; set; }

        public static async Task<DataTable> GetDataSource(int n)
        {
            DataTable reporte = new DataTable();
            reporte.Columns.Add("nombreProducto", typeof(string));
            reporte.Columns.Add("cantidad", typeof(int));
            reporte.Columns.Add("precio1", typeof(string));
            reporte.Columns.Add("subTotal", typeof(string));

            using(DataLayer.SIGIVEntities db = new DataLayer.SIGIVEntities())
            {
                var facturas = await db.Facturas.Where(x => x.idFactura == n).ToListAsync();
                foreach (var factura in facturas)
                {
                    var detalles = await db.DetallesFacturas.Where(x => x.idFactura == n).ToListAsync();
                    foreach (var detalle in detalles)// si trae los detalles
                    {
                        var producto = db.Productos.Find(detalle.idProducto);
                        reporte.Rows.Add(producto.nombreP, detalle.cantidad, $"{producto.precio}", $"{detalle.cantidad * producto.precio}");
                    }
                }
            }
            return reporte;
        }
    }
}
