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
    
    public partial class tb_hotel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_hotel()
        {
            this.tb_contactohotel = new HashSet<tb_contactohotel>();
            this.tb_hotel_paquete = new HashSet<tb_hotel_paquete>();
            this.tb_ingresohotel = new HashSet<tb_ingresohotel>();
            this.tb_tipohabitacion = new HashSet<tb_tipohabitacion>();
        }
    
        public int idHotel { get; set; }
        public string nombrehotel { get; set; }
        public Nullable<int> idCadenaHotelera { get; set; }
        public Nullable<int> idZona { get; set; }
        public Nullable<int> idPais { get; set; }
        public Nullable<int> idCiudad { get; set; }
        public Nullable<int> idCategoria { get; set; }
        public string direccionhotel { get; set; }
        public string correohotel { get; set; }
        public string telefono1hotel { get; set; }
        public string telefono2hotel { get; set; }
        public Nullable<int> idVigencia { get; set; }
        public string linkhotel { get; set; }
        public Nullable<System.TimeSpan> checkinhotel { get; set; }
        public Nullable<System.TimeSpan> checkouthotel { get; set; }
        public string mapahotel { get; set; }
        public string logohotel { get; set; }
        public Nullable<int> tipoplanalimenticio { get; set; }
        public Nullable<int> soloadultos { get; set; }
        public Nullable<System.DateTime> fecharegistro { get; set; }
        public Nullable<int> usuarioregistro { get; set; }
        public Nullable<System.DateTime> fechamodificacion { get; set; }
        public Nullable<int> usuariomodificacion { get; set; }
    
        public virtual tb_cadenahotelera tb_cadenahotelera { get; set; }
        public virtual tb_categoria tb_categoria { get; set; }
        public virtual tb_categoria tb_categoria1 { get; set; }
        public virtual tb_categoria tb_categoria2 { get; set; }
        public virtual tb_ciudad tb_ciudad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_contactohotel> tb_contactohotel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_hotel_paquete> tb_hotel_paquete { get; set; }
        public virtual tb_pais tb_pais { get; set; }
        public virtual tb_vigencia tb_vigencia { get; set; }
        public virtual tb_zona tb_zona { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_ingresohotel> tb_ingresohotel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_tipohabitacion> tb_tipohabitacion { get; set; }
    }
}
