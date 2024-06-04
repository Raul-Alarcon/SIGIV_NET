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
    internal class PedidosCLS
    {
        public int id { get; set; }
        public int proveedor { get; set; }
        public DateTime pedidoFecha { get; set; }
        public DateTime fechaRecibido { get; set; }
        public string comentario { get; set; }

        public static async Task<List<PedidosDTO>> GetAllAsync()
        {
            List<PedidosDTO> pedidos = new List<PedidosDTO>();
            using (SIGIVEntities db = new SIGIVEntities())
            {
                pedidos = await (from ped in db.Pedidos
                                 select new PedidosDTO
                                 {
                                     ID = ped.idPedido,
                                     Proveedor = ped.idProveedor,
                                     Pedido = ped.fechaPedido,
                                     Recibido = ped.fechaRecibido,
                                     comentario = ped.comentario
                                 }).ToListAsync();
            }
            return pedidos;
        }

        public static async Task<PedidosCLS> GetByIDAsync(int idPedido)
        {
            PedidosCLS pedido = new PedidosCLS();
            using (SIGIVEntities db = new SIGIVEntities())
            {
                DataLayer.Pedidos ped = await db.Pedidos.Where(x => x.idPedido == idPedido).FirstOrDefaultAsync();
                pedido.id = ped.idPedido;
                pedido.proveedor = ped.idProveedor;
                pedido.pedidoFecha = ped.fechaPedido;
                pedido.fechaRecibido = ped.fechaRecibido;
                pedido.comentario = ped.comentario;
            }
            return pedido;
        }

        public async Task<bool> AddAsync()
        {
            bool success = false;
            using (SIGIVEntities db = new SIGIVEntities())
            {
                DataLayer.Pedidos ped = new DataLayer.Pedidos();
                ped.idProveedor = this.proveedor;
                ped.fechaPedido = this.pedidoFecha;
                ped.fechaRecibido = this.fechaRecibido;
                ped.comentario = this.comentario;
                db.Pedidos.Add(ped);
                success = await db.SaveChangesAsync() > 0;
            }
            return success;
        }

        public async Task<bool> UpdateAsync()
        {
            bool success = false;
            using (SIGIVEntities db = new SIGIVEntities())
            {
                DataLayer.Pedidos ped = await db.Pedidos.Where(x => x.idPedido == this.id).FirstOrDefaultAsync();
                ped.idProveedor = this.proveedor;
                ped.fechaPedido = this.pedidoFecha;
                ped.fechaRecibido = this.fechaRecibido;
                ped.comentario = this.comentario;
                success = await db.SaveChangesAsync() > 0;
            }
            return success;
        }

        public async Task<bool> DeleteAsync(int idPedido)
        {
            bool success = false;
            using (SIGIVEntities db = new SIGIVEntities())
            {
                DataLayer.Pedidos ped = await db.Pedidos.Where(x => x.idPedido == idPedido).FirstOrDefaultAsync();
                db.Pedidos.Remove(ped);
                success = await db.SaveChangesAsync() > 0;
            }
            return success;
        }
    }
}
