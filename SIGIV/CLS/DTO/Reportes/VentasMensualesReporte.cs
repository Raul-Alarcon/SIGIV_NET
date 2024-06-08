using SIGIV.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
            var ventas = db.Facturas.Where(x => x.fechaFactura >= fInicio && x.fechaFactura <= fFinal).SelectMany(x => x.DetallesFacturas).GroupBy(x => x.Productos).Select(x => new { Producto = x.Key, Cantidad = x.Sum(y => y.cantidad), Precio = x.Key.precio, Categoria = x.Key.CategoriasProductos.categoria }).ToList();
                foreach (var venta in ventas)
                {
                    dt.Rows.Add(venta.Producto.nombreP, venta.Cantidad, $"{venta.Precio}", venta.Categoria, $"{venta.Cantidad * venta.Precio}");
                }
            }
            return dt;
        }

    }
}
