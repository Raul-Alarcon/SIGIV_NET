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
    public class DetallesStockCLS
    {
        public int id { get; set; }
        public int cantidad { get; set; }
        public string descripcion { get; set; }

        public static async Task<List<DestallesStockDTO>> GetAllDTOAsync()
        {
            List<DestallesStockDTO> detallesStock = new List<DestallesStockDTO>();
            using(var db = new SIGIVEntities())
            {
                detallesStock = await (from detalleStock in db.DetallesStok
                                       join stock in db.DetallesStok on detalleStock.idStok equals stock.idStok
                                       select new DestallesStockDTO
                                       {
                                           ID = detalleStock.idStok,
                                           Cantidad = (int)detalleStock.cantidadStok,
                                           Descripcion = stock.descripcion
                                       }).ToListAsync();
            }
            return detallesStock;
        }

        public static async Task<DetallesStockCLS> GetByIdAsync(int id)
        {
            DetallesStockCLS detalleStock = new DetallesStockCLS();
            using(var db = new SIGIVEntities())
            {
                DetallesStok det = await db.DetallesStok.Where(x => x.idStok == id).FirstOrDefaultAsync();
                detalleStock.id = det.idStok;
                detalleStock.cantidad = (int)det.cantidadStok;
                detalleStock.descripcion = det.descripcion;
            }
            return detalleStock;
        }

        public async Task<bool> SaveAsync()
        {
            bool success = false;
            using(var db = new SIGIVEntities())
            {
                DetallesStok detalleStock = new DetallesStok
                {
                    cantidadStok = cantidad,
                    descripcion = descripcion
                };
                db.DetallesStok.Add(detalleStock);
                int resultado = await db.SaveChangesAsync();
                success = resultado > 0;
            }
            return success;
        }

        public async Task<bool> UpdateAsync()
        {
            bool success = false;
            using(var db = new SIGIVEntities())
            {
                DetallesStok detalleStock = db.DetallesStok.Where(x => x.idStok == id).FirstOrDefault();
                detalleStock.cantidadStok = cantidad;
                detalleStock.descripcion = descripcion;
                db.Entry(detalleStock).State = EntityState.Modified;
                int resultado = await db.SaveChangesAsync();
                success = resultado > 0;
            }
            return success;
        }

        public async Task<bool> DeleteAsync()
        {
            bool success = false;
            using(var db = new SIGIVEntities())
            {
                DetallesStok detalleStock = db.DetallesStok.Where(x => x.idStok == id).FirstOrDefault();
                db.DetallesStok.Remove(detalleStock);
                int resultado = await db.SaveChangesAsync();
                success = resultado > 0;
            }
            return success;
        }

        public void Validar()
        {
            if (cantidad < 0)throw new ArgumentException("La cantidad no puede ser menor a 0");
            if (string.IsNullOrWhiteSpace(descripcion)) throw new ArgumentException("La descripción no puede estar vacía");
        }
    }
}
