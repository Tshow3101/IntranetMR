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
    
    public partial class tb_serviciolineaaerea
    {
        public int idServiciolineaaerea { get; set; }
        public Nullable<System.DateTime> viajaini { get; set; }
        public Nullable<System.DateTime> viajefin { get; set; }
        public Nullable<System.DateTime> compraini { get; set; }
        public Nullable<System.DateTime> comprafin { get; set; }
        public string farebasis { get; set; }
        public string clase { get; set; }
        public string claseinterna { get; set; }
        public Nullable<int> temporada { get; set; }
        public Nullable<int> tipotarifa { get; set; }
        public Nullable<int> tipopasajero { get; set; }
        public Nullable<decimal> cambioclase { get; set; }
        public Nullable<int> tipoboleto { get; set; }
        public Nullable<int> destino1 { get; set; }
        public Nullable<int> destino2 { get; set; }
        public Nullable<int> destino3 { get; set; }
        public Nullable<int> destino4 { get; set; }
        public Nullable<int> destino5 { get; set; }
        public Nullable<decimal> neto { get; set; }
        public Nullable<decimal> igvneto { get; set; }
        public Nullable<decimal> niño { get; set; }
        public Nullable<decimal> igvniño { get; set; }
        public Nullable<int> estadiaminima { get; set; }
        public Nullable<int> Cantidadparada { get; set; }
        public Nullable<int> paradasfree { get; set; }
        public Nullable<decimal> netoparada { get; set; }
        public Nullable<int> impuesto1 { get; set; }
        public Nullable<decimal> impuestoprecio1 { get; set; }
        public Nullable<int> impuesto2 { get; set; }
        public Nullable<decimal> impuestoprecio2 { get; set; }
        public Nullable<int> impuesto3 { get; set; }
        public Nullable<decimal> impuestoprecio3 { get; set; }
        public Nullable<int> impuesto4 { get; set; }
        public Nullable<decimal> impuestoprecio4 { get; set; }
        public Nullable<int> impuesto5 { get; set; }
        public Nullable<decimal> impuestoprecio5 { get; set; }
        public Nullable<int> impuesto6 { get; set; }
        public Nullable<decimal> impuestoprecio6 { get; set; }
        public string notas { get; set; }
        public Nullable<decimal> precioadulto { get; set; }
        public Nullable<decimal> comisionadulto { get; set; }
        public Nullable<decimal> totalcomisionadulto { get; set; }
        public Nullable<decimal> overadulto { get; set; }
        public Nullable<decimal> totaloveradulto { get; set; }
        public Nullable<decimal> totalapagaradulto { get; set; }
        public Nullable<decimal> preciochild { get; set; }
        public Nullable<decimal> comisionchild { get; set; }
        public Nullable<decimal> totalcomisionchild { get; set; }
        public Nullable<decimal> overchild { get; set; }
        public Nullable<decimal> totaloverchild { get; set; }
        public Nullable<decimal> totalapagarchild { get; set; }
        public Nullable<decimal> factor { get; set; }
        public Nullable<System.DateTime> fecharegistro { get; set; }
        public Nullable<int> usuarioregistro { get; set; }
        public Nullable<System.DateTime> fechamodificacion { get; set; }
        public Nullable<int> usuariomodificacion { get; set; }
    
        public virtual tb_categoria tb_categoria { get; set; }
        public virtual tb_categoria tb_categoria1 { get; set; }
        public virtual tb_categoria tb_categoria2 { get; set; }
        public virtual tb_categoria tb_categoria3 { get; set; }
        public virtual tb_ciudad tb_ciudad { get; set; }
        public virtual tb_ciudad tb_ciudad1 { get; set; }
        public virtual tb_ciudad tb_ciudad2 { get; set; }
        public virtual tb_ciudad tb_ciudad3 { get; set; }
        public virtual tb_ciudad tb_ciudad4 { get; set; }
        public virtual tb_impuestos tb_impuestos { get; set; }
        public virtual tb_impuestos tb_impuestos1 { get; set; }
        public virtual tb_impuestos tb_impuestos2 { get; set; }
        public virtual tb_impuestos tb_impuestos3 { get; set; }
        public virtual tb_impuestos tb_impuestos4 { get; set; }
        public virtual tb_impuestos tb_impuestos5 { get; set; }
    }
}
