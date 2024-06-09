using SIGIV.CLS.utils;
using SIGIV.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS.Auth
{
    public class UserManager
    {
        private static List<UsuarioCLS> usuarios = new List<UsuarioCLS>(); 

        public async Task<bool> IniciarSession(string usuario, string password)
        {
            bool succes = false;

            using(var db = new SIGIVEntities())
            {
                var _usuario = await db.Usuarios.Where(usu => usu.usuario == usuario)
                    .FirstOrDefaultAsync();
                if (_usuario == null) throw new Exception("No tiene registro de un usuario con ese nombre");

                password = Security.GenerateSHA256Hash(password);
                if (_usuario.clave != password) throw new Exception("Contraseña incorrecta");
                succes = true;

                if (usuarios.Count > 0) throw new Exception("Ya existe un usuario con ese nombre");

                usuarios.Add(new UsuarioCLS
                {
                    id = _usuario.idUsuario,    
                    usuario = usuario,
                    clave = password,
                    idRol = (int)_usuario.idRol,
                    idEmpleado = (int)_usuario.idEmpleado
                });
            }

            return succes;
        }

        public static bool CerrarSesion()
        {
            bool succes = false;
            if (usuarios.Count > 0)
            {
                usuarios.Clear();
                succes = true;
            }
            return succes;
        }

        public static UsuarioCLS GetSesion()
        {
            return usuarios.First();
        }

    }
}
