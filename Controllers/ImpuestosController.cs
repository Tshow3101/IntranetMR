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
    public class ImpuestosController : Controller
    {
        private ModeloMR db = new ModeloMR();

        // GET: Impuestos
        public ActionResult Index()
        {
            return View(db.tb_impuestos.ToList());
        }

        // GET: Impuestos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_impuestos tb_impuestos = db.tb_impuestos.Find(id);
            if (tb_impuestos == null)
            {
                return HttpNotFound();
            }
            return View(tb_impuestos);
        }

        // GET: Impuestos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Impuestos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idImpuestos,nombreImpuesto,precioImpuesto,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_impuestos tb_impuestos)
        {
            if (ModelState.IsValid)
            {
                tb_impuestos.fecharegistro = DateTime.Today;
                tb_impuestos.usuarioregistro = 1;
                db.tb_impuestos.Add(tb_impuestos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_impuestos);
        }

        // GET: Impuestos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_impuestos tb_impuestos = db.tb_impuestos.Find(id);
            if (tb_impuestos == null)
            {
                return HttpNotFound();
            }
            return View(tb_impuestos);
        }

        // POST: Impuestos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idImpuestos,nombreImpuesto,precioImpuesto,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_impuestos tb_impuestos)
        {
            if (ModelState.IsValid)
            {
                tb_impuestos.fechamodificacion = DateTime.Today;
                tb_impuestos.usuariomodificacion = 1;
                db.Entry(tb_impuestos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_impuestos);
        }

        // GET: Impuestos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_impuestos tb_impuestos = db.tb_impuestos.Find(id);
            if (tb_impuestos == null)
            {
                return HttpNotFound();
            }
            return View(tb_impuestos);
        }

        // POST: Impuestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_impuestos tb_impuestos = db.tb_impuestos.Find(id);
            db.tb_impuestos.Remove(tb_impuestos);
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
