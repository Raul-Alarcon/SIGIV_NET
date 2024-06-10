using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
            dt.Columns.Add("Total_Gastado", typeof(decimal));
            dt.Columns.Add("Numero_De_Compras", typeof(int));
            dt.Columns.Add("Producto_Comprado_Con_Frecuencia", typeof(string));
            using(DataLayer.SIGIVEntities db = new DataLayer.SIGIVEntities())
            {
                var clientes = await db.Facturas
                    .Where(f => f.fechaFactura >= fInicio && f.fechaFactura <= fFinal)
                    .GroupBy(f => f.idCliente)
                    .Select(f => new
                    {
                        idCliente = f.Key,
                        Nombre = db.Clientes.Where(c => c.IDCliente == f.Key).Select(c => c.nombresCliente).FirstOrDefault(),
                        Total_Gastado = f.Sum(x => x.TransaccionesPago.Sum(y => y.monto)),
                        Numero_De_Compras = f.Count(),
                        Producto_Comprado_Con_Frecuencia = f.SelectMany(x => x.DetallesFacturas)
                            .GroupBy(x => x.idProducto)
                            .OrderByDescending(x => x.Count())
                            .Select(x => x.Key)
                            .FirstOrDefault()
                    })
                    .OrderByDescending(f => f.Total_Gastado)
                    .Take(10)
                    .ToListAsync();


                foreach (var cliente in clientes)
                {
                    var clienteFrecuente = await db.Clientes
                        .FindAsync(cliente.idCliente);

                    var productoFrecuente = await db.Facturas
                        .Where(x => x.idCliente == cliente.idCliente)
                        .GroupBy(x => x.DetallesFacturas.FirstOrDefault().idProducto)
                        .Select(x => new 
                            { 
                                idProducto = x.Key, 
                                Cantidad = x.Sum(y => y.DetallesFacturas.Sum(z => z.cantidad)) 
                            })
                        .OrderByDescending(x => x.Cantidad)
                        .FirstOrDefaultAsync();

                    if(productoFrecuente.idProducto > 0)
                    {
                        var producto = await db.Productos
                            .FindAsync(productoFrecuente.idProducto);

                        dt.Rows.Add(clienteFrecuente.nombresCliente, $"{cliente.Total_Gastado}", cliente.Numero_De_Compras, producto.nombreP);
                    }
                     

                }
            }
            return dt;
        }

    }
}
