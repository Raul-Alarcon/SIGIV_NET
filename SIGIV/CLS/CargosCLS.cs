using SIGIV.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS
{
    public class CargosCLS
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public async Task<List<CargosCLS>> GetAllCargos()
        {
            List<CargosCLS> cargos;
            using (var db = new SIGIVEntities())
            {
                cargos = await (from cargo in db.Cargos
                                select new CargosCLS
                                {
                                    Id = cargo.idCargo,
                                    Nombre = cargo.cargo
                                }).ToListAsync();
            }
            return cargos;
        }

        public async Task<bool> SaveAsync()
        {
            bool success = false;
            using (var db = new SIGIVEntities())
            {
                Cargos cargo = new Cargos
                {
                    cargo = Nombre
                };
                db.Cargos.Add(cargo);
                int resultado = await db.SaveChangesAsync();
                success = resultado > 0;
            }
           return success;
        }

        public async Task<bool> UpdateAsync()
        {
            bool success = false;
            using (var db = new SIGIVEntities())
            {
                Cargos cargo = db.Cargos.Where(x => x.idCargo == Id).FirstOrDefault();
                cargo.cargo = Nombre;
                db.Entry(cargo).State = EntityState.Modified;
                int resultado = await db.SaveChangesAsync();
                success = resultado > 0;
            }
            return success;
        }

        public async Task<bool> DeleteAsync()
        {
            bool success = false;
            using (var db = new SIGIVEntities())
            {
                Cargos cargo = db.Cargos.Where(x => x.idCargo == Id).FirstOrDefault();
                db.Cargos.Remove(cargo);
                int resultado = await db.SaveChangesAsync();
                success = resultado > 0;
            }
            return success;
        }

        public void validar()
        {
            if (string.IsNullOrEmpty(Nombre)) throw new Exception("El nombre del cargo es requerido");
        }

    }
}
