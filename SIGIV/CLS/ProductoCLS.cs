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
    internal class ProductoCLS
    {
        public int id { get; set; }
        public string producto { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int idCategoria { get; set; }
        public int idStok { get; set; }
        public int cantidadStok { get; set; }

        public static async Task<List<ProductoDTO>> GetAllAsync()
        {
            List<ProductoDTO> productos = new List<ProductoDTO>();
            using (SIGIVEntities db = new SIGIVEntities())
            {
                productos = await (from pro in db.Productos
                                   join cat in db.CategoriasProductos on pro.idCategoria equals cat.idCategoria
                                   join sto in db.DetallesStok on pro.idStok equals sto.idStok
                                   select new ProductoDTO
                                   {
                                       ID = pro.idProducto,
                                       Producto = pro.nombreP,
                                       Descripcion = pro.descripcion,
                                       Precio = pro.precio,
                                       Categoria = cat.categoria,
                                       Stok = sto.cantidadStok
                                   }).ToListAsync();
            }
            return productos;
        }

        public static async Task<ProductoCLS> GetByIDAsync(int idProducto)
        {
            ProductoCLS producto = new ProductoCLS();
            using (SIGIVEntities db = new SIGIVEntities())
            {
                DataLayer.Productos pro = await db.Productos.Where(x => x.idProducto == idProducto).FirstOrDefaultAsync();
                producto.id = pro.idProducto;
                producto.producto = pro.nombreP;
                producto.descripcion = pro.descripcion;
                producto.precio = pro.precio;
                producto.idCategoria = pro.idCategoria;
                producto.idStok = pro.idStok;
                producto.cantidadStok = pro.DetallesStok.cantidadStok;
            }
            return producto;
        }

        public async Task<bool> AddAsync()
        {
            bool success = false;
            using (SIGIVEntities db = new SIGIVEntities())
            {
                DataLayer.Productos pro = new DataLayer.Productos
                {
                    nombreP = this.producto,
                    descripcion = this.descripcion,
                    precio = this.precio,
                    idCategoria = this.idCategoria,
                    idStok = this.idStok
                };
                db.Productos.Add(pro);
                success = await db.SaveChangesAsync() > 0;
            }
            return success;
        }

        public async Task<bool> UpdateAsync()
        {
            bool success = false;
            using (SIGIVEntities db = new SIGIVEntities())
            {
                DataLayer.Productos pro = db.Productos.Where(x => x.idProducto == this.id).FirstOrDefault();
                pro.nombreP = this.producto;
                pro.descripcion = this.descripcion;
                pro.precio = this.precio;
                pro.idCategoria = this.idCategoria;
                pro.idStok = this.idStok;
                success = await db.SaveChangesAsync() > 0;
            }
            return success;
        }

        public async static Task<bool> DeleteAsync(int idProducto)
        {
            bool success = false;
            using (SIGIVEntities db = new SIGIVEntities())
            {
                DataLayer.Productos pro = db.Productos.Where(x => x.idProducto == idProducto).FirstOrDefault();
                db.Productos.Remove(pro);
                success = await db.SaveChangesAsync() > 0;
            }
            return success;
        }
    }
}
