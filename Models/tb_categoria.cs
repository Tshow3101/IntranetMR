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
    
    public partial class tb_categoria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_categoria()
        {
            this.tb_aerolinea = new HashSet<tb_aerolinea>();
            this.tb_agencia = new HashSet<tb_agencia>();
            this.tb_agencia1 = new HashSet<tb_agencia>();
            this.tb_agencia2 = new HashSet<tb_agencia>();
            this.tb_bancoagencia = new HashSet<tb_bancoagencia>();
            this.tb_bancoagencia1 = new HashSet<tb_bancoagencia>();
            this.tb_contactohotel = new HashSet<tb_contactohotel>();
            this.tb_detalleingresohotel = new HashSet<tb_detalleingresohotel>();
            this.tb_detalleingresohotel1 = new HashSet<tb_detalleingresohotel>();
            this.tb_hotel = new HashSet<tb_hotel>();
            this.tb_hotel1 = new HashSet<tb_hotel>();
            this.tb_hotel2 = new HashSet<tb_hotel>();
            this.tb_ingresohotel = new HashSet<tb_ingresohotel>();
            this.tb_usuario = new HashSet<tb_usuario>();
            this.tb_usuario1 = new HashSet<tb_usuario>();
            this.tb_usuario2 = new HashSet<tb_usuario>();
            this.tb_usuario3 = new HashSet<tb_usuario>();
            this.tb_usuario4 = new HashSet<tb_usuario>();
            this.tb_usuario5 = new HashSet<tb_usuario>();
            this.tb_usuario6 = new HashSet<tb_usuario>();
            this.tb_usuario7 = new HashSet<tb_usuario>();
            this.tb_detalleTraslado = new HashSet<tb_detalleTraslado>();
        }
    
        public int idCategoria { get; set; }
        public string nombreCategoria { get; set; }
        public Nullable<int> idTipocategoria { get; set; }
        public Nullable<System.DateTime> fecharegistro { get; set; }
        public Nullable<int> usuarioregistro { get; set; }
        public Nullable<System.DateTime> fechamodificacion { get; set; }
        public Nullable<int> usuariomodificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_aerolinea> tb_aerolinea { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_agencia> tb_agencia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_agencia> tb_agencia1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_agencia> tb_agencia2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_bancoagencia> tb_bancoagencia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_bancoagencia> tb_bancoagencia1 { get; set; }
        public virtual tb_tipocategoria tb_tipocategoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_contactohotel> tb_contactohotel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_detalleingresohotel> tb_detalleingresohotel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_detalleingresohotel> tb_detalleingresohotel1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_hotel> tb_hotel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_hotel> tb_hotel1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_hotel> tb_hotel2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_ingresohotel> tb_ingresohotel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_usuario> tb_usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_usuario> tb_usuario1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_usuario> tb_usuario2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_usuario> tb_usuario3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_usuario> tb_usuario4 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_usuario> tb_usuario5 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_usuario> tb_usuario6 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_usuario> tb_usuario7 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_detalleTraslado> tb_detalleTraslado { get; set; }
    }
}
