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
    public class TarifaAereaController : Controller
    {
        private ModeloMR db = new ModeloMR();

        // GET: TarifaAerea
        // GET: TarifaAerea
        public ActionResult Index()
        {
            var tb_tarifa_aerea = db.tb_tarifa_aerea.Where(t => t.estado == 1).Include(t => t.tb_aerolinea).Include(t => t.tb_ciudad).Include(t => t.tb_pais).Include(t => t.tb_zona);
            return View(tb_tarifa_aerea.ToList());
        }

        // GET: TarifaAerea/Details/5
        public ActionResult Details(int id)
        {
            tb_tarifa_aerea tb_tarifa_aerea = db.tb_tarifa_aerea.Find(id);
            if (tb_tarifa_aerea == null)
            {
                return HttpNotFound();
            }
            return View(tb_tarifa_aerea);
        }

        public ActionResult DetailsR(int id)
        {
            tb_tarifa_aerea tb_tarifa_aerea = db.tb_tarifa_aerea.Find(id);
            if (tb_tarifa_aerea == null)
            {
                return HttpNotFound();
            }
            return View(tb_tarifa_aerea);
        }

        public ActionResult GeneratePDF(int? id)
        {
            tb_tarifa_aerea tb_tarifa_aerea = db.tb_tarifa_aerea.Find(id);
            return new ActionAsPdf("DetailsR/" + id)
            {
                FileName = (tb_tarifa_aerea.tb_aerolinea.NombreComercial + "_" + tb_tarifa_aerea.clase + "_" + tb_tarifa_aerea.tipo_tarifa + ".pdf").ToUpper(),
                PageSize = Rotativa.Options.Size.A4,
                PageOrientation = Rotativa.Options.Orientation.Landscape,
                PageMargins = new Rotativa.Options.Margins(4, 2, 4, 2)
            };
        }

        public ActionResult consultar(int iddestino)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var llista = db.tb_tarifa_aerea.Where(x => x.id_ciudad == iddestino).OrderBy(x => x.total_tarifa).Select(x => new {
                x.tb_aerolinea.NombreComercial,
                x.tb_ciudad.nombreCiudad,
                x.clase,
                x.neto,
                x.queue,
                x.igv,
                x.total_tarifa,
                ta = x.tb_detalletarifaaerea.Select(y => new {
                    y.impuesto,
                    y.precio_impuesto
                })
            });
            return Json(llista, JsonRequestBehavior.AllowGet);
        }

        public ActionResult consultarn(int? iddestino, int? idlaerea)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var llistax = db.tb_tarifa_aerea.Where(x => x.id_ciudad == iddestino && x.id_laerea == idlaerea).OrderBy(x => x.total_tarifa).Select(x => new {
                x.tb_aerolinea.NombreComercial,
                x.tb_ciudad.nombreCiudad,
                x.clase,
                x.neto,
                x.queue,
                x.igv,
                x.total_tarifa,
                ta = x.tb_detalletarifaaerea.Select(y => new {
                    y.impuesto,
                    y.precio_impuesto
                })
            });
            return Json(llistax, JsonRequestBehavior.AllowGet);
        }

        // GET: TarifaAerea/Create
        public ActionResult Create()
        {
            ViewBag.id_laerea = new SelectList(db.tb_aerolinea, "idaerolinea", "NombreComercial").OrderBy(m => m.Text);
            ViewBag.id_destino = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad").OrderBy(m => m.Text);
            ViewBag.id_pais = new SelectList(db.tb_pais, "idPais", "NombrePais").OrderBy(m => m.Text);
            ViewBag.id_zona = new SelectList(db.tb_zona, "idZona", "nombreZona").OrderBy(m => m.Text);
            return View();
        }

        // POST: TarifaAerea/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tarifa_aerea,id_zona,id_pais,id_destino,clase,id_laerea,dest_abre,total_tarifa,neto,min_estadia,max_estadia,time_compra_1,time_compra_2,fecha_emisiion,porc_chd,prec_chd,porc_inf,prec_inf,edad_chd_1,edad_chd_2,edad_inf_1,edad_inf_2")] tb_tarifa_aerea tb_tarifa_aerea)
        {
            if (ModelState.IsValid)
            {
                db.tb_tarifa_aerea.Add(tb_tarifa_aerea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_laerea = new SelectList(db.tb_aerolinea, "idAerolinea", "NombreComercial", tb_tarifa_aerea.id_laerea).OrderBy(m => m.Text);
            ViewBag.id_destino = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_tarifa_aerea.id_ciudad).OrderBy(m => m.Text);
            ViewBag.id_pais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_tarifa_aerea.id_pais).OrderBy(m => m.Text); ;
            ViewBag.id_zona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_tarifa_aerea.id_zona).OrderBy(m => m.Text); ;
            return View(tb_tarifa_aerea);
        }

        // GET: TarifaAerea/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tarifa_aerea tb_tarifa_aerea = db.tb_tarifa_aerea.Find(id);
            if (tb_tarifa_aerea == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_laerea = new SelectList(db.tb_aerolinea, "idAerolinea", "NombreComercial", tb_tarifa_aerea.id_laerea);
            ViewBag.id_destino = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_tarifa_aerea.id_ciudad);
            ViewBag.id_pais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_tarifa_aerea.id_pais);
            ViewBag.id_zona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_tarifa_aerea.id_zona);
            return View(tb_tarifa_aerea);
        }

        // POST: TarifaAerea/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tarifa_aerea,id_zona,id_pais,id_destino,clase,id_laerea,dest_abre,total_tarifa,neto,min_estadia,max_estadia,time_compra_1,time_compra_2,fecha_emisiion,porc_chd,prec_chd,porc_inf,prec_inf,edad_chd_1,edad_chd_2,edad_inf_1,edad_inf_2")] tb_tarifa_aerea tb_tarifa_aerea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_tarifa_aerea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_laerea = new SelectList(db.tb_aerolinea, "idAerolinea", "NombreComercial", tb_tarifa_aerea.id_laerea);
            ViewBag.id_destino = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_tarifa_aerea.id_ciudad);
            ViewBag.id_pais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_tarifa_aerea.id_pais);
            ViewBag.id_zona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_tarifa_aerea.id_zona);
            return View(tb_tarifa_aerea);
        }

        // GET: TarifaAerea/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tarifa_aerea tb_tarifa_aerea = db.tb_tarifa_aerea.Find(id);
            if (tb_tarifa_aerea == null)
            {
                return HttpNotFound();
            }
            return View(tb_tarifa_aerea);
        }

        // POST: TarifaAerea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_tarifa_aerea tb_tarifa_aerea = db.tb_tarifa_aerea.Find(id);
            db.tb_tarifa_aerea.Remove(tb_tarifa_aerea);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult getPais(int id_zona)
        {
            return Json(new SelectList(db.tb_pais.Where(x => x.idZona == id_zona).ToList(), "idPais", "nombreZona").OrderBy(m => m.Text));
        }

        //public JsonResult getDestinos()
        //{
        //    db.Configuration.ProxyCreationEnabled = false;
        //    var results = from p in db.tb_imp_aereo
        //                  group p.tb_destino.desDestino by p.id_destino into g
        //                  select new { idDestino = g.Key, Destino = g.ToList() };
        //    return Json(results, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult getDestinos()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var results = from p in db.tb_ciudad
                          orderby p.nombreCiudad
                          select new { idDestino = p.idCiudad, Destino = p.nombreCiudad };
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getPaisx()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var resultsx = from x in db.tb_pais
                           orderby x.NombrePais
                           select new { idPais = x.idPais, Pais = x.NombrePais };
            return Json(resultsx, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GuardarTarifa(tb_tarifa_aerea tb_tarifa_aerea)
        {
            bool status = false;

            var isValidModel = TryUpdateModel(tb_tarifa_aerea);
            if (isValidModel)
            {
                using (db)
                {

                    db.tb_tarifa_aerea.Add(tb_tarifa_aerea);
                    db.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

        public JsonResult DarDeBaja(tb_tarifa_aerea tb_tarifa_aerea, int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            bool status = false;
            var t = db.tb_tarifa_aerea.Find(id);

            using (db)
            {

                t.estado = 0;
                db.Entry(t).State = EntityState.Modified;
                db.SaveChanges();

                status = true;
            }

            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public ActionResult eliminaDetalles(List<tb_detalletarifaaerea> tb_detalletarifaaerea, List<tb_detalletarifastopovers> tb_detalletarifastopovers, List<tb_detalletarifablackouts> tb_detalletarifablackouts, int id = 0)
        {
            bool status = false;
            db.Database.ExecuteSqlCommand("DELETE FROM tb_detalletarifaaerea WHERE id_tarifa_aerea = @id", new
            object[] { new System.Data.SqlClient.SqlParameter("id", id) });
            db.Database.Connection.Close();

            db.Database.ExecuteSqlCommand("DELETE FROM tb_detalletarifastopovers WHERE id_tarifa_aerea = @id", new
            object[] { new System.Data.SqlClient.SqlParameter("id", id) });
            db.Database.Connection.Close();

            db.Database.ExecuteSqlCommand("DELETE FROM tb_detalletarifablackouts WHERE id_tarifa_aerea = @id", new
            object[] { new System.Data.SqlClient.SqlParameter("id", id) });
            db.Database.Connection.Close();

            if (tb_detalletarifaaerea != null)
            {
                foreach (var det in tb_detalletarifaaerea)
                {
                    db.tb_detalletarifaaerea.Add(det);
                    db.SaveChanges();
                }
            }

            if (tb_detalletarifastopovers != null)
            {
                foreach (var det2 in tb_detalletarifastopovers)
                {
                    db.tb_detalletarifastopovers.Add(det2);
                    db.SaveChanges();
                }
            }

            if (tb_detalletarifablackouts != null)
            {
                foreach (var det2 in tb_detalletarifablackouts)
                {
                    db.tb_detalletarifablackouts.Add(det2);
                    db.SaveChanges();
                }
            }

            status = true;
            return new JsonResult { Data = new { status = status } };

        }

        public JsonResult EditarTarifa(tb_tarifa_aerea tb_tarifa_aerea)
        {
            bool status = false;
            var v = db.tb_tarifa_aerea.Find(tb_tarifa_aerea.id_tarifa_aerea);
            var isValidModel = TryUpdateModel(tb_tarifa_aerea);
            if (isValidModel)
            {
                using (db)
                {
                    db.Entry(v).CurrentValues.SetValues(tb_tarifa_aerea);
                    db.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
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
