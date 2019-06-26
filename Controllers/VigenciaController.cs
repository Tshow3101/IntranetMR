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
    public class VigenciaController : Controller
    {
        private ModeloMR db = new ModeloMR();

        // GET: Vigencia
        public ActionResult Index()
        {
            return View(db.tb_vigencia.ToList());
        }

        // GET: Vigencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_vigencia tb_vigencia = db.tb_vigencia.Find(id);
            if (tb_vigencia == null)
            {
                return HttpNotFound();
            }
            return View(tb_vigencia);
        }

        // GET: Vigencia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vigencia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVigencia,nombreVigencia,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_vigencia tb_vigencia)
        {
            if (ModelState.IsValid)
            {
                tb_vigencia.fecharegistro = DateTime.Today;
                tb_vigencia.usuarioregistro = 1;
                db.tb_vigencia.Add(tb_vigencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_vigencia);
        }

        // GET: Vigencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_vigencia tb_vigencia = db.tb_vigencia.Find(id);
            if (tb_vigencia == null)
            {
                return HttpNotFound();
            }
            return View(tb_vigencia);
        }

        // POST: Vigencia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVigencia,nombreVigencia,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_vigencia tb_vigencia)
        {
            if (ModelState.IsValid)
            {
                tb_vigencia.usuariomodificacion = 1;
                tb_vigencia.fechamodificacion = DateTime.Today;
                db.Entry(tb_vigencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_vigencia);
        }

        // GET: Vigencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_vigencia tb_vigencia = db.tb_vigencia.Find(id);
            if (tb_vigencia == null)
            {
                return HttpNotFound();
            }
            return View(tb_vigencia);
        }

        // POST: Vigencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_vigencia tb_vigencia = db.tb_vigencia.Find(id);
            db.tb_vigencia.Remove(tb_vigencia);
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
