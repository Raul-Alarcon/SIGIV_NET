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
    
    public partial class DetallesFacturas
    {
        public int idDetalles { get; set; }
        public int idProducto { get; set; }
        public int idFactura { get; set; }
        public int cantidad { get; set; }
        public decimal iva { get; set; }
        public decimal descuento { get; set; }
    
        public virtual Facturas Facturas { get; set; }
        public virtual Productos Productos { get; set; }
    }
}
