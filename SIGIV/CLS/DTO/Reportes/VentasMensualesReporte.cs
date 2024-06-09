using System;
using System.Data;
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
                var query = from df in db.DetallesFacturas
                            join p in db.Productos on df.idProducto equals p.idProducto
                            join c in db.CategoriasProductos on p.idCategoria equals c.idCategoria
                            join f in db.Facturas on df.idFactura equals f.idFactura
                            where f.fechaFactura >= fInicio && f.fechaFactura <= fFinal
                            select new VentasMensualesReporte
                            {
                                Nombre = p.nombreP,
                                Cantidad = df.cantidad ?? 0,
                                Precio = p.precio.ToString(),
                                Categoria = c.categoria,
                                total = (df.cantidad * p.precio).ToString()
                            };
                foreach (var item in query)
                {
                    dt.Rows.Add(item.Nombre, item.Cantidad, item.Categoria, item.Precio, item.total);
                }
    
            }
            return dt;
        }

    }
}
