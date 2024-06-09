using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS
{
    public class FormasDePagoCLS
    {
        public int id { get; set; }
        public string tipo { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(this.tipo))
            {
                throw new ArgumentException("El campo tipo es requerido");
            }
        }

        public async static Task<List<FormasDePagoCLS>> GetAsync()
        {
            List<FormasDePagoCLS> formas = new List<FormasDePagoCLS>();
            using (var db = new DataLayer.SIGIVEntities())
            {
                formas = await (from forma in db.TiposPago
                          select new FormasDePagoCLS
                          {
                              id = forma.idTipoPago,
                              tipo = forma.tipo
                          }).ToListAsync();
            }
            return formas;
        }


        public async Task<bool> SaveAsync()
        {
            bool success = false;
            using (var db = new DataLayer.SIGIVEntities())
            {
                DataLayer.TiposPago forma = new DataLayer.TiposPago
                {
                    tipo = this.tipo
                };
                db.TiposPago.Add(forma);
                int result = await db.SaveChangesAsync();
                success = true;
            }
            return success;
        }

        public async Task<bool> UpdateAsync()
        {
            bool success = false;
            using (var db = new DataLayer.SIGIVEntities())
            {
                DataLayer.TiposPago forma = db.TiposPago.Where(x => x.idTipoPago == this.id).FirstOrDefault();
                forma.tipo = this.tipo;
                int result = await db.SaveChangesAsync();
                success = true;
            }
            return success;
        }

        public async Task<bool> DeleteAsync()
        {
            bool success = false;
            using (var db = new DataLayer.SIGIVEntities())
            {
                DataLayer.TiposPago forma = db.TiposPago.Where(x => x.idTipoPago == this.id).FirstOrDefault();
                db.TiposPago.Remove(forma);
                int result = await db.SaveChangesAsync();
                success = true;
            }
            return success;
        }
    }
}
