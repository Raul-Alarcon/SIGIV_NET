using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SIGIV.CLS.DTO.Reportes
{
    public class VentasMensualesReporte
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public string Precio { get; set; }
        public string Categoria { get; set; }
        public string total { get; set; }

        public static async Task<DataTable> GetDataSourse(DateTime fInicio, DateTime fFinal)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Cantidad", typeof(int));
            dt.Columns.Add("Precio", typeof(string));
            dt.Columns.Add("Categoria", typeof(string));
            dt.Columns.Add("Total", typeof(string));
            using (DataLayer.SIGIVEntities db = new DataLayer.SIGIVEntities())
            { 
                var ventas = await db.Facturas
                    .Where(f => f.fechaFactura >= fInicio && f.fechaFactura <= fFinal)
                    .SelectMany(f => f.DetallesFacturas)
                    .GroupBy(f => f.Productos)
                    .Select(f => new
                    {
                        Nombre = f.Key.nombreP,
                        Cantidad = f.Sum(x => x.cantidad),
                        Precio = f.Key.precio,
                        Categoria = f.Key.CategoriasProductos.categoria,
                        Total = f.Sum(x => x.cantidad * x.Productos.precio)
                    })
                    .OrderByDescending(f => f.Total)
                    .ToListAsync();

                foreach (var venta in ventas)
                {
                    dt.Rows.Add(venta.Nombre, venta.Cantidad, venta.Precio, venta.Categoria, venta.Total);
                }
            }
            return dt;
        }

    }
}
