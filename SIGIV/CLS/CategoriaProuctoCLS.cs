using SIGIV.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS
{
    internal class CategoriaProuctoCLS
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string detalles { get; set; }

        public async Task<List<CategoriaProuctoCLS>> GetAllAsync()
        {
            List<CategoriaProuctoCLS> categoriaProuctos;
            using (var db = new SIGIVEntities())
            {
                categoriaProuctos = await (from CategoriasProucto in db.CategoriasProductos
                                           select new CategoriaProuctoCLS
                                                                                     {
                                               Id = CategoriasProucto.idCategoria,
                                               Nombre = CategoriasProucto.categoria,
                                               detalles = CategoriasProucto.detalles
                                           }).ToListAsync();
            }
            return categoriaProuctos;
        }

        public async Task<bool> SaveAsync()
        {
            bool success = false;
            using (var db = new SIGIVEntities())
            {
                CategoriasProductos categoriasProuctos = new CategoriasProductos
                {
                    categoria = Nombre,
                    detalles = detalles
                };
                db.CategoriasProductos.Add(categoriasProuctos);
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
                CategoriasProductos CategoriasProductos = db.CategoriasProductos.Where(x => x.idCategoria == Id).FirstOrDefault();
                CategoriasProductos.categoria = Nombre;
                CategoriasProductos.detalles = detalles;
                db.Entry(CategoriasProductos).State = EntityState.Modified;
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
                CategoriasProductos categoriasProductos = db.CategoriasProductos.Where(x => x.idCategoria == Id).FirstOrDefault();
                db.CategoriasProductos.Remove(categoriasProductos);
                int resultado = await db.SaveChangesAsync();
                success = resultado > 0;
            }
            return success;
        }

        public void validar()
        {
            if (string.IsNullOrEmpty(Nombre))throw new Exception("El nombre de la categoria es requerido");
        }
    }
}
