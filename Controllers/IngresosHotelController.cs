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
    public class IngresosHotelController : Controller
    {
        private ModeloMR db = new ModeloMR();

        // GET: IngresosHotel
        public ActionResult Index()
        {
            var tb_ingresohotel = db.tb_ingresohotel.Include(t => t.tb_cadenahotelera).Include(t => t.tb_categoria).Include(t => t.tb_hotel).Include(t => t.tb_tipohabitacion);
            return View(tb_ingresohotel.ToList());
        }

        // GET: IngresosHotel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ingresohotel tb_ingresohotel = db.tb_ingresohotel.Find(id);
            if (tb_ingresohotel == null)
            {
                return HttpNotFound();
            }
            return View(tb_ingresohotel);
        }

        // GET: IngresosHotel/Create
        public ActionResult Create()
        {
            ViewBag.idCadena = new SelectList(db.tb_cadenahotelera, "idCadenaHotelera", "nombreCadenaHotelera");            
            ViewBag.tarifa = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 17), "idCategoria", "nombreCategoria");
            ViewBag.idHotel = new SelectList(db.tb_hotel, "idHotel", "nombrehotel");
            ViewBag.idTipoHabitacion = new SelectList(db.tb_tipohabitacion, "idTipoHabitacion", "NombreTipoHabitacion");
            return View();
        }

        // POST: IngresosHotel/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idIngresoHotel,fecviajeini,fecviajefin,feccompraini,feccomprafin,tarifa,codprom,idCadena,idHotel,idTipoHabitacion,montoadulto,montoniño,porcentaje,doble,doblereal,triple,triplereal,cuadruple,cuadruplereal,simple,simplereal,quintuple,quituplereal,sextuple,sextuplereal,child1,child1real,edad1child1,edad2child1,child2,child2real,edad1child2,edad2child2,child3,child3real,edad1child3,edad2child3,infante,infantereal,edadinfante1,edadinfante2,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_ingresohotel tb_ingresohotel)
        {
            if (ModelState.IsValid)
            {
                db.tb_ingresohotel.Add(tb_ingresohotel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCadena = new SelectList(db.tb_cadenahotelera, "idCadenaHotelera", "nombreCadenaHotelera", tb_ingresohotel.idCadena);
            ViewBag.tarifa = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_ingresohotel.tarifa);
            ViewBag.idHotel = new SelectList(db.tb_hotel, "idHotel", "nombrehotel", tb_ingresohotel.idHotel);
            ViewBag.idTipoHabitacion = new SelectList(db.tb_tipohabitacion, "idTipoHabitacion", "NombreTipoHabitacion", tb_ingresohotel.idTipoHabitacion);
            return View(tb_ingresohotel);
        }

        // GET: IngresosHotel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ingresohotel tb_ingresohotel = db.tb_ingresohotel.Find(id);
            if (tb_ingresohotel == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCadena = new SelectList(db.tb_cadenahotelera, "idCadenaHotelera", "nombreCadenaHotelera", tb_ingresohotel.idCadena);
            ViewBag.edad1child1 = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_ingresohotel.edad1child1);
            ViewBag.edad1child2 = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_ingresohotel.edad1child2);
            ViewBag.edad1child3 = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_ingresohotel.edad1child3);
            ViewBag.edad2child1 = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_ingresohotel.edad2child1);
            ViewBag.edad2child2 = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_ingresohotel.edad2child2);
            ViewBag.edad2child3 = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_ingresohotel.edad2child3);
            ViewBag.tarifa = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_ingresohotel.tarifa);
            ViewBag.idHotel = new SelectList(db.tb_hotel, "idHotel", "nombrehotel", tb_ingresohotel.idHotel);
            ViewBag.idTipoHabitacion = new SelectList(db.tb_tipohabitacion, "idTipoHabitacion", "NombreTipoHabitacion", tb_ingresohotel.idTipoHabitacion);
            return View(tb_ingresohotel);
        }

        // POST: IngresosHotel/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idIngresoHotel,fecviajeini,fecviajefin,feccompraini,feccomprafin,tarifa,codprom,idCadena,idHotel,idTipoHabitacion,montoadulto,montoniño,porcentaje,doble,doblereal,triple,triplereal,cuadruple,cuadruplereal,simple,simplereal,quintuple,quituplereal,sextuple,sextuplereal,child1,child1real,edad1child1,edad2child1,child2,child2real,edad1child2,edad2child2,child3,child3real,edad1child3,edad2child3,infante,infantereal,edadinfante1,edadinfante2,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_ingresohotel tb_ingresohotel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_ingresohotel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCadena = new SelectList(db.tb_cadenahotelera, "idCadenaHotelera", "nombreCadenaHotelera", tb_ingresohotel.idCadena);
            ViewBag.edad1child1 = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_ingresohotel.edad1child1);
            ViewBag.edad1child2 = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_ingresohotel.edad1child2);
            ViewBag.edad1child3 = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_ingresohotel.edad1child3);
            ViewBag.edad2child1 = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_ingresohotel.edad2child1);
            ViewBag.edad2child2 = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_ingresohotel.edad2child2);
            ViewBag.edad2child3 = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_ingresohotel.edad2child3);
            ViewBag.tarifa = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_ingresohotel.tarifa);
            ViewBag.idHotel = new SelectList(db.tb_hotel, "idHotel", "nombrehotel", tb_ingresohotel.idHotel);
            ViewBag.idTipoHabitacion = new SelectList(db.tb_tipohabitacion, "idTipoHabitacion", "NombreTipoHabitacion", tb_ingresohotel.idTipoHabitacion);
            return View(tb_ingresohotel);
        }

        // GET: IngresosHotel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ingresohotel tb_ingresohotel = db.tb_ingresohotel.Find(id);
            if (tb_ingresohotel == null)
            {
                return HttpNotFound();
            }
            return View(tb_ingresohotel);
        }

        // POST: IngresosHotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_ingresohotel tb_ingresohotel = db.tb_ingresohotel.Find(id);
            db.tb_ingresohotel.Remove(tb_ingresohotel);
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
