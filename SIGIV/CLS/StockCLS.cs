using SIGIV.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS
{
    public class StockCLS
    {
        public int idStok { get; set; }
        public int cantidadStok { get; set; }
        public string descripcion { get; set; }

        public async Task<StockCLS> AddAsync()
        {
            StockCLS stock = new StockCLS();
            using (SIGIVEntities db = new SIGIVEntities())
            {
                DataLayer.DetallesStok sto = new DataLayer.DetallesStok();
                sto.cantidadStok = this.cantidadStok;
                sto.descripcion = this.descripcion;
                db.DetallesStok.Add(sto);
                await db.SaveChangesAsync();
                stock.idStok = sto.idStok;
            }
            return stock;
        }

        public async Task<bool> UpdateAsync()
        {
            bool success = false;
            using (SIGIVEntities db = new SIGIVEntities())
            {
                DataLayer.DetallesStok sto = await db.DetallesStok.Where(x => x.idStok == this.idStok).FirstOrDefaultAsync();
                sto.cantidadStok = this.cantidadStok;
                sto.descripcion = this.descripcion;
                await db.SaveChangesAsync();
                success = true;
            }
            return success;
        }

        public async Task<bool> DeleteAsync()
        {
            bool success = false;
            using (SIGIVEntities db = new SIGIVEntities())
            {
                DataLayer.DetallesStok sto = await db.DetallesStok.Where(x => x.idStok == this.idStok).FirstOrDefaultAsync();
                db.DetallesStok.Remove(sto);
                await db.SaveChangesAsync();
                success = true;
            }
            return success;
        }
    }
}
