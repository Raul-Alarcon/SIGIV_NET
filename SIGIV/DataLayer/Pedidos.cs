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
    
    public partial class Pedidos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedidos()
        {
            this.DetallesPedidos = new HashSet<DetallesPedidos>();
        }
    
        public int idPedido { get; set; }
        public Nullable<int> idProveedor { get; set; }
        public Nullable<System.DateTime> fechaPedido { get; set; }
        public Nullable<System.DateTime> fechaRecibido { get; set; }
        public string comentario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallesPedidos> DetallesPedidos { get; set; }
        public virtual Proveedores Proveedores { get; set; }
    }
}
