//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IntranetMundoRepresentaciones.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_detalleserviciosgenerales
    {
        public int idDetalleserviciosgenerales { get; set; }
        public Nullable<int> idServiciosgenerales { get; set; }
        public Nullable<int> minpasajeros { get; set; }
        public Nullable<int> maxpasajeros { get; set; }
        public Nullable<decimal> costoadulto { get; set; }
        public Nullable<decimal> costoniño { get; set; }
        public Nullable<decimal> ventaadulto { get; set; }
        public Nullable<decimal> ventaniño { get; set; }
        public Nullable<System.DateTime> fecharegistro { get; set; }
        public Nullable<int> usuarioregistro { get; set; }
        public Nullable<System.DateTime> fechamodificacion { get; set; }
        public Nullable<int> usuariomodificacion { get; set; }
    
        public virtual tb_serviciosgenerales tb_serviciosgenerales { get; set; }
    }
}
