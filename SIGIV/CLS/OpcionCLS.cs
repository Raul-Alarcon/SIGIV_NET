using SIGIV.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS
{
    internal class OpcionCLS
    {
        public int id { get; set; }
        public string opcion { get; set; }

        public static async Task<List<OpcionCLS>> GetALLAsync()
        {
            List<OpcionCLS> opciones = new List<OpcionCLS>();
            using (var db = new SIGIVEntities())
            {
                opciones = await (from opcion in db.Opciones
                                  select new OpcionCLS
                                  {
                                      id = opcion.idOpcion,
                                      opcion = opcion.opcion
                                  }).ToListAsync();
            }
            return opciones;
        }

        public async static Task<List<OpcionCLS>> GetOpcionesAsignadasByRol(int idRol)
        {
            List<OpcionCLS> opcion = new List<OpcionCLS>();
            using (var db = new SIGIVEntities())
            {
                opcion = await (from rolOpcion in db.AsignacionRolesOpciones
                                join opciones in db.Opciones on rolOpcion.idOpcion equals opciones.idOpcion
                                where rolOpcion.idRol == idRol
                                select new OpcionCLS
                                {
                                    id = opciones.idOpcion,
                                    opcion = opciones.opcion
                                }).ToListAsync();
            }
            return opcion;
        }

        public async Task<bool> QuitarOpcionAsignadoByIdRol(int idRol)
        {
            bool success = false;
            using (var db = new SIGIVEntities())
            {
                AsignacionRolesOpciones asignacion = db.AsignacionRolesOpciones.Where(x => x.idRol == idRol && x.idOpcion == id).FirstOrDefault();
                db.AsignacionRolesOpciones.Remove(asignacion);
                int result = await db.SaveChangesAsync();
                success = result > 0;
            }
            return success;
        }


        public async Task<bool> SaveAsync()
        {
            bool success = false;
            using (var db = new SIGIVEntities())
            {
                Opciones opciones = new Opciones
                {
                    opcion = opcion
                };
                db.Opciones.Add(opciones);
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
                Opciones opciones = db.Opciones.Where(x => x.idOpcion == id).FirstOrDefault();
                opciones.opcion = opcion;
                db.Entry(opciones).State = EntityState.Modified;
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
                Opciones opciones = db.Opciones.Where(x => x.idOpcion == id).FirstOrDefault();
                db.Opciones.Remove(opciones);
                int result = await db.SaveChangesAsync();
                success = result > 0;
            }
            return success;
        }

        public async Task<bool> AsignarARol(int idRol)
        {
            bool success = false;
            using (var db = new SIGIVEntities())
            {
                AsignacionRolesOpciones asignacion = new AsignacionRolesOpciones
                {
                    idRol = idRol,
                    idOpcion = id
                };
                db.AsignacionRolesOpciones.Add(asignacion);
                int result = await db.SaveChangesAsync();
                success = result > 0;
            }
            return success;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(opcion)) throw new Exception("El campo opcion es requerido");
        }
    }
}
