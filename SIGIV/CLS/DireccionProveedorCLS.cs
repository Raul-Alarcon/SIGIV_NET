using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS
{
    public class DireccionProveedorCLS
    {
        public int id { get; set; }
        public string Linea1 { get; set; }
        public string Linea2 { get; set; }
        public int idProveedor { get; set; }
        public int idDireccion { get; set; }

        public int codigoPostal { get; set; } 


       public async Task<bool> SaveAsync()
       {
            using (DataLayer.SIGIVEntities db = new DataLayer.SIGIVEntities())
            {
                DataLayer.ProveedoresDireccion direccion = new DataLayer.ProveedoresDireccion();
                direccion.idDireccion = idDireccion;
                direccion.idProveedor = idProveedor;
                direccion.Linea1 = Linea1;
                direccion.Linea2 = Linea2;
                db.ProveedoresDireccion.Add(direccion);
                await db.SaveChangesAsync();
            }
            return true;
       }

       public async Task<bool> UpdateAsync()
       {
            using (DataLayer.SIGIVEntities db = new DataLayer.SIGIVEntities())
            {
                DataLayer.ProveedoresDireccion direccion = await db.ProveedoresDireccion
                        .Where(x => x.idDireccion == idDireccion)
                            .FirstOrDefaultAsync();

                direccion.idDireccion = idDireccion;
                direccion.idProveedor = idProveedor;
                direccion.Linea1 = Linea1;
                direccion.Linea2 = Linea2;
                await db.SaveChangesAsync();
            }
            return true;
       }
    }
}
