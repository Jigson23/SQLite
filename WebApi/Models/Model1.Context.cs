﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class NuevaJerusalenEntities : DbContext
    {
        public NuevaJerusalenEntities()
            : base("name=NuevaJerusalenEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Hermano> Hermano { get; set; }
    
        public virtual ObjectResult<InsertaHermanos_Result> InsertaHermanos(string cedula, string nombre, string apellidos, string idSexo, Nullable<System.DateTime> fecha_Nac, string idProvincia, string ciudad, string direccion, string telefono, string idEstadoCivil, string tipoSangre, Nullable<bool> bautizo, Nullable<System.DateTime> fechaBautizo, Nullable<bool> activo)
        {
            var cedulaParameter = cedula != null ?
                new ObjectParameter("cedula", cedula) :
                new ObjectParameter("cedula", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var apellidosParameter = apellidos != null ?
                new ObjectParameter("apellidos", apellidos) :
                new ObjectParameter("apellidos", typeof(string));
    
            var idSexoParameter = idSexo != null ?
                new ObjectParameter("IdSexo", idSexo) :
                new ObjectParameter("IdSexo", typeof(string));
    
            var fecha_NacParameter = fecha_Nac.HasValue ?
                new ObjectParameter("Fecha_Nac", fecha_Nac) :
                new ObjectParameter("Fecha_Nac", typeof(System.DateTime));
    
            var idProvinciaParameter = idProvincia != null ?
                new ObjectParameter("IdProvincia", idProvincia) :
                new ObjectParameter("IdProvincia", typeof(string));
    
            var ciudadParameter = ciudad != null ?
                new ObjectParameter("Ciudad", ciudad) :
                new ObjectParameter("Ciudad", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var idEstadoCivilParameter = idEstadoCivil != null ?
                new ObjectParameter("IdEstadoCivil", idEstadoCivil) :
                new ObjectParameter("IdEstadoCivil", typeof(string));
    
            var tipoSangreParameter = tipoSangre != null ?
                new ObjectParameter("TipoSangre", tipoSangre) :
                new ObjectParameter("TipoSangre", typeof(string));
    
            var bautizoParameter = bautizo.HasValue ?
                new ObjectParameter("Bautizo", bautizo) :
                new ObjectParameter("Bautizo", typeof(bool));
    
            var fechaBautizoParameter = fechaBautizo.HasValue ?
                new ObjectParameter("FechaBautizo", fechaBautizo) :
                new ObjectParameter("FechaBautizo", typeof(System.DateTime));
    
            var activoParameter = activo.HasValue ?
                new ObjectParameter("activo", activo) :
                new ObjectParameter("activo", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<InsertaHermanos_Result>("InsertaHermanos", cedulaParameter, nombreParameter, apellidosParameter, idSexoParameter, fecha_NacParameter, idProvinciaParameter, ciudadParameter, direccionParameter, telefonoParameter, idEstadoCivilParameter, tipoSangreParameter, bautizoParameter, fechaBautizoParameter, activoParameter);
        }
    
        public virtual ObjectResult<ConsultaGeneral_Result> ConsultaGeneral()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ConsultaGeneral_Result>("ConsultaGeneral");
        }
    }
}
