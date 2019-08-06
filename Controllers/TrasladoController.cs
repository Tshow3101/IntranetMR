using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IntranetMundoRepresentaciones.Models;
using Rotativa;

namespace IntranetMundoRepresentaciones.Controllers
{
    public class TrasladoController : Controller
    {
        private ModeloMR db = new ModeloMR();

        // GET: Traslado
        public ActionResult Index()
        {
            var tb_traslado = db.tb_traslado.Where(x => x.estado == 1).Include(t => t.tb_ciudad).Include(t => t.tb_usuario);
            return View(tb_traslado.ToList());
        }

        // GET: Traslado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_traslado tb_traslado = db.tb_traslado.Find(id);
            if (tb_traslado == null)
            {
                return HttpNotFound();
            }
            return View(tb_traslado);
        }

        public JsonResult DarDeBaja(tb_traslado tb_traslado, int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            bool status = false;
            var t = db.tb_traslado.Find(id);

            using (db)
            {

                t.estado = 2;
                db.Entry(t).State = EntityState.Modified;
                db.SaveChanges();

                status = true;
            }

            return new JsonResult { Data = new { status = status } };
        }

        public ActionResult DetailsR(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_traslado tb_traslado = db.tb_traslado.Find(id);
            if (tb_traslado == null)
            {
                return HttpNotFound();
            }
            return View(tb_traslado);
        }

        // GET: Traslado/Create
        public ActionResult Create()
        {
            ViewBag.id_puntosalida = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad");
            ViewBag.id_operador = new SelectList(db.tb_usuario.Where(x => x.TIPOUSUARIO == 56), "idUsuario", "nombreusuario");
            return View();
        }

        // POST: Traslado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_traslado,id_operador,id_puntosalida,fecha_vigencia")] tb_traslado tb_traslado)
        {
            if (ModelState.IsValid)
            {
                db.tb_traslado.Add(tb_traslado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_puntosalida = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_traslado.id_puntosalida);
            ViewBag.id_operador = new SelectList(db.tb_usuario, "idUsuario", "nombreusuario", tb_traslado.id_operador);
            return View(tb_traslado);
        }

        // GET: Traslado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_traslado tb_traslado = db.tb_traslado.Find(id);
            if (tb_traslado == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_puntosalida = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_traslado.id_puntosalida);
            ViewBag.id_operador = new SelectList(db.tb_usuario, "idUsuario", "nombreusuario", tb_traslado.id_operador);
            return View(tb_traslado);
        }

        // POST: Traslado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_traslado,id_operador,id_puntosalida,fecha_vigencia")] tb_traslado tb_traslado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_traslado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_puntosalida = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_traslado.id_puntosalida);
            ViewBag.id_operador = new SelectList(db.tb_usuario, "idUsuario", "nombreusuario", tb_traslado.id_operador);
            return View(tb_traslado);
        }

        public JsonResult getDestinos()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var results = from p in db.tb_ciudad
                          orderby p.nombreCiudad
                          select new { idDestino = p.idCiudad, Destino = p.nombreCiudad };
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getTramo()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var results = from p in db.tb_categoria
                          where p.idTipocategoria == 36
                          orderby p.nombreCategoria
                          select new { idCategoria = p.idCategoria, Categoria = p.nombreCategoria };
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GeneratePDF(int? id)
        {
            tb_traslado tb_traslado = db.tb_traslado.Find(id);
            return new ActionAsPdf("DetailsR/" + id)
            {
                FileName = (tb_traslado.tb_usuario.nombreusuario + "_" + tb_traslado.tb_ciudad.nombreCiudad + ".pdf").ToUpper(),
                PageSize = Rotativa.Options.Size.A4,
                PageOrientation = Rotativa.Options.Orientation.Landscape,
                PageMargins = new Rotativa.Options.Margins(4, 2, 4, 2)
            };
        }

        // GET: Traslado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_traslado tb_traslado = db.tb_traslado.Find(id);
            if (tb_traslado == null)
            {
                return HttpNotFound();
            }
            return View(tb_traslado);
        }

        public JsonResult GuardarTraslado(tb_traslado tb_traslado)
        {
            bool status = false;

            var isValidModel = TryUpdateModel(tb_traslado);
            if (isValidModel)
            {
                using (db)
                {

                    db.tb_traslado.Add(tb_traslado);
                    db.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public ActionResult eliminaDetalles(List<tb_detalleTraslado> tb_detalleTraslado, int id = 0)
        {
            bool status = false;
            db.Database.ExecuteSqlCommand("DELETE FROM tb_detalleTraslado WHERE id_traslado = @id", new
            object[] { new System.Data.SqlClient.SqlParameter("id", id) });
            db.Database.Connection.Close();

            if (tb_detalleTraslado != null)
            {
                foreach (var det in tb_detalleTraslado)
                {
                    db.tb_detalleTraslado.Add(det);
                    db.SaveChanges();
                }
            }

            status = true;
            return new JsonResult { Data = new { status = status } };

        }

        public JsonResult EditarTraslado(tb_traslado tb_traslado)
        {
            bool status = false;
            var v = db.tb_traslado.Find(tb_traslado.id_traslado);
            using (db)
            {
                db.Entry(v).CurrentValues.SetValues(tb_traslado);
                db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

        // POST: Traslado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_traslado tb_traslado = db.tb_traslado.Find(id);
            db.tb_traslado.Remove(tb_traslado);
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
