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
    public class AgenciaController : Controller
    {
        private ModeloMR db = new ModeloMR();

        // GET: Agencia
        public ActionResult Index()
        {
            var tb_agencia = db.tb_agencia.Include(t => t.tb_categoria).Include(t => t.tb_categoria1).Include(t => t.tb_ciudad).Include(t => t.tb_pais).Include(t => t.tb_zona).Include(t => t.tb_usuario).Include(t => t.tb_vigencia).Include(t => t.tb_categoria2).Include(t => t.tb_vigencia1);
            return View(tb_agencia.ToList());
        }

        // GET: Agencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_agencia tb_agencia = db.tb_agencia.Find(id);
            if (tb_agencia == null)
            {
                return HttpNotFound();
            }
            return View(tb_agencia);
        }

        // GET: Agencia/Create
        public ActionResult Create()
        {
            ViewBag.documentousuario = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 26), "idCategoria", "nombreCategoria");
            ViewBag.Formapago = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 27), "idCategoria", "nombreCategoria");
            ViewBag.idCiudad = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad");
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais");
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona");
            ViewBag.Promotor = new SelectList(db.tb_usuario.Where(x => x.TIPOUSUARIO == 44), "idUsuario", "nombreusuario");
            ViewBag.retenedor = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia");
            ViewBag.tipodocumento = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 15), "idCategoria", "nombreCategoria");
            ViewBag.Vigente = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia");
            return View();
        }

        // POST: Agencia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAgencia,tipodocumento,Direccion,Promotor,retenedor,idZona,Png_En_alta_vertical,documentousuario,Telefono1,Linea_Credito,Retencion,idPais,png_en_alta_horizontal,Numero_de_Ruc,Telefono2,Formapago,Cta_Detraccion,idCiudad,Pie_de_Pagina_Flyers,RazonSocial,correo,Vigente,Logo,Color,Encabezado_landing_reps,Landing_MR,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_agencia tb_agencia)
        {
            if (ModelState.IsValid)
            {
                tb_agencia.fecharegistro = DateTime.Today;
                tb_agencia.usuarioregistro = 1;
                tb_agencia.Vigente = 1;
                db.tb_agencia.Add(tb_agencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.documentousuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_agencia.documentousuario);
            ViewBag.Formapago = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_agencia.Formapago);
            ViewBag.idCiudad = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_agencia.idCiudad);
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_agencia.idPais);
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_agencia.idZona);
            ViewBag.Promotor = new SelectList(db.tb_usuario, "idUsuario", "apellidopaternousuario", tb_agencia.Promotor);
            ViewBag.retenedor = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_agencia.retenedor);
            ViewBag.tipodocumento = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_agencia.tipodocumento);
            ViewBag.Vigente = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_agencia.Vigente);
            return View(tb_agencia);
        }

        // GET: Agencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_agencia tb_agencia = db.tb_agencia.Find(id);
            if (tb_agencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.documentousuario = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 26), "idCategoria", "nombreCategoria", tb_agencia.documentousuario);
            ViewBag.Formapago = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 27), "idCategoria", "nombreCategoria", tb_agencia.Formapago);
            ViewBag.idCiudad = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_agencia.idCiudad);
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_agencia.idPais);
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_agencia.idZona);
            ViewBag.Promotor = new SelectList(db.tb_usuario, "idUsuario", "apellidopaternousuario", tb_agencia.Promotor);
            ViewBag.retenedor = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_agencia.retenedor);
            ViewBag.tipodocumento = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 15), "idCategoria", "nombreCategoria", tb_agencia.tipodocumento);
            ViewBag.Vigente = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_agencia.Vigente);
            return View(tb_agencia);
        }

        // POST: Agencia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAgencia,tipodocumento,Direccion,Promotor,retenedor,idZona,Png_En_alta_vertical,documentousuario,Telefono1,Linea_Credito,Retencion,idPais,png_en_alta_horizontal,Numero_de_Ruc,Telefono2,Formapago,Cta_Detraccion,idCiudad,Pie_de_Pagina_Flyers,RazonSocial,correo,Vigente,Logo,Color,Encabezado_landing_reps,Landing_MR,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_agencia tb_agencia)
        {
            if (ModelState.IsValid)
            {
                tb_agencia.fechamodificacion = DateTime.Today;
                tb_agencia.usuariomodificacion = 1;
                db.Entry(tb_agencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.documentousuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_agencia.documentousuario);
            ViewBag.Formapago = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_agencia.Formapago);
            ViewBag.idCiudad = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_agencia.idCiudad);
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_agencia.idPais);
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_agencia.idZona);
            ViewBag.Promotor = new SelectList(db.tb_usuario, "idUsuario", "apellidopaternousuario", tb_agencia.Promotor);
            ViewBag.retenedor = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_agencia.retenedor);
            ViewBag.tipodocumento = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_agencia.tipodocumento);
            ViewBag.Vigente = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_agencia.Vigente);
            return View(tb_agencia);
        }

        // GET: Agencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_agencia tb_agencia = db.tb_agencia.Find(id);
            if (tb_agencia == null)
            {
                return HttpNotFound();
            }
            return View(tb_agencia);
        }

        // POST: Agencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_agencia tb_agencia = db.tb_agencia.Find(id);
            tb_agencia.Vigente = 2;
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
