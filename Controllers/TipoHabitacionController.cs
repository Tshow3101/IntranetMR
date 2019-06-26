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
    public class TipoHabitacionController : Controller
    {
        private ModeloMR db = new ModeloMR();

        // GET: TipoHabitacion
        public ActionResult Index()
        {
            var tb_tipohabitacion = db.tb_tipohabitacion.Include(t => t.tb_cadenahotelera).Include(t => t.tb_hotel);
            return View(tb_tipohabitacion.ToList());
        }

        // GET: TipoHabitacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipohabitacion tb_tipohabitacion = db.tb_tipohabitacion.Find(id);
            if (tb_tipohabitacion == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipohabitacion);
        }

        // GET: TipoHabitacion/Create
        public ActionResult Create()
        {
            ViewBag.idCadenaHotelera = new SelectList(db.tb_cadenahotelera, "idCadenaHotelera", "nombreCadenaHotelera");
            ViewBag.idHotel = new SelectList(db.tb_hotel, "idHotel", "nombrehotel");
            return View();
        }

        // POST: TipoHabitacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoHabitacion,NombreTipoHabitacion,idCadenaHotelera,idHotel,capacidadmaxima,camasmaximas,descripcion,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_tipohabitacion tb_tipohabitacion)
        {
            if (ModelState.IsValid)
            {
                tb_tipohabitacion.fecharegistro = DateTime.Today;
                tb_tipohabitacion.usuarioregistro = 1;
                db.tb_tipohabitacion.Add(tb_tipohabitacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCadenaHotelera = new SelectList(db.tb_cadenahotelera, "idCadenaHotelera", "nombreCadenaHotelera", tb_tipohabitacion.idCadenaHotelera);
            ViewBag.idHotel = new SelectList(db.tb_hotel, "idHotel", "nombrehotel", tb_tipohabitacion.idHotel);
            return View(tb_tipohabitacion);
        }

        // GET: TipoHabitacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipohabitacion tb_tipohabitacion = db.tb_tipohabitacion.Find(id);
            if (tb_tipohabitacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCadenaHotelera = new SelectList(db.tb_cadenahotelera, "idCadenaHotelera", "nombreCadenaHotelera", tb_tipohabitacion.idCadenaHotelera);
            ViewBag.idHotel = new SelectList(db.tb_hotel, "idHotel", "nombrehotel", tb_tipohabitacion.idHotel);
            return View(tb_tipohabitacion);
        }

        // POST: TipoHabitacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoHabitacion,NombreTipoHabitacion,idCadenaHotelera,idHotel,capacidadmaxima,camasmaximas,descripcion,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_tipohabitacion tb_tipohabitacion)
        {
            if (ModelState.IsValid)
            {
                tb_tipohabitacion.fechamodificacion = DateTime.Today;
                tb_tipohabitacion.usuariomodificacion = 1;
                db.Entry(tb_tipohabitacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCadenaHotelera = new SelectList(db.tb_cadenahotelera, "idCadenaHotelera", "nombreCadenaHotelera", tb_tipohabitacion.idCadenaHotelera);
            ViewBag.idHotel = new SelectList(db.tb_hotel, "idHotel", "nombrehotel", tb_tipohabitacion.idHotel);
            return View(tb_tipohabitacion);
        }

        // GET: TipoHabitacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipohabitacion tb_tipohabitacion = db.tb_tipohabitacion.Find(id);
            if (tb_tipohabitacion == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipohabitacion);
        }

        // POST: TipoHabitacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_tipohabitacion tb_tipohabitacion = db.tb_tipohabitacion.Find(id);
            db.tb_tipohabitacion.Remove(tb_tipohabitacion);
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
    }
}
