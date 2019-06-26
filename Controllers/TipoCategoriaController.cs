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
    public class TipoCategoriaController : Controller
    {
        private ModeloMR db = new ModeloMR();

        // GET: TipoCategoria
        public ActionResult Index()
        {
            return View(db.tb_tipocategoria.ToList());
        }

        // GET: TipoCategoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipocategoria tb_tipocategoria = db.tb_tipocategoria.Find(id);
            if (tb_tipocategoria == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipocategoria);
        }

        // GET: TipoCategoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoCategoria/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipocategoria,nombreTipoCategoria,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_tipocategoria tb_tipocategoria)
        {
            if (ModelState.IsValid)
            {
                tb_tipocategoria.fecharegistro = DateTime.Today;
                tb_tipocategoria.usuarioregistro = 1;/*Usuario Administrador*/
                db.tb_tipocategoria.Add(tb_tipocategoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_tipocategoria);
        }

        // GET: TipoCategoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipocategoria tb_tipocategoria = db.tb_tipocategoria.Find(id);
            if (tb_tipocategoria == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipocategoria);
        }

        // POST: TipoCategoria/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipocategoria,nombreTipoCategoria,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_tipocategoria tb_tipocategoria)
        {
            if (ModelState.IsValid)
            {
                tb_tipocategoria.usuariomodificacion = 1;/*Usuario Administrador*/
                tb_tipocategoria.fechamodificacion = DateTime.Today;
                db.Entry(tb_tipocategoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_tipocategoria);
        }

        // GET: TipoCategoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipocategoria tb_tipocategoria = db.tb_tipocategoria.Find(id);
            if (tb_tipocategoria == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipocategoria);
        }

        // POST: TipoCategoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_tipocategoria tb_tipocategoria = db.tb_tipocategoria.Find(id);
            db.tb_tipocategoria.Remove(tb_tipocategoria);
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
