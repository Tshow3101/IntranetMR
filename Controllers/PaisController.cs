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
    public class PaisController : Controller
    {
        private ModeloMR db = new ModeloMR();

        // GET: Pais
        public ActionResult Index()
        {
            var tb_pais = db.tb_pais.Include(t => t.tb_zona);
            return View(tb_pais.ToList());
        }

        // GET: Pais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_pais tb_pais = db.tb_pais.Find(id);
            if (tb_pais == null)
            {
                return HttpNotFound();
            }
            return View(tb_pais);
        }

        // GET: Pais/Create
        public ActionResult Create()
        {
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona");
            return View();
        }

        // POST: Pais/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPais,NombrePais,idZona,fotoPais,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_pais tb_pais)
        {
            if (ModelState.IsValid)
            {
                tb_pais.fecharegistro = DateTime.Today;
                tb_pais.usuarioregistro = 1;
                db.tb_pais.Add(tb_pais);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_pais.idZona);
            return View(tb_pais);
        }

        // GET: Pais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_pais tb_pais = db.tb_pais.Find(id);
            if (tb_pais == null)
            {
                return HttpNotFound();
            }
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_pais.idZona);
            return View(tb_pais);
        }

        // POST: Pais/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPais,NombrePais,idZona,fotoPais,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_pais tb_pais)
        {
            if (ModelState.IsValid)
            {
                tb_pais.fechamodificacion = DateTime.Today;
                tb_pais.usuariomodificacion = 1;
                db.Entry(tb_pais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_pais.idZona);
            return View(tb_pais);
        }

        // GET: Pais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_pais tb_pais = db.tb_pais.Find(id);
            if (tb_pais == null)
            {
                return HttpNotFound();
            }
            return View(tb_pais);
        }

        // POST: Pais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_pais tb_pais = db.tb_pais.Find(id);
            db.tb_pais.Remove(tb_pais);
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
