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
    
    public partial class Direcciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Direcciones()
        {
            this.ClienteDireccion = new HashSet<ClienteDireccion>();
            this.ClienteDireccion1 = new HashSet<ClienteDireccion>();
            this.ClienteDireccion2 = new HashSet<ClienteDireccion>();
            this.EmpleadoDireccion = new HashSet<EmpleadoDireccion>();
            this.EmpleadoDireccion1 = new HashSet<EmpleadoDireccion>();
            this.EmpleadoDireccion2 = new HashSet<EmpleadoDireccion>();
            this.ProveedoresDireccion = new HashSet<ProveedoresDireccion>();
        }
    
        public int idDireccion { get; set; }
        public int idDistrito { get; set; }
        public Nullable<int> CodigoPostal { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClienteDireccion> ClienteDireccion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClienteDireccion> ClienteDireccion1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClienteDireccion> ClienteDireccion2 { get; set; }
        public virtual Distritos Distritos { get; set; }
        public virtual Distritos Distritos1 { get; set; }
        public virtual Distritos Distritos2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmpleadoDireccion> EmpleadoDireccion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmpleadoDireccion> EmpleadoDireccion1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmpleadoDireccion> EmpleadoDireccion2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProveedoresDireccion> ProveedoresDireccion { get; set; }
    }
}
