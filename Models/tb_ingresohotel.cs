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
    
    public partial class tb_ingresohotel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_ingresohotel()
        {
            this.tb_detalleingresohotel = new HashSet<tb_detalleingresohotel>();
        }
    
        public int idIngresoHotel { get; set; }
        public Nullable<System.DateTime> fecviajeini { get; set; }
        public Nullable<System.DateTime> fecviajefin { get; set; }
        public Nullable<System.DateTime> feccompraini { get; set; }
        public Nullable<System.DateTime> feccomprafin { get; set; }
        public Nullable<int> tarifa { get; set; }
        public string codprom { get; set; }
        public Nullable<int> idCadena { get; set; }
        public Nullable<int> idHotel { get; set; }
        public Nullable<int> montoadulto { get; set; }
        public Nullable<int> montoniño { get; set; }
        public Nullable<int> montoinfante { get; set; }
        public Nullable<int> porcentaje { get; set; }
        public Nullable<System.DateTime> fecharegistro { get; set; }
        public Nullable<int> usuarioregistro { get; set; }
        public Nullable<System.DateTime> fechamodificacion { get; set; }
        public Nullable<int> usuariomodificacion { get; set; }
        public Nullable<int> preciodoble { get; set; }
    
        public virtual tb_cadenahotelera tb_cadenahotelera { get; set; }
        public virtual tb_categoria tb_categoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_detalleingresohotel> tb_detalleingresohotel { get; set; }
        public virtual tb_hotel tb_hotel { get; set; }
    }
}
