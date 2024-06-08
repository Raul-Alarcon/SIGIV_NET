using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS
{
    public class DireccionClienteCLS
    {
        public int id { get; set; }
        public string Linea1 { get; set; }
        public string Linea2 { get; set; }
        public int idCliente { get; set; }
        public int idDireccion { get; set; }

        public string codigoPostal { get; set; }

        public async Task<bool> SaveAsync()
        {
            using (DataLayer.SIGIVEntities db = new DataLayer.SIGIVEntities())
            {
                DataLayer.ClienteDireccion direccion = new DataLayer.ClienteDireccion();
                direccion.idCliente = idCliente;
                direccion.Linea1 = Linea1;
                direccion.Linea2 = Linea2;
                direccion.codigoPostal = codigoPostal;
                db.ClienteDireccion.Add(direccion);
                await db.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> UpdateAsync()
        {
            using (DataLayer.SIGIVEntities db = new DataLayer.SIGIVEntities())
            {
                DataLayer.ClienteDireccion direccion = await db.ClienteDireccion
                        .Where(x => x.idCliente == id)
                        .FirstOrDefaultAsync();

                direccion.idCliente = idCliente;
                direccion.Linea1 = Linea1;
                direccion.Linea2 = Linea2;
                direccion.codigoPostal = codigoPostal;
                await db.SaveChangesAsync();
            }
            return true;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Linea1)) throw new Exception("La dirección es requerida");
            if (string.IsNullOrEmpty(Linea2)) throw new Exception("La dirección es requerida");
            if (string.IsNullOrEmpty(codigoPostal)) throw new Exception("El código postal es requerido");
        }
    }
}
