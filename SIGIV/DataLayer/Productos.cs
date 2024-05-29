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
    
    public partial class Productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Productos()
        {
            this.DetallesFacturas = new HashSet<DetallesFacturas>();
        }
    
        public int idProducto { get; set; }
        public string nombreP { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int idCategoria { get; set; }
        public int idStok { get; set; }
    
        public virtual CategoriasProductos CategoriasProductos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallesFacturas> DetallesFacturas { get; set; }
        public virtual DetallesStok DetallesStok { get; set; }
    }
}
