//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIGIV.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuarios
    {
        public int idUsuario { get; set; }
        public Nullable<int> idEmpleado { get; set; }
        public Nullable<int> idRol { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
    
        public virtual Empleados Empleados { get; set; }
        public virtual Roles Roles { get; set; }
    }
}
