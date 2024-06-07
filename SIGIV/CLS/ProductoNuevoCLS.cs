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
    public class ProductoNuevoCLS
    {
        public int id { get; set; }
        public string nombreP { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int idCategoria { get; set; }

        public static async Task<List<ProductoNuevoDTO>> GetAllAsync()
        {
            List<ProductoNuevoDTO> productos = new List<ProductoNuevoDTO>();
            using (SIGIVEntities db = new SIGIVEntities())
            {
                productos = await (from pro in db.ProductosNuevos
                                   join cat in db.CategoriasProductos on pro.idCategoria equals cat.idCategoria
                                   select new ProductoNuevoDTO
                                   {
                                       ID = pro.idProductoNuevo,
                                       NombreP = pro.nombreP,
                                       Descripcion = pro.descripcion,
                                       Precio = (decimal)pro.precio,
                                       Categoria = cat.categoria
                                   }).ToListAsync();
            }
            return productos;
        }

        public static async Task<ProductoNuevoCLS> GetByIDAsync(int idProducto)
        {
            ProductoNuevoCLS producto = new ProductoNuevoCLS();
            using (SIGIVEntities db = new SIGIVEntities())
            {
                DataLayer.ProductosNuevos pro = await db.ProductosNuevos
                    .Where(x => x.idProductoNuevo == idProducto).FirstOrDefaultAsync();
                producto.id = pro.idProductoNuevo;
                producto.nombreP = pro.nombreP;
                producto.descripcion = pro.descripcion;
                producto.precio = (decimal)pro.precio;
                producto.idCategoria = (int)pro.idCategoria;

            }
            return producto;
        }

        public async Task<bool> AddAsync()
        {
            bool suscess = false;
            using (SIGIVEntities db = new SIGIVEntities())
            {
                DataLayer.ProductosNuevos pron = new DataLayer.ProductosNuevos
                {
                    nombreP = nombreP,
                    descripcion = descripcion,
                    precio = precio,
                    idCategoria = idCategoria,
                };
                db.ProductosNuevos.Add(pron);
                suscess = await db.SaveChangesAsync() > 0;
            }
            return suscess;
        }

        public async Task<bool> UpdateAsync()
        {
            bool suscess = false;
            using (SIGIVEntities db = new SIGIVEntities())
            {
                DataLayer.ProductosNuevos pro = await db.ProductosNuevos
                    .Where(x => x.idProductoNuevo == id).FirstOrDefaultAsync();
                pro.nombreP = nombreP;
                pro.descripcion = descripcion;
                pro.precio = precio;
                pro.idCategoria = idCategoria;
                suscess = await db.SaveChangesAsync() > 0;
            }
            return suscess;
        }

        public async static Task<bool> DeleteAsync(int idProducto)
        {
            bool suscess = false;
            using (SIGIVEntities db = new SIGIVEntities())
            {
                DataLayer.ProductosNuevos pro = await db.ProductosNuevos
                    .Where(x => x.idProductoNuevo == idProducto).FirstOrDefaultAsync();
                db.ProductosNuevos.Remove(pro);
                suscess = await db.SaveChangesAsync() > 0;
            }
            return suscess;
        }
    }
}
