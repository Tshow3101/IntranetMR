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
    public class PaqueteController : Controller
    {
        private ModeloMR db = new ModeloMR();

        // GET: Paquete
        public ActionResult Index()
        {
            var tb_paquete = db.tb_paquete.Include(t => t.tb_categoria).Include(t => t.tb_ciudad).Include(t => t.tb_ciudad1).Include(t => t.tb_moneda).Include(t => t.tb_pais).Include(t => t.tb_tarjetaasistencia).Include(t => t.tb_tematica).Include(t => t.tb_zona);
            return View(tb_paquete.ToList());
        }

        // GET: Paquete/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_paquete tb_paquete = db.tb_paquete.Find(id);
            if (tb_paquete == null)
            {
                return HttpNotFound();
            }
            return View(tb_paquete);
        }

        // GET: Paquete/Create
        public ActionResult Create()
        {
            ViewBag.seccion = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 21), "idCategoria", "nombreCategoria");
            ViewBag.destino1 = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad");
            ViewBag.destino2 = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad");
            ViewBag.moneda = new SelectList(db.tb_moneda, "idMoneda", "NombreMoneda");
            ViewBag.pais = new SelectList(db.tb_pais, "idPais", "NombrePais");
            ViewBag.tarjetaasistencia = new SelectList(db.tb_tarjetaasistencia, "idTarjetaasistencia", "nombreTarjetaasistencia");
            ViewBag.tematica = new SelectList(db.tb_tematica, "idTematica", "nombretematica");
            ViewBag.zona = new SelectList(db.tb_zona, "idZona", "nombreZona");
            return View();
        }

        // POST: Paquete/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPaquete,incentivo,factor,comision,fechacompra,seccion,tematica,moneda,tipocambio,nombrepaquete,tempviajeini,tempviajefin,zona,pais,destino1,destino2,flyer,word,tarjetaasistencia,incluye,notas,fechacreacion,usuariocreacion,fechamodificacion,usuariomodificacion")] tb_paquete tb_paquete)
        {
            if (ModelState.IsValid)
            {
                db.tb_paquete.Add(tb_paquete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.seccion = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_paquete.seccion);
            ViewBag.destino1 = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_paquete.destino1);
            ViewBag.destino2 = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_paquete.destino2);
            ViewBag.moneda = new SelectList(db.tb_moneda, "idMoneda", "NombreMoneda", tb_paquete.moneda);
            ViewBag.pais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_paquete.pais);
            ViewBag.tarjetaasistencia = new SelectList(db.tb_tarjetaasistencia, "idTarjetaasistencia", "nombreTarjetaasistencia", tb_paquete.tarjetaasistencia);
            ViewBag.tematica = new SelectList(db.tb_tematica, "idTematica", "nombretematica", tb_paquete.tematica);
            ViewBag.zona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_paquete.zona);
            return View(tb_paquete);
        }

        // GET: Paquete/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_paquete tb_paquete = db.tb_paquete.Find(id);
            if (tb_paquete == null)
            {
                return HttpNotFound();
            }
            ViewBag.seccion = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 21), "idCategoria", "nombreCategoria", tb_paquete.seccion);
            ViewBag.destino1 = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_paquete.destino1);
            ViewBag.destino2 = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_paquete.destino2);
            ViewBag.moneda = new SelectList(db.tb_moneda, "idMoneda", "NombreMoneda", tb_paquete.moneda);
            ViewBag.pais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_paquete.pais);
            ViewBag.tarjetaasistencia = new SelectList(db.tb_tarjetaasistencia, "idTarjetaasistencia", "nombreTarjetaasistencia", tb_paquete.tarjetaasistencia);
            ViewBag.tematica = new SelectList(db.tb_tematica, "idTematica", "nombretematica", tb_paquete.tematica);
            ViewBag.zona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_paquete.zona);
            return View(tb_paquete);
        }

        // POST: Paquete/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPaquete,incentivo,factor,comision,fechacompra,seccion,tematica,moneda,tipocambio,nombrepaquete,tempviajeini,tempviajefin,zona,pais,destino1,destino2,flyer,word,tarjetaasistencia,incluye,notas,fechacreacion,usuariocreacion,fechamodificacion,usuariomodificacion")] tb_paquete tb_paquete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_paquete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.seccion = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_paquete.seccion);
            ViewBag.destino1 = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_paquete.destino1);
            ViewBag.destino2 = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_paquete.destino2);
            ViewBag.moneda = new SelectList(db.tb_moneda, "idMoneda", "NombreMoneda", tb_paquete.moneda);
            ViewBag.pais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_paquete.pais);
            ViewBag.tarjetaasistencia = new SelectList(db.tb_tarjetaasistencia, "idTarjetaasistencia", "nombreTarjetaasistencia", tb_paquete.tarjetaasistencia);
            ViewBag.tematica = new SelectList(db.tb_tematica, "idTematica", "nombretematica", tb_paquete.tematica);
            ViewBag.zona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_paquete.zona);
            return View(tb_paquete);
        }

        // GET: Paquete/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_paquete tb_paquete = db.tb_paquete.Find(id);
            if (tb_paquete == null)
            {
                return HttpNotFound();
            }
            return View(tb_paquete);
        }

        // POST: Paquete/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_paquete tb_paquete = db.tb_paquete.Find(id);
            db.tb_paquete.Remove(tb_paquete);
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
