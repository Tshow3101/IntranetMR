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
    public class CadenaHoteleraController : Controller
    {
        private ModeloMR db = new ModeloMR();

        // GET: CadenaHotelera
        public ActionResult Index()
        {
            var tb_cadenahotelera = db.tb_cadenahotelera.Include(t => t.tb_ciudad).Include(t => t.tb_pais).Include(t => t.tb_vigencia).Include(t => t.tb_zona);
            return View(tb_cadenahotelera.ToList());
        }

        // GET: CadenaHotelera/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_cadenahotelera tb_cadenahotelera = db.tb_cadenahotelera.Find(id);
            if (tb_cadenahotelera == null)
            {
                return HttpNotFound();
            }
            return View(tb_cadenahotelera);
        }

        // GET: CadenaHotelera/Create
        public ActionResult Create()
        {
            ViewBag.idCiudad = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad");
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais");
            ViewBag.idVigencia = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia");
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona");
            return View();
        }

        // POST: CadenaHotelera/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCadenaHotelera,nombreCadenaHotelera,idZona,idPais,idCiudad,DireccionCadenaHotelera,ContactoCadenaHotelera,CorreoCadenaHotelera,Telefono1CadenaHotelera,Telefono2CadenaHotelera,LogoCadenaHotelera,PaginaWebCadenaHotelera,idVigencia,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_cadenahotelera tb_cadenahotelera)
        {
            if (ModelState.IsValid)
            {
                tb_cadenahotelera.fecharegistro = DateTime.Today;
                tb_cadenahotelera.usuarioregistro = 1;
                tb_cadenahotelera.idVigencia = 1;
                db.tb_cadenahotelera.Add(tb_cadenahotelera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCiudad = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_cadenahotelera.idCiudad);
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_cadenahotelera.idPais);
            ViewBag.idVigencia = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_cadenahotelera.idVigencia);
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_cadenahotelera.idZona);
            return View(tb_cadenahotelera);
        }

        // GET: CadenaHotelera/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_cadenahotelera tb_cadenahotelera = db.tb_cadenahotelera.Find(id);
            if (tb_cadenahotelera == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCiudad = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_cadenahotelera.idCiudad);
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_cadenahotelera.idPais);
            ViewBag.idVigencia = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_cadenahotelera.idVigencia);
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_cadenahotelera.idZona);
            return View(tb_cadenahotelera);
        }

        // POST: CadenaHotelera/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCadenaHotelera,nombreCadenaHotelera,idZona,idPais,idCiudad,DireccionCadenaHotelera,ContactoCadenaHotelera,CorreoCadenaHotelera,Telefono1CadenaHotelera,Telefono2CadenaHotelera,LogoCadenaHotelera,PaginaWebCadenaHotelera,idVigencia,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_cadenahotelera tb_cadenahotelera)
        {
            if (ModelState.IsValid)
            {
                tb_cadenahotelera.fechamodificacion = DateTime.Today;
                tb_cadenahotelera.usuariomodificacion = 1;
                db.Entry(tb_cadenahotelera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCiudad = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_cadenahotelera.idCiudad);
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_cadenahotelera.idPais);
            ViewBag.idVigencia = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_cadenahotelera.idVigencia);
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_cadenahotelera.idZona);
            return View(tb_cadenahotelera);
        }

        // GET: CadenaHotelera/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_cadenahotelera tb_cadenahotelera = db.tb_cadenahotelera.Find(id);
            if (tb_cadenahotelera == null)
            {
                return HttpNotFound();
            }
            return View(tb_cadenahotelera);
        }

        // POST: CadenaHotelera/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_cadenahotelera tb_cadenahotelera = db.tb_cadenahotelera.Find(id);
            tb_cadenahotelera.idVigencia = 2;
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
