using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IntranetMundoRepresentaciones.Models;

namespace IntranetMundoRepresentaciones.Controllers
{
    public class PaqueteController : Controller
    {
        private ModeloMR db = new ModeloMR();

        // GET: Paquete
        public ActionResult Index()
        {
            var tb_paquete = db.tb_paquete.Include(t => t.tb_aerolinea).Include(t => t.tb_cadenahotelera).Include(t => t.tb_ciudad).Include(t => t.tb_ciudad1).Include(t => t.tb_hotel).Include(t => t.tb_pais).Include(t => t.tb_usuario).Include(t => t.tb_usuario1).Include(t => t.tb_tipohabitacion).Include(t => t.tb_zona).Include(t => t.tb_tarjetaasistencia);
            return View(tb_paquete.ToList());
        }

        // GET: Paquete/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_paquete tb_paquete = db.tb_paquete.Find(id);
            if (tb_paquete == null)
            {
                return HttpNotFound();
            }
            return View(tb_paquete);
        }

        // GET: Paquete/Create
        public ActionResult Create()
        {
            ViewBag.aerolinea = new SelectList(db.tb_aerolinea.OrderBy(m => m.NombreComercial), "idaerolinea", "NombreComercial");
            ViewBag.idCadenaH = new SelectList(db.tb_cadenahotelera.OrderBy(m => m.nombreCadenaHotelera), "idCadenaHotelera", "nombreCadenaHotelera");
            ViewBag.idCiudad = new SelectList(db.tb_ciudad.OrderBy(m => m.nombreCiudad), "idCiudad", "nombreCiudad");
            ViewBag.idCiudadT = new SelectList(db.tb_ciudad.OrderBy(m => m.nombreCiudad), "idCiudad", "nombreCiudad");
            ViewBag.idHotelH = new SelectList(db.tb_hotel.OrderBy(m => m.nombrehotel), "idHotel", "nombrehotel");
            ViewBag.idPais = new SelectList(db.tb_pais.OrderBy(m => m.NombrePais), "idPais", "NombrePais");
            ViewBag.idOperadorT = new SelectList(db.tb_usuario.OrderBy(m => m.nombreusuario), "idUsuario", "nombreusuario");
            ViewBag.idOperadorTA = new SelectList(db.tb_usuario.OrderBy(m => m.nombreusuario), "idUsuario", "nombreusuario");
            ViewBag.idTipoHabitacionH = new SelectList(db.tb_tipohabitacion.OrderBy(m => m.NombreTipoHabitacion), "idTipoHabitacion", "NombreTipoHabitacion");
            ViewBag.idZona = new SelectList(db.tb_zona.OrderBy(m => m.nombreZona), "idZona", "nombreZona");
            ViewBag.planTA = new SelectList(db.tb_tarjetaasistencia.OrderBy(m => m.nombreTarjetaasistencia), "idTarjetaasistencia", "nombreTarjetaasistencia");
            return View();
        }

