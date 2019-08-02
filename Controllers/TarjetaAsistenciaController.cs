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
    public class TarjetaAsistenciaController : Controller
    {
        private ModeloMR db = new ModeloMR();

        // GET: TarjetaAsistencia
        public ActionResult Index()
        {
            var tb_tarjetaasistencia = db.tb_tarjetaasistencia.Include(t => t.tb_usuario);
            return View(tb_tarjetaasistencia.ToList());
        }

        // GET: TarjetaAsistencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tarjetaasistencia tb_tarjetaasistencia = db.tb_tarjetaasistencia.Find(id);
            if (tb_tarjetaasistencia == null)
            {
                return HttpNotFound();
            }
            return View(tb_tarjetaasistencia);
        }

        // GET: TarjetaAsistencia/Create
        public ActionResult Create()
        {
            ViewBag.idOperador = new SelectList(db.tb_usuario.Where(x => x.TIPOUSUARIO == 56), "idUsuario", "nombreusuario");
            return View();
        }

        // POST: TarjetaAsistencia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTarjetaasistencia,nombreTarjetaasistencia,idOperador,cobertura,costo")] tb_tarjetaasistencia tb_tarjetaasistencia)
        {
            if (ModelState.IsValid)
            {
                db.tb_tarjetaasistencia.Add(tb_tarjetaasistencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idOperador = new SelectList(db.tb_usuario, "idUsuario", "apellidopaternousuario", tb_tarjetaasistencia.idOperador);
            return View(tb_tarjetaasistencia);
        }

        // GET: TarjetaAsistencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tarjetaasistencia tb_tarjetaasistencia = db.tb_tarjetaasistencia.Find(id);
            if (tb_tarjetaasistencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.idOperador = new SelectList(db.tb_usuario.Where(x => x.TIPOUSUARIO == 56), "idUsuario", "nombreusuario");
            return View(tb_tarjetaasistencia);
        }

        // POST: TarjetaAsistencia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTarjetaasistencia,nombreTarjetaasistencia,idOperador,cobertura,costo")] tb_tarjetaasistencia tb_tarjetaasistencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_tarjetaasistencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idOperador = new SelectList(db.tb_usuario, "idUsuario", "apellidopaternousuario", tb_tarjetaasistencia.idOperador);
            return View(tb_tarjetaasistencia);
        }

        // GET: TarjetaAsistencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tarjetaasistencia tb_tarjetaasistencia = db.tb_tarjetaasistencia.Find(id);
            if (tb_tarjetaasistencia == null)
            {
                return HttpNotFound();
            }
            return View(tb_tarjetaasistencia);
        }

        // POST: TarjetaAsistencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_tarjetaasistencia tb_tarjetaasistencia = db.tb_tarjetaasistencia.Find(id);
            db.tb_tarjetaasistencia.Remove(tb_tarjetaasistencia);
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
