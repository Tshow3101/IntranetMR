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
    
    public partial class tb_contactohotel
    {
        public int idContactoHotel { get; set; }
        public Nullable<int> idHotel { get; set; }
        public string nombreContactoHotel { get; set; }
        public string correoContactoHotel { get; set; }
        public Nullable<int> idCategoria { get; set; }
        public Nullable<System.DateTime> fecharegistro { get; set; }
        public Nullable<int> usuarioregistro { get; set; }
        public Nullable<System.DateTime> fechamodificacion { get; set; }
        public Nullable<int> usuariomodificacion { get; set; }
    
        public virtual tb_categoria tb_categoria { get; set; }
        public virtual tb_hotel tb_hotel { get; set; }
    }
}
