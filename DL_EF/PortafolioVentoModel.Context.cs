﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL_EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PortafolioVentoEntities : DbContext
    {
        public PortafolioVentoEntities()
            : base("name=PortafolioVentoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Automovil> Automovils { get; set; }
        public virtual DbSet<AutomovilProveedor> AutomovilProveedors { get; set; }
        public virtual DbSet<Proveedor> Proveedors { get; set; }
    
        public virtual int AutomovilDelete(Nullable<int> idAutomovil)
        {
            var idAutomovilParameter = idAutomovil.HasValue ?
                new ObjectParameter("IdAutomovil", idAutomovil) :
                new ObjectParameter("IdAutomovil", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AutomovilDelete", idAutomovilParameter);
        }
    
        public virtual ObjectResult<AutomovilGetAll_Result> AutomovilGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AutomovilGetAll_Result>("AutomovilGetAll");
        }
    
        public virtual ObjectResult<AutomovilGetById_Result> AutomovilGetById(Nullable<int> idAutomovil)
        {
            var idAutomovilParameter = idAutomovil.HasValue ?
                new ObjectParameter("IdAutomovil", idAutomovil) :
                new ObjectParameter("IdAutomovil", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AutomovilGetById_Result>("AutomovilGetById", idAutomovilParameter);
        }
    
        public virtual int AutomovilUpdate(Nullable<int> idAutomovil, string marca, string modelo, string color, byte[] imagen)
        {
            var idAutomovilParameter = idAutomovil.HasValue ?
                new ObjectParameter("IdAutomovil", idAutomovil) :
                new ObjectParameter("IdAutomovil", typeof(int));
    
            var marcaParameter = marca != null ?
                new ObjectParameter("Marca", marca) :
                new ObjectParameter("Marca", typeof(string));
    
            var modeloParameter = modelo != null ?
                new ObjectParameter("Modelo", modelo) :
                new ObjectParameter("Modelo", typeof(string));
    
            var colorParameter = color != null ?
                new ObjectParameter("Color", color) :
                new ObjectParameter("Color", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AutomovilUpdate", idAutomovilParameter, marcaParameter, modeloParameter, colorParameter, imagenParameter);
        }
    
        public virtual int AutomovilAdd(string marca, string modelo, string color, byte[] imagen)
        {
            var marcaParameter = marca != null ?
                new ObjectParameter("Marca", marca) :
                new ObjectParameter("Marca", typeof(string));
    
            var modeloParameter = modelo != null ?
                new ObjectParameter("Modelo", modelo) :
                new ObjectParameter("Modelo", typeof(string));
    
            var colorParameter = color != null ?
                new ObjectParameter("Color", color) :
                new ObjectParameter("Color", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AutomovilAdd", marcaParameter, modeloParameter, colorParameter, imagenParameter);
        }
    
        public virtual int ProveedorAdd(string nombre, Nullable<int> costo)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var costoParameter = costo.HasValue ?
                new ObjectParameter("Costo", costo) :
                new ObjectParameter("Costo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProveedorAdd", nombreParameter, costoParameter);
        }
    
        public virtual int ProveedorDelete(Nullable<int> idProveedor)
        {
            var idProveedorParameter = idProveedor.HasValue ?
                new ObjectParameter("IdProveedor", idProveedor) :
                new ObjectParameter("IdProveedor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProveedorDelete", idProveedorParameter);
        }
    
        public virtual ObjectResult<ProveedorGetAll_Result> ProveedorGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProveedorGetAll_Result>("ProveedorGetAll");
        }
    
        public virtual ObjectResult<ProveedorGetById_Result> ProveedorGetById(Nullable<int> idProveedor)
        {
            var idProveedorParameter = idProveedor.HasValue ?
                new ObjectParameter("IdProveedor", idProveedor) :
                new ObjectParameter("IdProveedor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProveedorGetById_Result>("ProveedorGetById", idProveedorParameter);
        }
    
        public virtual int ProveedorUpdate(Nullable<int> idProveedor, string nombre, Nullable<int> costo)
        {
            var idProveedorParameter = idProveedor.HasValue ?
                new ObjectParameter("IdProveedor", idProveedor) :
                new ObjectParameter("IdProveedor", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var costoParameter = costo.HasValue ?
                new ObjectParameter("Costo", costo) :
                new ObjectParameter("Costo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProveedorUpdate", idProveedorParameter, nombreParameter, costoParameter);
        }
    
        public virtual int AutomovilProveedorAdd(Nullable<int> idAutomovil, Nullable<int> idProveedor)
        {
            var idAutomovilParameter = idAutomovil.HasValue ?
                new ObjectParameter("IdAutomovil", idAutomovil) :
                new ObjectParameter("IdAutomovil", typeof(int));
    
            var idProveedorParameter = idProveedor.HasValue ?
                new ObjectParameter("IdProveedor", idProveedor) :
                new ObjectParameter("IdProveedor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AutomovilProveedorAdd", idAutomovilParameter, idProveedorParameter);
        }
    
        public virtual ObjectResult<AutomovilProveedorAsignadaByAutomovilId_Result> AutomovilProveedorAsignadaByAutomovilId(Nullable<int> idAutomovil)
        {
            var idAutomovilParameter = idAutomovil.HasValue ?
                new ObjectParameter("IdAutomovil", idAutomovil) :
                new ObjectParameter("IdAutomovil", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AutomovilProveedorAsignadaByAutomovilId_Result>("AutomovilProveedorAsignadaByAutomovilId", idAutomovilParameter);
        }
    
        public virtual ObjectResult<AutomovilProveedorNOAsignadaByAutomovilId_Result> AutomovilProveedorNOAsignadaByAutomovilId(Nullable<int> idAutomovil)
        {
            var idAutomovilParameter = idAutomovil.HasValue ?
                new ObjectParameter("IdAutomovil", idAutomovil) :
                new ObjectParameter("IdAutomovil", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AutomovilProveedorNOAsignadaByAutomovilId_Result>("AutomovilProveedorNOAsignadaByAutomovilId", idAutomovilParameter);
        }
    
        public virtual int AutomovilProveedorDelete(Nullable<int> automovilProveedor)
        {
            var automovilProveedorParameter = automovilProveedor.HasValue ?
                new ObjectParameter("AutomovilProveedor", automovilProveedor) :
                new ObjectParameter("AutomovilProveedor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AutomovilProveedorDelete", automovilProveedorParameter);
        }
    }
}
