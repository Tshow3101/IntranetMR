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
    public class ZonaController : Controller
    {
        private ModeloMR db = new ModeloMR();

        // GET: Zona
        public ActionResult Index()
        {
            return View(db.tb_zona.ToList());
        }

        // GET: Zona/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_zona tb_zona = db.tb_zona.Find(id);
            if (tb_zona == null)
            {
                return HttpNotFound();
            }
            return View(tb_zona);
        }

        // GET: Zona/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zona/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idZona,nombreZona,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_zona tb_zona)
        {
            if (ModelState.IsValid)
            {
                tb_zona.fecharegistro = DateTime.Today;
                tb_zona.usuarioregistro = 1;
                db.tb_zona.Add(tb_zona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_zona);
        }

        // GET: Zona/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_zona tb_zona = db.tb_zona.Find(id);
            if (tb_zona == null)
            {
                return HttpNotFound();
            }
            return View(tb_zona);
        }

        // POST: Zona/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idZona,nombreZona,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_zona tb_zona)
        {
            if (ModelState.IsValid)
            {
                tb_zona.fechamodificacion = DateTime.Today;
                tb_zona.usuariomodificacion = 1;
                db.Entry(tb_zona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_zona);
        }

        // GET: Zona/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_zona tb_zona = db.tb_zona.Find(id);
            if (tb_zona == null)
            {
                return HttpNotFound();
            }
            return View(tb_zona);
        }

        // POST: Zona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_zona tb_zona = db.tb_zona.Find(id);
            db.tb_zona.Remove(tb_zona);
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
