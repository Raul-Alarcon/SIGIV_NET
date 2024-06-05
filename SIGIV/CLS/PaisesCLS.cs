using SIGIV.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS
{
    internal class PaisesCLS
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public static async Task<List<PaisesCLS>> GetAllAsync()
        {
            List<PaisesCLS> paises = new List<PaisesCLS>();
            using (var db = new SIGIVEntities())
            {
                paises = await (from pais in db.Paises
                                select new PaisesCLS
                                {
                                    id = pais.idPais,
                                    nombre = pais.pais
                                }).ToListAsync();
            }
            return paises;
        }

        public async Task<bool> SaveAsync()
        {
            bool success = false;
            using (var db = new SIGIVEntities())
            {
                Paises pais = new Paises
                {
                    pais = nombre
                };
                db.Paises.Add(pais);
                int result = await db.SaveChangesAsync();
                success = result > 0;
            }
            return success;
        }

        public async Task<bool> UpdateAsync()
        {
            bool success = false;
            using (var db = new SIGIVEntities())
            {
                Paises pais = db.Paises.Where(x => x.idPais == id).FirstOrDefault();
                pais.pais = nombre;
                db.Entry(pais).State = EntityState.Modified;
                int result = await db.SaveChangesAsync();
                success = result > 0;
            }
            return success;
        }

        public async Task<bool> DeleteAsync()
        {
            bool success = false;
            using (var db = new SIGIVEntities())
            {
                Paises pais = db.Paises.Where(x => x.idPais == id).FirstOrDefault();
                db.Paises.Remove(pais);
                int result = await db.SaveChangesAsync();
                success = result > 0;
            }
            return success;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(nombre)) throw new ArgumentException("El nombre del país es requerido.");
        }
    }
}
