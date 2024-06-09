using SIGIV.CLS.DTO;
using SIGIV.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public async static Task<List<FacturaDTO>> GetAsync()
        {
            List<FacturaDTO> facturas = new List<FacturaDTO>();
            using (var db = new SIGIVEntities())
            {
                facturas = await (from factura in db.Facturas
                            join cliente in db.Clientes on factura.idCliente equals cliente.IDCliente
                            join empleado in db.Empleados on factura.idEmpleado equals empleado.idEmpleado
                            select new FacturaDTO
                            {
                                Id = factura.idFactura,
                                Fecha = (DateTime)factura.fechaFactura,
                                Cliente = cliente.nombresCliente + " " + cliente.apellidosCliente,
                                Empleado = empleado.nombresEmpleado + " " + empleado.apellidosEmpleado
                            }).ToListAsync();
            }

            return facturas;
        }

        public async Task<List<ProductoFacturaDTO>> GetAllProductosAsync()
        {
            List<ProductoFacturaDTO> productos = new List<ProductoFacturaDTO>();
            using (var db = new SIGIVEntities())
            {
                productos = await (from detalle in db.DetallesFacturas
                                   join producto in db.Productos on detalle.idProducto equals producto.idProducto
                                   where detalle.idFactura == this.id
                                   select new ProductoFacturaDTO
                                   {
                                       ID = producto.idProducto,
                                       Producto = producto.nombreP,
                                       Precio = (decimal)producto.precio,
                                       Cantidad = (int)detalle.cantidad,
                                   }).ToListAsync();
            }

            return productos;
        }

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


                        var ctualProduct = db.Productos.Find(producto.ID);
                        ctualProduct.DetallesStok.cantidadStok -= producto.Cantidad;
                        db.Entry(ctualProduct).State = System.Data.Entity.EntityState.Modified; 

                    });

                    result = await db.SaveChangesAsync();



                    success = result > 0;
                }
            }

            return success;
        }
    }
}
