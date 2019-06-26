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
    public class CiudadController : Controller
    {
        private ModeloMR db = new ModeloMR();

        // GET: Ciudad
        public ActionResult Index()
        {
            var tb_ciudad = db.tb_ciudad.Include(t => t.tb_pais).Include(t => t.tb_zona);
            return View(tb_ciudad.ToList());
        }

        // GET: Ciudad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ciudad tb_ciudad = db.tb_ciudad.Find(id);
            if (tb_ciudad == null)
            {
                return HttpNotFound();
            }
            return View(tb_ciudad);
        }

        // GET: Ciudad/Create
        public ActionResult Create()
        {
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais");
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona");
            return View();
        }

        // POST: Ciudad/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCiudad,nombreCiudad,CodigoCiudad,idPais,idZona,fotoCiudad,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_ciudad tb_ciudad)
        {
            if (ModelState.IsValid)
            {
                tb_ciudad.fecharegistro = DateTime.Today;
                tb_ciudad.usuarioregistro = 1;
                db.tb_ciudad.Add(tb_ciudad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_ciudad.idPais);
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_ciudad.idZona);
            return View(tb_ciudad);
        }

        // GET: Ciudad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ciudad tb_ciudad = db.tb_ciudad.Find(id);
            if (tb_ciudad == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_ciudad.idPais);
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_ciudad.idZona);
            return View(tb_ciudad);
        }

        // POST: Ciudad/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCiudad,nombreCiudad,CodigoCiudad,idPais,idZona,fotoCiudad,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_ciudad tb_ciudad)
        {
            if (ModelState.IsValid)
            {
                tb_ciudad.fechamodificacion = DateTime.Today;
                tb_ciudad.usuariomodificacion = 1;
                db.Entry(tb_ciudad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_ciudad.idPais);
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_ciudad.idZona);
            return View(tb_ciudad);
        }

        // GET: Ciudad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ciudad tb_ciudad = db.tb_ciudad.Find(id);
            if (tb_ciudad == null)
            {
                return HttpNotFound();
            }
            return View(tb_ciudad);
        }

        // POST: Ciudad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_ciudad tb_ciudad = db.tb_ciudad.Find(id);
            db.tb_ciudad.Remove(tb_ciudad);
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
