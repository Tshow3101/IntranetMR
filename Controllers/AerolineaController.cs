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
    public class AerolineaController : Controller
    {
        private ModeloMR db = new ModeloMR();

        // GET: Aerolinea
        public ActionResult Index()
        {
            var tb_aerolinea = db.tb_aerolinea.Include(t => t.tb_categoria).Include(t => t.tb_ciudad).Include(t => t.tb_pais).Include(t => t.tb_zona);
            return View(tb_aerolinea.ToList());
        }

        // GET: Aerolinea/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_aerolinea tb_aerolinea = db.tb_aerolinea.Find(id);
            if (tb_aerolinea == null)
            {
                return HttpNotFound();
            }
            return View(tb_aerolinea);
        }

        // GET: Aerolinea/Create
        public ActionResult Create()
        {
            ViewBag.BancoAfiliado = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 23), "idCategoria", "nombreCategoria");
            ViewBag.Destino = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad");
            ViewBag.Pais = new SelectList(db.tb_pais, "idPais", "NombrePais");
            ViewBag.Zona = new SelectList(db.tb_zona, "idZona", "nombreZona");
            return View();
        }

        // POST: Aerolinea/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idaerolinea,NombreComercial,Zona,telefono1,RazonSocial,Pais,telefono2,Ruc,Destino,Paginaweb,correofacturacion,Direccion,BancoAfiliado,logo,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_aerolinea tb_aerolinea)
        {
            if (ModelState.IsValid)
            {
                tb_aerolinea.usuarioregistro = 1;
                tb_aerolinea.fecharegistro = DateTime.Today;
                db.tb_aerolinea.Add(tb_aerolinea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BancoAfiliado = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_aerolinea.BancoAfiliado);
            ViewBag.Destino = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_aerolinea.Destino);
            ViewBag.Pais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_aerolinea.Pais);
            ViewBag.Zona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_aerolinea.Zona);
            return View(tb_aerolinea);
        }

        // GET: Aerolinea/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_aerolinea tb_aerolinea = db.tb_aerolinea.Find(id);
            if (tb_aerolinea == null)
            {
                return HttpNotFound();
            }
            ViewBag.BancoAfiliado = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 23), "idCategoria", "nombreCategoria", tb_aerolinea.BancoAfiliado);
            ViewBag.Destino = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_aerolinea.Destino);
            ViewBag.Pais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_aerolinea.Pais);
            ViewBag.Zona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_aerolinea.Zona);
            return View(tb_aerolinea);
        }

        // POST: Aerolinea/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idaerolinea,NombreComercial,Zona,telefono1,RazonSocial,Pais,telefono2,Ruc,Destino,Paginaweb,correofacturacion,Direccion,BancoAfiliado,logo,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_aerolinea tb_aerolinea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_aerolinea).State = EntityState.Modified;
                tb_aerolinea.usuariomodificacion = 1;
                tb_aerolinea.fechamodificacion = DateTime.Today;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BancoAfiliado = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 23), "idCategoria", "nombreCategoria", tb_aerolinea.BancoAfiliado);
            ViewBag.Destino = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_aerolinea.Destino);
            ViewBag.Pais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_aerolinea.Pais);
            ViewBag.Zona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_aerolinea.Zona);
            return View(tb_aerolinea);
        }

        // GET: Aerolinea/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_aerolinea tb_aerolinea = db.tb_aerolinea.Find(id);
            if (tb_aerolinea == null)
            {
                return HttpNotFound();
            }
            return View(tb_aerolinea);
        }

        // POST: Aerolinea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_aerolinea tb_aerolinea = db.tb_aerolinea.Find(id);
            db.tb_aerolinea.Remove(tb_aerolinea);
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
