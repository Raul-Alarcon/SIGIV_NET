﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SIGIVEntities : DbContext
    {
        public SIGIVEntities()
            : base("name=SIGIVEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AsignacionRolesOpciones> AsignacionRolesOpciones { get; set; }
        public virtual DbSet<Cargos> Cargos { get; set; }
        public virtual DbSet<CategoriasProductos> CategoriasProductos { get; set; }
        public virtual DbSet<ClienteDireccion> ClienteDireccion { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<ContactosProveedor> ContactosProveedor { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<DetallesFacturas> DetallesFacturas { get; set; }
        public virtual DbSet<DetallesPedidos> DetallesPedidos { get; set; }
        public virtual DbSet<DetallesStok> DetallesStok { get; set; }
        public virtual DbSet<Distritos> Distritos { get; set; }
        public virtual DbSet<EmpleadoDireccion> EmpleadoDireccion { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Facturas> Facturas { get; set; }
        public virtual DbSet<Municipios> Municipios { get; set; }
        public virtual DbSet<Opciones> Opciones { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<Pedidos> Pedidos { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<ProductosNuevos> ProductosNuevos { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<ProveedoresDireccion> ProveedoresDireccion { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<TiposPago> TiposPago { get; set; }
        public virtual DbSet<TransaccionesPago> TransaccionesPago { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    }
}
