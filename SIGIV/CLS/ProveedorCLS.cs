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
    public class ProveedorCLS
    {
        public int id { get; set; }
        public string compania { get; set; }
        public string nit { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string web { get; set; }
        public string giro { get; set; }

        public static async Task<List<ProveedorDTO>> GetAllDTOAsync()
        {
            List<ProveedorDTO> proveedores = new List<ProveedorDTO>();
            using (SIGIVEntities db = new SIGIVEntities())
            {
                proveedores = await (from prov in db.Proveedores
                                     select new ProveedorDTO
                                     {
                                         ID = prov.idProveedor,
                                         Proveedor = prov.compania,
                                         NIT = prov.nit,
                                         Telefono = prov.telefonoProveedor,
                                         Correo = prov.eMailProveedor,
                                         Sitio = prov.web,
                                         Giro = prov.giro
                                     }).ToListAsync();
            }
            return proveedores;
        }

        public static async Task<ProveedorCLS> GetByIDAsync(int idProveedor)
        {
            ProveedorCLS proveedor = new ProveedorCLS();
            using (SIGIVEntities db = new SIGIVEntities())
            {
                DataLayer.Proveedores prov = await db.Proveedores.Where(x => x.idProveedor == idProveedor).FirstOrDefaultAsync();
                proveedor.id = prov.idProveedor;
                proveedor.compania = prov.compania;
                proveedor.nit = prov.nit;
                proveedor.telefono = prov.telefonoProveedor;
                proveedor.correo = prov.eMailProveedor;
                proveedor.web = prov.web;
                proveedor.giro = prov.giro;
            }
            return proveedor;
        }

        public async Task<bool> AddAsync()
        {
            bool success = false;
            using (SIGIVEntities db = new SIGIVEntities())
            {
                DataLayer.Proveedores prov = new DataLayer.Proveedores();
                prov.compania = this.compania;
                prov.nit = this.nit;
                prov.telefonoProveedor = this.telefono;
                prov.eMailProveedor = this.correo;
                prov.web = this.web;
                prov.giro = this.giro;
                db.Proveedores.Add(prov);
                success = await db.SaveChangesAsync() > 0;
            }
            return success;
        }

        public async Task<bool> UpdateAsync()
        {
            bool success = false;
            using (SIGIVEntities db = new SIGIVEntities())
            {
                DataLayer.Proveedores prov = await db.Proveedores.Where(x => x.idProveedor == this.id).FirstOrDefaultAsync();
                prov.compania = this.compania;
                prov.nit = this.nit;
                prov.telefonoProveedor = this.telefono;
                prov.eMailProveedor = this.correo;
                prov.web = this.web;
                prov.giro = this.giro;
                success = await db.SaveChangesAsync() > 0;
            }
            return success;
        }

        public async Task<bool> DeleteAsync(int idProveedor)
        {
            bool success = false;
            using (SIGIVEntities db = new SIGIVEntities())
            {
                DataLayer.Proveedores prov = await db.Proveedores.Where(x => x.idProveedor == idProveedor).FirstOrDefaultAsync();
                db.Proveedores.Remove(prov);
                success = await db.SaveChangesAsync() > 0;
            }
            return success;
        }

        public async Task<bool> DeleteAsync()
        {
            return await DeleteAsync(this.id);
        }

        // obtenes la direccion del provedor
        public async Task<DireccionProveedorCLS> GetDireccionAsync()
        {
            DireccionProveedorCLS direccion = new DireccionProveedorCLS();
            using (SIGIVEntities db = new SIGIVEntities())
            {
                var model = await db.ProveedoresDireccion.Where(x => x.idProveedor == this.id).FirstOrDefaultAsync();
                if (model != null)
                {
                    direccion.id = model.idProveedoresDireccion;
                    direccion.idProveedor = (int)model.idProveedor;
                    direccion.Linea1 = model.Linea1;
                    direccion.Linea2 = model.Linea2; 
                    direccion.codigoPostal = model.codigoPostal;
                }
            }
            return direccion;
        }
 
        // tareas de tipo Task
        // obtienes el contacto del provedor
        // returna un objeto de tipo ContactoProveedorCLS 

        public async Task<ContactoProveedorCLS> GetContactoAsync()
        {
            ContactoProveedorCLS contacto = new ContactoProveedorCLS();
            using (SIGIVEntities db = new SIGIVEntities())
            {
                var model = await db.ContactosProveedor.Where(x => x.idProveedor == this.id).FirstOrDefaultAsync();
                if (model != null)
                {
                    contacto.id = model.idContacto;
                    contacto.idProveedor = (int)model.idProveedor;
                    contacto.nombresContacto = model.nombresContacto;
                    contacto.ApellidosContacto = model.apellidosContacto;
                    contacto.cargoContacto = model.cargoContacto;
                    contacto.telefonoContacto = model.telefonoContacto;
                    contacto.eMailContacto = model.eMailContacto;
                    contacto.observacion = model.observacion;
                }
            }
            return contacto;
        }
        public void validar()
        {
            if (string.IsNullOrEmpty(compania)) throw new ArgumentException("El nombre de la compañía no puede estar vacío");
            if (string.IsNullOrEmpty(nit)) throw new ArgumentException("El NIT no puede estar vacío");
            if (string.IsNullOrEmpty(telefono)) throw new ArgumentException("El teléfono no puede estar vacío");
            if (string.IsNullOrEmpty(correo)) throw new ArgumentException("El correo no puede estar vacío");
            if (string.IsNullOrEmpty(web)) throw new ArgumentException("El sitio web no puede estar vacío");
            if (string.IsNullOrEmpty(giro)) throw new ArgumentException("El giro no puede estar vacío");
        }
    }
}
