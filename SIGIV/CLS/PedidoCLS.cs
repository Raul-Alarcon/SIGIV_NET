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
    public  class PedidoCLS
    {
        public int idPedido { get; set; }
        public int idProveedor { get; set; }
        public DateTime fechaPedido { get; set; }
        public DateTime fechaRecibido { get; set; }
        public string comentario { get; set; }

        public List<ProductoFacturaDTO> productos = new List<ProductoFacturaDTO>();

        public async static Task<List<PedidoDTO>> GetAsync()
        {
            List<PedidoDTO> pedidos = new List<PedidoDTO>();
            using (SIGIVEntities db = new SIGIVEntities())
            {
                pedidos = await (from ped in db.Pedidos
                                 select new PedidoDTO
                                 {
                                     Id = ped.idPedido,
                                     Proveedor = ped.Proveedores.compania,
                                     Fecha_Pedido = (DateTime) ped.fechaPedido,
                                     Estado = ped.fechaRecibido  == null ? "Pendiente" : "Procesada"
                                 }).ToListAsync();
            }
            return pedidos;
        }

        public async static Task<PedidoDTO> GetByIDAsync(int idPedido)
        {
            PedidoDTO pedido = new PedidoDTO();
            using (SIGIVEntities db = new SIGIVEntities())
            {
                pedido = await (from ped in db.Pedidos
                                 where ped.idPedido == idPedido
                                 select new PedidoDTO
                                 {
                                     Id = ped.idPedido,
                                     Proveedor = ped.Proveedores.compania,
                                     Fecha_Pedido = (DateTime) ped.fechaPedido,
                                     Estado = ped.fechaRecibido as DateTime? == null ? "Pendiente" : "Procesada"
                                 }).FirstOrDefaultAsync();
            }
            return pedido;
        }

        public async Task<bool> SaveAsync()
        {
            bool result = false;
            using (SIGIVEntities db = new SIGIVEntities())
            {
                Pedidos pedido = new Pedidos
                {
                    idProveedor = this.idProveedor,
                    fechaPedido = this.fechaPedido,
                    fechaRecibido = this.fechaRecibido,
                    comentario = this.comentario
                };
                db.Pedidos.Add(pedido);
                result = await db.SaveChangesAsync() > 0;
            }
            return result;
        }

        public async Task<bool> UpdateAsync()
        {
            bool result = false;
            using (SIGIVEntities db = new SIGIVEntities())
            {
                Pedidos pedido = await db.Pedidos.Where(x => x.idPedido == this.idPedido).FirstOrDefaultAsync();
                pedido.idProveedor = this.idProveedor;
                pedido.fechaPedido = this.fechaPedido;
                pedido.fechaRecibido = this.fechaRecibido;
                pedido.comentario = this.comentario;
                result = await db.SaveChangesAsync() > 0;
            }
            return result;
        }

        public async static Task<bool> DeleteAsync(int idPedido)
        {
            bool result = false;
            using (SIGIVEntities db = new SIGIVEntities())
            { 
                Pedidos pedido = await db.Pedidos.Where(x => x.idPedido == idPedido).FirstOrDefaultAsync();
                db.Pedidos.Remove(pedido);
                result = await db.SaveChangesAsync() > 0;
            }
            return result;
        }

        public async Task<bool> DeleteAsync()
        { 
            return await DeleteAsync(this.idPedido);
        }

        public async Task<bool> HacerPedidoAsync()
        {
            bool result = false;
            using (SIGIVEntities db = new SIGIVEntities())
            { 
                Pedidos pedido = new Pedidos
                {
                    idProveedor = this.idProveedor,
                    fechaPedido = this.fechaPedido,
                    fechaRecibido = null,
                    comentario = this.comentario
                };
                db.Pedidos.Add(pedido);
                result = await db.SaveChangesAsync() > 0;
                if (result)
                {
                    foreach (var producto in productos)
                    {
                        bool existe = await db.Productos.Where(x => x.nombreP == producto.Producto).AnyAsync();

                        ProductosNuevos productoNuevo = new ProductosNuevos
                        {
                            nombreP = producto.Producto,
                            precio = producto.Precio,
                            descripcion =  existe ? "Producto ya existente" : "Producto nuevo",
                        };

                        db.ProductosNuevos.Add(productoNuevo);
                        bool succes = await db.SaveChangesAsync() > 0;

                        if (succes)
                        {
                            DetallesPedidos detalle = new DetallesPedidos
                            {
                                idPedido = pedido.idPedido,
                                idProductoNuevo = productoNuevo.idProductoNuevo,
                                cantidad = producto.Cantidad,
                                precioUnidad = producto.Precio
                            };
                            db.DetallesPedidos.Add(detalle);
                            await db.SaveChangesAsync();
                        }

                       
                    } 
                }
            }
            return result;
        }

        public async Task<bool> RecibirPedidoAsync()
        {
            bool result = false;
            using (SIGIVEntities db = new SIGIVEntities())
            {
                Pedidos pedido = await db.Pedidos.Where(x => x.idPedido == this.idPedido).FirstOrDefaultAsync();
                pedido.fechaRecibido = DateTime.Now;
                result = await db.SaveChangesAsync() > 0;
            }
            return result;
        }


        public async static Task<List<ProductoFacturaDTO>> GetProductosAsync(int id)
        {
            List<ProductoFacturaDTO> productos = new List<ProductoFacturaDTO>();
            using (SIGIVEntities db = new SIGIVEntities())
            {
                productos = await (from det in db.DetallesPedidos
                                   where det.idPedido == id
                                   select new ProductoFacturaDTO
                                   {
                                       ID = (int)det.idProductoNuevo,
                                       Producto = det.ProductosNuevos.nombreP,
                                       Precio = (decimal)det.precioUnidad,
                                       Cantidad = (int)det.cantidad
                                   }).ToListAsync();
            }
            return productos;
        }

        public async Task<List<ProductoFacturaDTO>> GetProductosAsync()
        { 
            using (SIGIVEntities db = new SIGIVEntities())
            {
                productos = await (from det in db.DetallesPedidos
                                   where det.idPedido == this.idPedido
                                   select new ProductoFacturaDTO
                                   {
                                       ID = (int)det.idProductoNuevo,
                                       Producto = det.ProductosNuevos.nombreP,
                                       Precio = (decimal) det.precioUnidad,
                                       Cantidad = (int) det.cantidad
                                   }).ToListAsync();
            }
            return productos;
        }

        public async Task<bool> ProcesarProductos()
        {
            bool result = false;
            using (SIGIVEntities db = new SIGIVEntities())
            {
                foreach (var producto in productos)
                {
                    var _producto = await db.Productos
                           .Where(x => x.nombreP ==  producto.Producto)
                           .Select(x =>  x.DetallesStok)
                            .FirstOrDefaultAsync();

                    var stock = await db.DetallesStok
                        .Where(x => x.idStok == _producto.idStok)
                        .FirstOrDefaultAsync();

                    if (stock != null)
                    { 
                        stock.cantidadStok += producto.Cantidad; 
                    }
                }
                result = await db.SaveChangesAsync() > 0;
            }
            return result;
        }

    }
}
