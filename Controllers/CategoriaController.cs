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
    public class CategoriaController : Controller
    {
        private ModeloMR db = new ModeloMR();

        // GET: Categoria
        public ActionResult Index()
        {
            var tb_categoria = db.tb_categoria.Include(t => t.tb_tipocategoria);
            return View(tb_categoria.ToList());
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_categoria tb_categoria = db.tb_categoria.Find(id);
            if (tb_categoria == null)
            {
                return HttpNotFound();
            }
            return View(tb_categoria);
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            ViewBag.idTipocategoria = new SelectList(db.tb_tipocategoria, "idTipocategoria", "nombreTipoCategoria");
            return View();
        }

        // POST: Categoria/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCategoria,nombreCategoria,idTipocategoria,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_categoria tb_categoria)
        {
            if (ModelState.IsValid)
            {
                tb_categoria.fecharegistro = DateTime.Today;
                tb_categoria.usuarioregistro = 1;
                db.tb_categoria.Add(tb_categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTipocategoria = new SelectList(db.tb_tipocategoria, "idTipocategoria", "nombreTipoCategoria", tb_categoria.idTipocategoria);
            return View(tb_categoria);
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_categoria tb_categoria = db.tb_categoria.Find(id);
            if (tb_categoria == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTipocategoria = new SelectList(db.tb_tipocategoria, "idTipocategoria", "nombreTipoCategoria", tb_categoria.idTipocategoria);
            return View(tb_categoria);
        }

        // POST: Categoria/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCategoria,nombreCategoria,idTipocategoria,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_categoria tb_categoria)
        {
            if (ModelState.IsValid)
            {
                tb_categoria.fechamodificacion = DateTime.Today;
                tb_categoria.usuariomodificacion = 1;
                db.Entry(tb_categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTipocategoria = new SelectList(db.tb_tipocategoria, "idTipocategoria", "nombreTipoCategoria", tb_categoria.idTipocategoria);
            return View(tb_categoria);
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_categoria tb_categoria = db.tb_categoria.Find(id);
            if (tb_categoria == null)
            {
                return HttpNotFound();
            }
            return View(tb_categoria);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_categoria tb_categoria = db.tb_categoria.Find(id);
            db.tb_categoria.Remove(tb_categoria);
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
