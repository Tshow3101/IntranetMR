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
    
    public partial class tb_hotel_paquete
    {
        public int idHotelPaquete { get; set; }
        public Nullable<int> idPaquete { get; set; }
        public Nullable<int> Cadena { get; set; }
        public Nullable<int> Hotel { get; set; }
        public Nullable<int> tipohabitacion { get; set; }
        public Nullable<decimal> doble { get; set; }
        public Nullable<decimal> triple { get; set; }
        public Nullable<decimal> cuadruple { get; set; }
        public Nullable<decimal> simple { get; set; }
        public Nullable<decimal> quintuple { get; set; }
        public Nullable<decimal> sextuple { get; set; }
        public Nullable<decimal> child1 { get; set; }
        public Nullable<decimal> edad1child1 { get; set; }
        public Nullable<decimal> edad2child1 { get; set; }
        public Nullable<decimal> child2 { get; set; }
        public Nullable<decimal> edad1child2 { get; set; }
        public Nullable<decimal> edad2child2 { get; set; }
        public Nullable<decimal> child3 { get; set; }
        public Nullable<decimal> edad1child3 { get; set; }
        public Nullable<decimal> edad2child3 { get; set; }
        public Nullable<decimal> infante { get; set; }
        public Nullable<decimal> edadinfante1 { get; set; }
        public Nullable<decimal> edadinfante2 { get; set; }
    
        public virtual tb_cadenahotelera tb_cadenahotelera { get; set; }
        public virtual tb_hotel tb_hotel { get; set; }
        public virtual tb_paquete tb_paquete { get; set; }
        public virtual tb_tipohabitacion tb_tipohabitacion { get; set; }
    }
}
