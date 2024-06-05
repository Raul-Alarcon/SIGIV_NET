using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS
{
    public class ContactoProveedorCLS
    {
        public int id { get; set; }
        public string nombresContacto { get; set; }
        public string ApellidosContacto { get; set; }
        public string cargoContacto { get; set; }
        public string telefonoContacto { get; set; }
        public string eMailContacto { get; set; }
        public string observacion { get; set; }
        public int idProveedor { get; set; } 

        // son tareas Task
        // SaveAsync .... etc
        public async Task<bool> SaveAsync()
        {
            using (DataLayer.SIGIVEntities db = new DataLayer.SIGIVEntities())
            {
                DataLayer.ContactosProveedor contacto = new DataLayer.ContactosProveedor();
                contacto.idProveedor = idProveedor;
                contacto.nombresContacto = nombresContacto;
                contacto.ApellidosContacto = ApellidosContacto;
                contacto.cargoContacto = cargoContacto;
                contacto.telefonoContacto = telefonoContacto;
                contacto.eMailContacto = eMailContacto;
                contacto.observacion = observacion;
                db.ContactosProveedor.Add(contacto);
                await db.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> UpdateAsync()
        {
            using (DataLayer.SIGIVEntities db = new DataLayer.SIGIVEntities())
            {
                DataLayer.ContactosProveedor contacto = await db.ContactosProveedor
                        .Where(x => x.idContacto == id)
                            .FirstOrDefaultAsync();

                contacto.idProveedor = idProveedor;
                contacto.nombresContacto = nombresContacto;
                contacto.ApellidosContacto = ApellidosContacto;
                contacto.cargoContacto = cargoContacto;
                contacto.telefonoContacto = telefonoContacto;
                contacto.eMailContacto = eMailContacto;
                contacto.observacion = observacion;
                await db.SaveChangesAsync();
            }
            return true;
        }

        public void validar()
        {
            if (string.IsNullOrEmpty(nombresContacto))
            {
                throw new ArgumentException("El campo nombres es obligatorio");
            }
            if (string.IsNullOrEmpty(ApellidosContacto))
            {
                throw new ArgumentException("El campo apellidos es obligatorio");
            }
            if (string.IsNullOrEmpty(cargoContacto))
            {
                throw new ArgumentException("El campo cargo es obligatorio");
            }
            if (string.IsNullOrEmpty(telefonoContacto))
            {
                throw new ArgumentException("El campo telefono es obligatorio");
            }
            if (string.IsNullOrEmpty(eMailContacto))
            {
                throw new ArgumentException("El campo eMail es obligatorio");
            }
        }
    }
}