        // POST: Paquete/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPaquete,idZona,idPais,idCiudad,fecha_compra_in,fecha_compra_out,fecha_viajes_in,fecha_viaje_out,idCadenaH,idHotelH,idTipoHabitacionH,acomodacionH,precioH,idOperadorT,idCiudadT,planT,precioT,idOperadorTA,planTA,precioTA,incentivo,factor,aerolinea,npax,precio_A,precio_TTA,preciototal")] tb_paquete tb_paquete)
        {
            if (ModelState.IsValid)
            {
                db.tb_paquete.Add(tb_paquete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.aerolinea = new SelectList(db.tb_aerolinea.OrderBy(m => m.NombreComercial), "idaerolinea", "NombreComercial", tb_paquete.aerolinea);
            ViewBag.idCadenaH = new SelectList(db.tb_cadenahotelera.OrderBy(m => m.nombreCadenaHotelera), "idCadenaHotelera", "nombreCadenaHotelera", tb_paquete.idCadenaH);
            ViewBag.idCiudad = new SelectList(db.tb_ciudad.OrderBy(m => m.nombreCiudad), "idCiudad", "nombreCiudad", tb_paquete.idCiudad);
            ViewBag.idCiudadT = new SelectList(db.tb_ciudad.OrderBy(m => m.nombreCiudad), "idCiudad", "nombreCiudad", tb_paquete.idCiudadT);
            ViewBag.idHotelH = new SelectList(db.tb_hotel.OrderBy(m => m.nombrehotel), "idHotel", "nombrehotel", tb_paquete.idHotelH);
            ViewBag.idPais = new SelectList(db.tb_pais.OrderBy(m => m.NombrePais), "idPais", "NombrePais", tb_paquete.idPais);
            ViewBag.idOperadorT = new SelectList(db.tb_usuario.OrderBy(m => m.nombreusuario), "idUsuario", "nombreusuario", tb_paquete.idOperadorT);
            ViewBag.idOperadorTA = new SelectList(db.tb_usuario.OrderBy(m => m.nombreusuario), "idUsuario", "nombreusuario", tb_paquete.idOperadorTA);
            ViewBag.idTipoHabitacionH = new SelectList(db.tb_tipohabitacion.OrderBy(m => m.NombreTipoHabitacion), "idTipoHabitacion", "NombreTipoHabitacion", tb_paquete.idTipoHabitacionH);
            ViewBag.idZona = new SelectList(db.tb_zona.OrderBy(m => m.nombreZona), "idZona", "nombreZona", tb_paquete.idZona);
            ViewBag.planTA = new SelectList(db.tb_tarjetaasistencia.OrderBy(m => m.nombreTarjetaasistencia), "idTarjetaasistencia", "nombreTarjetaasistencia", tb_paquete.planTA);
            return View(tb_paquete);
        }

        // GET: Paquete/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_paquete tb_paquete = db.tb_paquete.Find(id);
            if (tb_paquete == null)
            {
                return HttpNotFound();
            }
            ViewBag.aerolinea = new SelectList(db.tb_aerolinea, "idaerolinea", "NombreComercial", tb_paquete.aerolinea);
            ViewBag.idCadenaH = new SelectList(db.tb_cadenahotelera, "idCadenaHotelera", "nombreCadenaHotelera", tb_paquete.idCadenaH);
            ViewBag.idCiudad = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_paquete.idCiudad);
            ViewBag.idCiudadT = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_paquete.idCiudadT);
            ViewBag.idHotelH = new SelectList(db.tb_hotel, "idHotel", "nombrehotel", tb_paquete.idHotelH);
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_paquete.idPais);
            ViewBag.idOperadorT = new SelectList(db.tb_usuario, "idUsuario", "apellidopaternousuario", tb_paquete.idOperadorT);
            ViewBag.idOperadorTA = new SelectList(db.tb_usuario, "idUsuario", "apellidopaternousuario", tb_paquete.idOperadorTA);
            ViewBag.idTipoHabitacionH = new SelectList(db.tb_tipohabitacion, "idTipoHabitacion", "NombreTipoHabitacion", tb_paquete.idTipoHabitacionH);
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_paquete.idZona);
            ViewBag.planTA = new SelectList(db.tb_tarjetaasistencia, "idTarjetaasistencia", "nombreTarjetaasistencia", tb_paquete.planTA);
            return View(tb_paquete);
        }

        // POST: Paquete/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPaquete,idZona,idPais,idCiudad,fecha_compra_in,fecha_compra_out,fecha_viajes_in,fecha_viaje_out,idCadenaH,idHotelH,idTipoHabitacionH,acomodacionH,precioH,idOperadorT,idCiudadT,planT,precioT,idOperadorTA,planTA,precioTA,incentivo,factor,aerolinea,npax,precio_A,precio_TTA,preciototal")] tb_paquete tb_paquete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_paquete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.aerolinea = new SelectList(db.tb_aerolinea, "idaerolinea", "NombreComercial", tb_paquete.aerolinea);
            ViewBag.idCadenaH = new SelectList(db.tb_cadenahotelera, "idCadenaHotelera", "nombreCadenaHotelera", tb_paquete.idCadenaH);
            ViewBag.idCiudad = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_paquete.idCiudad);
            ViewBag.idCiudadT = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_paquete.idCiudadT);
            ViewBag.idHotelH = new SelectList(db.tb_hotel, "idHotel", "nombrehotel", tb_paquete.idHotelH);
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_paquete.idPais);
            ViewBag.idOperadorT = new SelectList(db.tb_usuario, "idUsuario", "apellidopaternousuario", tb_paquete.idOperadorT);
            ViewBag.idOperadorTA = new SelectList(db.tb_usuario, "idUsuario", "apellidopaternousuario", tb_paquete.idOperadorTA);
            ViewBag.idTipoHabitacionH = new SelectList(db.tb_tipohabitacion, "idTipoHabitacion", "NombreTipoHabitacion", tb_paquete.idTipoHabitacionH);
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_paquete.idZona);
            ViewBag.planTA = new SelectList(db.tb_tarjetaasistencia, "idTarjetaasistencia", "nombreTarjetaasistencia", tb_paquete.planTA);
            return View(tb_paquete);
        }

        // GET: Paquete/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_paquete tb_paquete = db.tb_paquete.Find(id);
            if (tb_paquete == null)
            {
                return HttpNotFound();
            }
            return View(tb_paquete);
        }

        // POST: Paquete/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_paquete tb_paquete = db.tb_paquete.Find(id);
            db.tb_paquete.Remove(tb_paquete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult getPais(int? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var results = from p in db.tb_pais
                          where p.idZona == id
                          orderby p.NombrePais
                          select new { idPais = p.idPais, Pais = p.NombrePais };
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getDestinos(int? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var results = from p in db.tb_ciudad
                          where p.idPais == id
                          orderby p.nombreCiudad
                          select new { idCiudad = p.idCiudad, Ciudad = p.nombreCiudad };
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getHotel(int? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var results = from p in db.tb_hotel
                          where p.idCadenaHotelera == id
                          orderby p.nombrehotel
                          select new { idHotel = p.idHotel, Hotel = p.nombrehotel };
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getTipoHabitacion(int? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var results = from p in db.tb_tipohabitacion
                          where p.idHotel == id
                          orderby p.NombreTipoHabitacion
                          select new { idTipoHabitacion = p.idTipoHabitacion, TipoHabitacion = p.NombreTipoHabitacion };
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getPreTraslado(int? op, int? ds, DateTime? fechain, DateTime? fechaout)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var results = from p in db.tb_traslado
                          where p.id_operador == op && p.id_puntosalida == ds && p.fecha_vigencia >= fechain && p.fecha_vigencia >= fechaout
                          orderby p.id_traslado
                          select new { idTraslado = p.id_traslado};
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getTraslado(int? it, int? dll)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var results = from p in db.tb_detalleTraslado
                          where p.id_traslado == it && p.id_destino == dll 
                          orderby p.id_traslado
                          select new {
                              tramo = p.tb_categoria.nombreCategoria,
                              destinoll = p.tb_ciudad.nombreCiudad,
                              precio_compartido = p.precio_compartido,
                              rango1a_priv = p.rango1a_priv,
                              rango2a_priv = p.rango2a_priv,
                              precioa_priv = p.precioa_priv,
                              rango1b_priv = p.rango1b_priv,
                              rango2b_priv = p.rango2b_priv,
                              preciob_priv = p.preciob_priv,
                              rango1c_priv = p.rango1c_priv,
                              rango2c_priv = p.rango2c_priv,
                              precioc_priv = p.precioc_priv,
                              rango1d_lujo = p.rango1d_lujo,
                              rango2d_lujo = p.rango2d_lujo,
                              preciod_lujo = p.preciod_lujo,
                          };
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getPreTarifaHotelera(int? ch, int? ht, DateTime? fechaini, DateTime? fechaout)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var results = from p in db.tb_ingresohotel
                          where p.idCadena == ch && p.idHotel == ht && p.feccompraini <= fechaini && p.feccomprafin >= fechaout
                          select new { idIngresoHotel = p.idIngresoHotel };
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getTarifaHotelera(int? ih, int? th)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var results = from p in db.tb_detalleingresohotel
                          where p.idIngresoHotel == ih && p.idTipoHabitacion == th
                          select new
                          {
                              doblereal = p.doblereal,
                              triplereal = p.triplereal,
                              cuadruplereal = p.cuadruplereal,
                              simplereal = p.simplereal,
                              quituplereal = p.quituplereal,
                              sextuplereal = p.sextuplereal,
                              child1real = p.child1real,
                              edad1child1 = p.edad1child1,
                              edad2child1 = p.edad2child1,
                              child2real = p.child2real,
                              edad1child2 = p.edad1child2,
                              edad2child2 = p.edad2child2,
                              child3real = p.child3real,
                              edad1child3 = p.edad1child3,
                              edad2child3 = p.edad2child3,
                              infantereal = p.infantereal,
                              edadinfante1 = p.edadinfante1,
                              edadinfante2 = p.edadinfante2,
                              capmaximaadu = p.capmaximaadu,
                              capmaximanin = p.capmaximanin,
                              serviciohabitacion1 = p.serviciohabitacion1,
                              serviciohabitacion2 = p.serviciohabitacion2,
                              preciserviciodoble1 = p.preciserviciodoble1,
                              preciserviciotriple1 = p.preciserviciotriple1,
                              preciserviciocuadruple1 = p.preciserviciocuadruple1,
                              preciserviciosimple1 = p.preciserviciosimple1,
                              preciservicioquintuple1 = p.preciservicioquintuple1,
                              preciserviciosextuple1 = p.preciserviciosextuple1,
                              preciserviciodoble2 = p.preciserviciodoble2,
                              preciserviciotriple2 = p.preciserviciotriple2,
                              preciserviciocuadruple2 = p.preciserviciocuadruple2,
                              preciserviciosimple2 = p.preciserviciosimple2,
                              preciservicioquintuple2 = p.preciservicioquintuple2,
                              preciserviciosextuple2 = p.preciserviciosextuple2,
                              tipohabitacion = p.tb_tipohabitacion.NombreTipoHabitacion
                          };
            return Json(results, JsonRequestBehavior.AllowGet);
        }
    }
}
