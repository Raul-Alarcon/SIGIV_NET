using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS
{
    public class DireccionCLS
    { 
        public int id { get; set; }
        public int idDistrito { get; set; }
        public int CodigoPostal { get; set; }




        public async Task<bool> SaveAsync()
        {
            bool succes = false;
            using (DataLayer.SIGIVEntities db = new DataLayer.SIGIVEntities())
            {
                DataLayer.Direcciones direccion = new DataLayer.Direcciones();
                direccion.idDistrito = idDistrito;
                direccion.CodigoPostal = CodigoPostal;
                db.Direcciones.Add(direccion);
                int result = await db.SaveChangesAsync();
                succes = result > 0;
            }
            return succes;
        }


        public async Task<DireccionCLS> SaveAndReturnAsync()
        { 
           DireccionCLS direccionCls = new DireccionCLS();
            using (DataLayer.SIGIVEntities db = new DataLayer.SIGIVEntities())
            { 
                DataLayer.Direcciones direccion = new DataLayer.Direcciones();
                direccion.idDistrito = idDistrito;
                direccion.CodigoPostal = CodigoPostal;
                db.Direcciones.Add(direccion);
                int result = await db.SaveChangesAsync();
                if (result > 0)
                {
                    direccionCls.id = direccion.idDireccion;
                    direccionCls.idDistrito = direccion.idDistrito;
                    direccionCls.CodigoPostal = (int)direccion.CodigoPostal;
                }
            } 
            return direccionCls;
        }
    }
}
