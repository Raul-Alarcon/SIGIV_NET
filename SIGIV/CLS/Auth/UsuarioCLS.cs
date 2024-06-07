using SIGIV.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;

namespace SIGIV.CLS.Auth
{
    public class UsuarioCLS
    {
        public int id { get; set; }
        public int idEmpleado { get; set; }
        public int idRol { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }


        public async Task<UsuarioCLS> SaveAsync()
        {
            UsuarioCLS usuario = new UsuarioCLS();
            using (SIGIVEntities db = new SIGIVEntities())
            {
                DataLayer.Usuarios usu = new DataLayer.Usuarios();
                usu.usuario = this.usuario;
                usu.clave = this.clave;
                usu.idRol = this.idRol;
                usu.idEmpleado = this.idEmpleado;
                db.Usuarios.Add(usu);
                await db.SaveChangesAsync();
                

                if(usu.idUsuario > 0)
                {
                    usuario.id = usu.idUsuario;
                    usuario.usuario = usu.usuario;
                    usuario.idRol = (int)usu.idRol;
                    usuario.idEmpleado = (int)usu.idEmpleado;
                    usuario.clave = usu.clave;
                }
            }
            return usuario; 
        }

        public async Task<bool> UpdateAsync()
        {
            bool success = false;
            using (SIGIVEntities db = new SIGIVEntities())
            {
                                        
            }
            return success;
        }

    }
}
