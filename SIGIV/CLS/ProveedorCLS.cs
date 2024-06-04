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
    internal class ProveedorCLS
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
    }
}
