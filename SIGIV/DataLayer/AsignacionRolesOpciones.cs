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
    
    public partial class AsignacionRolesOpciones
    {
        public int idAsignacionRol { get; set; }
        public int idRol { get; set; }
        public int idOpcion { get; set; }
    
        public virtual Opciones Opciones { get; set; }
        public virtual Opciones Opciones1 { get; set; }
        public virtual Roles Roles { get; set; }
        public virtual Roles Roles1 { get; set; }
    }
}
