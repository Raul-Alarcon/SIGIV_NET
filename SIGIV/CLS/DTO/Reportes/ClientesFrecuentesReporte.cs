using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS.DTO.Reportes
{
    public class ClientesFrecuentesReporte
    {
        public string Nombre { get; set; }
        public string Total_Gastado { get; set; }
        public int Numero_De_Compras { get; set; }
        public string Producto_Comprado_Con_Frecuencia { get; set; }

        public async static Task<DataTable> GetDataSource(DateTime fInicio, DateTime fFinal)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Total_Gastado", typeof(string));
            dt.Columns.Add("Numero_De_Compras", typeof(int));
            dt.Columns.Add("Producto_Comprado_Con_Frecuencia", typeof(string));
            using(DataLayer.SIGIVEntities db = new DataLayer.SIGIVEntities())
            {
                var clientes = db.Facturas.Where(x => x.fechaFactura >= fInicio && x.fechaFactura <= fFinal).GroupBy(x => x.idCliente).Select(x => new { idCliente = x.Key, Total_Gastado = x.Sum(y => y.DetallesFacturas.Sum(z => z.Productos.precio)), Numero_De_Compras = x.Count() }).OrderByDescending(x => x.Total_Gastado).Take(10).ToList();
                foreach (var cliente in clientes)
                {
                    var clienteFrecuente = db.Clientes.Find(cliente.idCliente);
                    var productoFrecuente = db.Facturas.Where(x => x.idCliente == cliente.idCliente).GroupBy(x => x.DetallesFacturas.FirstOrDefault().idProducto).Select(x => new { idProducto = x.Key, Cantidad = x.Sum(y => y.DetallesFacturas.Sum(z => z.cantidad)) }).OrderByDescending(x => x.Cantidad).FirstOrDefault();
                    dt.Rows.Add(clienteFrecuente.nombresCliente, $"{cliente.Total_Gastado}", cliente.Numero_De_Compras, db.Productos.Find(productoFrecuente.idProducto).nombreP);
                }
            }
            return dt;

        }
    }
}
