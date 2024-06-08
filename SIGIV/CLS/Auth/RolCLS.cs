using Microsoft.SqlServer.Server;
using SIGIV.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS.Auth
{
    public  class RolCLS
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(nombre)) throw new ArgumentException("El nombre del rol es requerido");
        }

        public async static Task<List<RolCLS>> GetAsync()
        {
            List<RolCLS> roles = new List<RolCLS>();
            using (var db = new SIGIVEntities())
            {
                roles = await (from rol in db.Roles
                               select new RolCLS
                               {
                                   id = rol.idRol,
                                   nombre = rol.nombreRol
                               }).ToListAsync();
            }
            return roles;
        }

        public static async Task<RolCLS> GetByIdAsync(int id) 
        {
            RolCLS rol = null;
            using(var db = new SIGIVEntities())
            {
                rol = await db.Roles.Where(x => x.idRol == id).Select(x => new RolCLS
                {
                    id = x.idRol,
                    nombre = x.nombreRol
                }).FirstOrDefaultAsync();
            }
            return rol;
        }


        public async Task<bool> SaveAsync()
        {
            bool result = false;
            using (var db = new SIGIVEntities())
            {
                Roles rol = new Roles();
                rol.nombreRol = this.nombre;
                db.Roles.Add(rol);
                await db.SaveChangesAsync();
                if (rol.idRol > 0)
                {
                    this.id = rol.idRol;
                    result = true;
                }
            }
            return result;
        }

        public async Task<bool> UpdateAsync()
        {
            bool result = false;
            using (var db = new SIGIVEntities())
            {
                Roles rol = db.Roles.Where(x => x.idRol == this.id).FirstOrDefault();
                if (rol != null)
                {
                    rol.nombreRol = this.nombre;
                    await db.SaveChangesAsync();
                    result = true;
                }
            }
            return result;
        }
    }
}
