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
    public class OperadorController : Controller
    {
        private ModeloMR db = new ModeloMR();

        // GET: Operador
        public ActionResult Index()
        {
            var tb_usuario = db.tb_usuario.Where(t => t.TIPOUSUARIO == 56 && t.vigenteusuario == 1).Include(t => t.tb_agencia1).Include(t => t.tb_categoria).Include(t => t.tb_categoria1).Include(t => t.tb_categoria2).Include(t => t.tb_categoria3).Include(t => t.tb_categoria4).Include(t => t.tb_categoria5).Include(t => t.tb_categoria6).Include(t => t.tb_categoria7).Include(t => t.tb_pais).Include(t => t.tb_vigencia).Include(t => t.tb_zona).Include(t => t.tb_vigencia1).Include(t => t.tb_vigencia2);
            return View(tb_usuario.ToList());
        }

        // GET: Operador/Details/5
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

        public ActionResult DetailsR(int? id)
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

        // GET: Operador/Create
        public ActionResult Create()
        {
            ViewBag.idAgencia = new SelectList(db.tb_agencia, "idAgencia", "Direccion");
            ViewBag.areausuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria");
            ViewBag.documentousuario = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 26), "idCategoria", "nombreCategoria");
            ViewBag.empresesa_usuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria");
            ViewBag.formapagousuario = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 27), "idCategoria", "nombreCategoria");
            ViewBag.Puesto_Empresa = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria");
            ViewBag.sexousuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria");
            ViewBag.tipodocumento = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 15), "idCategoria", "nombreCategoria");
            ViewBag.TIPOUSUARIO = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria");
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais");
            ViewBag.facturaelectronicausuario = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia");
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona");
            ViewBag.retenedorusuario = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia");
            ViewBag.vigenteusuario = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia");
            return View();
        }

        // POST: Operador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUsuario,anexo_usuario,apellidopaternousuario,apellidomaternousuario,areausuario,Puesto_Empresa,comisionusuario,contactousuario,contrasenausuario,correousuario,correosunatusuario,ctadetraccionusuario,cumpleanosusuario,direccionusuario,documentousuario,empresesa_usuario,facturaelectronicausuario,formapagousuario,lineacreditousuario,metausuario,nombreusuario,numerocontactousuario,numerodocumentousuario,idPais,razonsocialusuario,retenedorusuario,sexousuario,skypeusuario,telefonousuario,tipodocumento,usuario,vigenteusuario,idZona,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion,idAgencia,TIPOUSUARIO")] tb_usuario tb_usuario)
        {
            if (ModelState.IsValid)
            {

                db.tb_usuario.Add(tb_usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAgencia = new SelectList(db.tb_agencia, "idAgencia", "Direccion", tb_usuario.idAgencia);
            ViewBag.areausuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.areausuario);
            ViewBag.documentousuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.documentousuario);
            ViewBag.empresesa_usuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.empresesa_usuario);
            ViewBag.formapagousuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.formapagousuario);
            ViewBag.Puesto_Empresa = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.Puesto_Empresa);
            ViewBag.sexousuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.sexousuario);
            ViewBag.tipodocumento = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.tipodocumento);
            ViewBag.TIPOUSUARIO = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.TIPOUSUARIO);
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_usuario.idPais);
            ViewBag.facturaelectronicausuario = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_usuario.facturaelectronicausuario);
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_usuario.idZona);
            ViewBag.retenedorusuario = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_usuario.retenedorusuario);
            ViewBag.vigenteusuario = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_usuario.vigenteusuario);
            return View(tb_usuario);
        }

        // GET: Operador/Edit/5
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
            ViewBag.idAgencia = new SelectList(db.tb_agencia, "idAgencia", "Direccion", tb_usuario.idAgencia);
            ViewBag.areausuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.areausuario);
            ViewBag.documentousuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.documentousuario);
            ViewBag.empresesa_usuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.empresesa_usuario);
            ViewBag.formapagousuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.formapagousuario);
            ViewBag.Puesto_Empresa = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.Puesto_Empresa);
            ViewBag.sexousuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.sexousuario);
            ViewBag.tipodocumento = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.tipodocumento);
            ViewBag.TIPOUSUARIO = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.TIPOUSUARIO);
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_usuario.idPais);
            ViewBag.facturaelectronicausuario = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_usuario.facturaelectronicausuario);
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_usuario.idZona);
            ViewBag.retenedorusuario = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_usuario.retenedorusuario);
            ViewBag.vigenteusuario = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_usuario.vigenteusuario);
            return View(tb_usuario);
        }

        // POST: Operador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
            ViewBag.idAgencia = new SelectList(db.tb_agencia, "idAgencia", "Direccion", tb_usuario.idAgencia);
            ViewBag.areausuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.areausuario);
            ViewBag.documentousuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.documentousuario);
            ViewBag.empresesa_usuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.empresesa_usuario);
            ViewBag.formapagousuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.formapagousuario);
            ViewBag.Puesto_Empresa = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.Puesto_Empresa);
            ViewBag.sexousuario = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.sexousuario);
            ViewBag.tipodocumento = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.tipodocumento);
            ViewBag.TIPOUSUARIO = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_usuario.TIPOUSUARIO);
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_usuario.idPais);
            ViewBag.facturaelectronicausuario = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_usuario.facturaelectronicausuario);
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_usuario.idZona);
            ViewBag.retenedorusuario = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_usuario.retenedorusuario);
            ViewBag.vigenteusuario = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_usuario.vigenteusuario);
            return View(tb_usuario);
        }

        public JsonResult GuardarOperador(tb_usuario tb_usuario)
        {
            bool status = false;
                using (db)
                {
                tb_usuario.fecharegistro = DateTime.Today;
                tb_usuario.usuarioregistro = 1;
                db.tb_usuario.Add(tb_usuario);
                db.SaveChanges();
                status = true;
                }
            return new JsonResult { Data = new { status = status } };
        }

        public ActionResult GeneratePDF(int? id)
        {
            tb_usuario tb_usuario = db.tb_usuario.Find(id);
            return new ActionAsPdf("DetailsR/" + id)
            {
                FileName = (tb_usuario.nombreusuario + "_" + tb_usuario.numerodocumentousuario +".pdf").ToUpper(),
                PageSize = Rotativa.Options.Size.A4,
                PageOrientation = Rotativa.Options.Orientation.Portrait,
                PageMargins = new Rotativa.Options.Margins(4, 2, 4, 2)
            };
        }


        public JsonResult EditarOperador(tb_usuario tb_usuario)
        {
            bool status = false;
            var v = db.tb_usuario.Find(tb_usuario.idUsuario);
            var isValidModel = TryUpdateModel(tb_usuario);
            if (isValidModel)
            {
                using (db)
                {
                    tb_usuario.fechamodificacion = DateTime.Today;
                    tb_usuario.usuariomodificacion = 1;
                    db.Entry(v).CurrentValues.SetValues(tb_usuario);
                    db.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

        public JsonResult DarDeBaja(tb_usuario tb_usuario, int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            bool status = false;
            var t = db.tb_usuario.Find(id);

            using (db)
            {

                t.vigenteusuario = 2;
                db.Entry(t).State = EntityState.Modified;
                db.SaveChanges();

                status = true;
            }

            return new JsonResult { Data = new { status = status } };
        }

        // GET: Operador/Delete/5
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

        // POST: Operador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_usuario tb_usuario = db.tb_usuario.Find(id);
            db.tb_usuario.Remove(tb_usuario);
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
