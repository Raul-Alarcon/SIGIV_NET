using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS.DTO.Reportes
{
    public class InventarioActualReporte
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public string Precio { get; set; }
        public string Categoria { get; set; }
        public string Valor { get; set; }
        public static async Task<DataTable> GetDataSource()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Cantidad", typeof(int));
            dt.Columns.Add("Precio", typeof(string));
            dt.Columns.Add("Categoria", typeof(string));
            dt.Columns.Add("Valor", typeof(string));
            using (DataLayer.SIGIVEntities db = new DataLayer.SIGIVEntities())
            {
                var productos = db.Productos.ToList();
                foreach (var producto in productos)
                {
                    dt.Rows.Add(producto.nombreP, producto.DetallesStok.cantidadStok, $"{producto.precio}", producto.CategoriasProductos.categoria, $"{producto.DetallesStok.cantidadStok * producto.precio}");
                }
            }
            return dt;
        }
    }
}
