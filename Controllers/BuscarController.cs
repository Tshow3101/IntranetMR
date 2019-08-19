using IntranetMundoRepresentaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntranetMundoRepresentaciones.Controllers
{
    public class BuscarController : Controller
    {

        private ModeloMR db = new ModeloMR();
        // GET: Buscar
        public ActionResult Index(DateTime? fecha1, DateTime? fecha2, int idZona = 0, int idPais = 0, int idCiudad = 0, int idCadena = 0, int idHotel = 0, int idLineaaerea = 0)
        {
            ViewBag.idCiudad = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad");
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais");
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona");
            ViewBag.idCadena = new SelectList(db.tb_cadenahotelera, "idCadenaHotelera", "nombreCadenaHotelera");
            ViewBag.idHotel = new SelectList(db.tb_hotel, "idHotel", "nombrehotel");
            ViewBag.idLineaaerea = new SelectList(db.tb_aerolinea, "idAerolinea", "NombreComercial");

            var itinerariodeviaje = from c in db.tb_detalleingresohotel
                                    where c.tb_ingresohotel.fecviajeini < fecha1 && c.tb_ingresohotel.fecviajefin > fecha2 &&
                                          c.tb_ingresohotel.feccompraini < DateTime.Today && c.tb_ingresohotel.feccomprafin > DateTime.Today
                                    select c;

            var zonaseitinerario = from c in db.tb_detalleingresohotel
                                   where c.tb_ingresohotel.tb_hotel.tb_zona.idZona == idZona && c.tb_ingresohotel.tb_hotel.tb_pais.idPais == idPais &&
                                         c.tb_ingresohotel.tb_hotel.tb_ciudad.idCiudad == idCiudad &&
                                         c.tb_ingresohotel.fecviajeini < fecha1 && c.tb_ingresohotel.fecviajefin > fecha2 &&
                                         c.tb_ingresohotel.feccompraini < DateTime.Today && c.tb_ingresohotel.feccomprafin > DateTime.Today
                                   select c;

            var hotelzonaseitinerarios = from c in db.tb_detalleingresohotel
                                         where c.tb_ingresohotel.idHotel == idHotel && c.tb_ingresohotel.idCadena == idCadena &&
                                               c.tb_ingresohotel.tb_hotel.tb_zona.idZona == idZona && c.tb_ingresohotel.tb_hotel.tb_pais.idPais == idPais &&
                                               c.tb_ingresohotel.tb_hotel.tb_ciudad.idCiudad == idCiudad &&
                                               c.tb_ingresohotel.fecviajeini < fecha1 && c.tb_ingresohotel.fecviajefin > fecha2 &&
                                               c.tb_ingresohotel.feccompraini < DateTime.Today && c.tb_ingresohotel.feccomprafin > DateTime.Today
                                         select c;

            ViewBag.boletoaereoeitinerario = from c in db.tb_tarifa_aerea
                                             where c.id_laerea == idLineaaerea && c.time_viaje_1 < fecha1 && c.time_viaje_2 > fecha2 &&
                                                   c.time_compra_1 < DateTime.Today && c.time_compra_2 > DateTime.Today
                                             select c;
            return View(ViewBag.boletoaereoeitinerario.ToList());
        }
    }
}