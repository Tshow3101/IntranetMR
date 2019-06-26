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
    public class MonedaController : Controller
    {
        private ModeloMR db = new ModeloMR();

        // GET: Moneda
        public ActionResult Index()
        {
            return View(db.tb_moneda.ToList());
        }

        // GET: Moneda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_moneda tb_moneda = db.tb_moneda.Find(id);
            if (tb_moneda == null)
            {
                return HttpNotFound();
            }
            return View(tb_moneda);
        }

        // GET: Moneda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Moneda/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMoneda,NombreMoneda,precioMoneda,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_moneda tb_moneda)
        {
            if (ModelState.IsValid)
            {
                tb_moneda.fecharegistro = DateTime.Today;
                tb_moneda.usuarioregistro = 1;
                db.tb_moneda.Add(tb_moneda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_moneda);
        }

        // GET: Moneda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_moneda tb_moneda = db.tb_moneda.Find(id);
            if (tb_moneda == null)
            {
                return HttpNotFound();
            }
            return View(tb_moneda);
        }

        // POST: Moneda/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMoneda,NombreMoneda,precioMoneda,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_moneda tb_moneda)
        {
            if (ModelState.IsValid)
            {
                tb_moneda.fechamodificacion = DateTime.Today;
                tb_moneda.usuariomodificacion = 1;
                db.Entry(tb_moneda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_moneda);
        }

        // GET: Moneda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_moneda tb_moneda = db.tb_moneda.Find(id);
            if (tb_moneda == null)
            {
                return HttpNotFound();
            }
            return View(tb_moneda);
        }

        // POST: Moneda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_moneda tb_moneda = db.tb_moneda.Find(id);
            db.tb_moneda.Remove(tb_moneda);
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
