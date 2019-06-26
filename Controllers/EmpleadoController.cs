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
    public class EmpleadoController : Controller
    {
        private ModeloMR db = new ModeloMR();

        // GET: Empleado
        public ActionResult Index()
        {
            var tb_usuario = db.tb_usuario.Where(x => x.vigenteusuario == 1).Include(t => t.tb_categoria).Include(t => t.tb_categoria1).Include(t => t.tb_categoria2).Include(t => t.tb_categoria3).Include(t => t.tb_categoria4).Include(t => t.tb_categoria5).Include(t => t.tb_categoria6).Include(t => t.tb_pais).Include(t => t.tb_vigencia).Include(t => t.tb_zona).Include(t => t.tb_vigencia1).Include(t => t.tb_vigencia2).Include(t => t.tb_agencia1).Include(t => t.tb_categoria7);
            return View(tb_usuario.ToList());
        }

        // GET: Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_usuario tb_usuario = db.tb_usuario.Find(id);
            if (tb_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tb_usuario);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            ViewBag.areausuario = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 13), "idCategoria", "nombreCategoria");
            ViewBag.documentousuario = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 26), "idCategoria", "nombreCategoria");
            ViewBag.empresesa_usuario = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 12), "idCategoria", "nombreCategoria");
            ViewBag.formapagousuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria");
            ViewBag.Puesto_Empresa = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 11), "idCategoria", "nombreCategoria");
            ViewBag.sexousuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria");
            ViewBag.tipodocumento = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 15), "idCategoria", "nombreCategoria");
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais");
            ViewBag.facturaelectronicausuario = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia");
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona");
            ViewBag.retenedorusuario = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia");
            ViewBag.vigenteusuario = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia");
            ViewBag.idAgencia = new SelectList(db.tb_agencia, "idAgencia", "Direccion");
            ViewBag.TIPOUSUARIO = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 25), "idCategoria", "nombreCategoria");
            return View();
        }

        // POST: Empleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUsuario,anexo_usuario,apellidopaternousuario,apellidomaternousuario,areausuario,Puesto_Empresa,comisionusuario,contactousuario,contrasenausuario,correousuario,correosunatusuario,ctadetraccionusuario,cumpleanosusuario,direccionusuario,documentousuario,empresesa_usuario,facturaelectronicausuario,formapagousuario,lineacreditousuario,metausuario,nombreusuario,numerocontactousuario,numerodocumentousuario,idPais,razonsocialusuario,retenedorusuario,sexousuario,skypeusuario,telefonousuario,tipodocumento,usuario,vigenteusuario,idZona,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion,idAgencia,TIPOUSUARIO")] tb_usuario tb_usuario)
        {
            if (ModelState.IsValid)
            {
                tb_usuario.vigenteusuario =1;
                tb_usuario.fecharegistro = DateTime.Today;
                tb_usuario.usuarioregistro = 1;
                db.tb_usuario.Add(tb_usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.areausuario = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 13), "idCategoria", "nombreCategoria", tb_usuario.areausuario, db.tb_categoria.Where(x => x.idTipocategoria == 13));
            ViewBag.documentousuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.documentousuario);
            ViewBag.empresesa_usuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.empresesa_usuario);
            ViewBag.formapagousuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.formapagousuario);
            ViewBag.Puesto_Empresa = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.Puesto_Empresa);
            ViewBag.sexousuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.sexousuario);
            ViewBag.tipodocumento = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.tipodocumento);
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_usuario.idPais);
            ViewBag.facturaelectronicausuario = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_usuario.facturaelectronicausuario);
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_usuario.idZona);
            ViewBag.retenedorusuario = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_usuario.retenedorusuario);
            ViewBag.vigenteusuario = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_usuario.vigenteusuario);
            ViewBag.idAgencia = new SelectList(db.tb_agencia, "idAgencia", "Direccion", tb_usuario.idAgencia);
            ViewBag.TIPOUSUARIO = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.TIPOUSUARIO);
            return View(tb_usuario);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_usuario tb_usuario = db.tb_usuario.Find(id);
            if (tb_usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.areausuario = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 13), "idCategoria", "nombreCategoria", tb_usuario.areausuario);
            ViewBag.documentousuario = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 26), "idCategoria", "nombreCategoria", tb_usuario.documentousuario);
            ViewBag.empresesa_usuario = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 12), "idCategoria", "nombreCategoria", tb_usuario.empresesa_usuario);
            ViewBag.formapagousuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.formapagousuario);
            ViewBag.Puesto_Empresa = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 11), "idCategoria", "nombreCategoria", tb_usuario.Puesto_Empresa);
            ViewBag.sexousuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.sexousuario);
            ViewBag.tipodocumento = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 15), "idCategoria", "nombreCategoria", tb_usuario.tipodocumento);
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_usuario.idPais);
            ViewBag.facturaelectronicausuario = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_usuario.facturaelectronicausuario);
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_usuario.idZona);
            ViewBag.retenedorusuario = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_usuario.retenedorusuario);
            ViewBag.vigenteusuario = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_usuario.vigenteusuario);
            ViewBag.idAgencia = new SelectList(db.tb_agencia, "idAgencia", "Direccion", tb_usuario.idAgencia);
            ViewBag.TIPOUSUARIO = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 25), "idCategoria", "nombreCategoria", tb_usuario.TIPOUSUARIO);
            return View(tb_usuario);
        }

        // POST: Empleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUsuario,anexo_usuario,apellidopaternousuario,apellidomaternousuario,areausuario,Puesto_Empresa,comisionusuario,contactousuario,contrasenausuario,correousuario,correosunatusuario,ctadetraccionusuario,cumpleanosusuario,direccionusuario,documentousuario,empresesa_usuario,facturaelectronicausuario,formapagousuario,lineacreditousuario,metausuario,nombreusuario,numerocontactousuario,numerodocumentousuario,idPais,razonsocialusuario,retenedorusuario,sexousuario,skypeusuario,telefonousuario,tipodocumento,usuario,vigenteusuario,idZona,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion,idAgencia,TIPOUSUARIO")] tb_usuario tb_usuario)
        {
            if (ModelState.IsValid)
            {
                tb_usuario.fechamodificacion = DateTime.Today;
                tb_usuario.usuariomodificacion = 1;
                db.Entry(tb_usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.areausuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.areausuario);
            ViewBag.documentousuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.documentousuario);
            ViewBag.empresesa_usuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.empresesa_usuario);
            ViewBag.formapagousuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.formapagousuario);
            ViewBag.Puesto_Empresa = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.Puesto_Empresa);
            ViewBag.sexousuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.sexousuario);
            ViewBag.tipodocumento = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.tipodocumento);
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_usuario.idPais);
            ViewBag.facturaelectronicausuario = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_usuario.facturaelectronicausuario);
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_usuario.idZona);
            ViewBag.retenedorusuario = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_usuario.retenedorusuario);
            ViewBag.vigenteusuario = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_usuario.vigenteusuario);
            ViewBag.idAgencia = new SelectList(db.tb_agencia, "idAgencia", "Direccion", tb_usuario.idAgencia);
            ViewBag.TIPOUSUARIO = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.TIPOUSUARIO);
            return View(tb_usuario);
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_usuario tb_usuario = db.tb_usuario.Find(id);
            if (tb_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tb_usuario);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_usuario tb_usuario = db.tb_usuario.Find(id);
            tb_usuario.vigenteusuario = 2;
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
