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
    
    public partial class tb_detalleTraslado
    {
        public int id_detalleTraslado { get; set; }
        public Nullable<int> id_traslado { get; set; }
        public Nullable<int> id_destino { get; set; }
        public Nullable<int> id_tramo { get; set; }
        public Nullable<decimal> precio_compartido { get; set; }
        public Nullable<int> rango1a_priv { get; set; }
        public Nullable<int> rango2a_priv { get; set; }
        public Nullable<decimal> precioa_priv { get; set; }
        public Nullable<int> rango1b_priv { get; set; }
        public Nullable<int> rango2b_priv { get; set; }
        public Nullable<decimal> preciob_priv { get; set; }
        public Nullable<int> rango1c_priv { get; set; }
        public Nullable<int> rango2c_priv { get; set; }
        public Nullable<decimal> precioc_priv { get; set; }
        public Nullable<int> rango1d_lujo { get; set; }
        public Nullable<int> rango2d_lujo { get; set; }
        public Nullable<decimal> preciod_lujo { get; set; }
    
        public virtual tb_categoria tb_categoria { get; set; }
        public virtual tb_ciudad tb_ciudad { get; set; }
        public virtual tb_traslado tb_traslado { get; set; }
    }
}
