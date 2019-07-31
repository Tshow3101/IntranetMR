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
    public class IngresosHotelController : Controller
    {
        private ModeloMR db = new ModeloMR();

        // GET: IngresosHotel
        public ActionResult Index()
        {
            var tb_ingresohotel = db.tb_ingresohotel.Include(t => t.tb_cadenahotelera).Include(t => t.tb_categoria).Include(t => t.tb_hotel);
            return View(tb_ingresohotel.ToList());
        }

        // GET: IngresosHotel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ingresohotel tb_ingresohotel = db.tb_ingresohotel.Find(id);
            if (tb_ingresohotel == null)
            {
                return HttpNotFound();
            }
            return View(tb_ingresohotel);
        }

        // GET: IngresosHotel/Create
        public ActionResult Create()
        {
            ViewBag.idCadena = new SelectList(db.tb_cadenahotelera, "idCadenaHotelera", "nombreCadenaHotelera");
            ViewBag.tarifa = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 17), "idCategoria", "nombreCategoria");
            ViewBag.idHotel = new SelectList(db.tb_hotel, "idHotel", "nombrehotel");
            ViewBag.idTipoHabitacion = new SelectList(db.tb_tipohabitacion, "idTipoHabitacion", "NombreTipoHabitacion");
            ViewBag.serviciohabitacion1 = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 29), "idCategoria", "NombreCategoria");
            ViewBag.serviciohabitacion2 = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 29), "idCategoria", "NombreCategoria");
            return View();
        }

        // POST: IngresosHotel/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idIngresoHotel,fecviajeini,fecviajefin,feccompraini,feccomprafin,tarifa,codprom,idCadena,idHotel,idTipoHabitacion,montoadulto,montoniño,porcentaje,doble,doblereal,triple,triplereal,cuadruple,cuadruplereal,simple,simplereal,quintuple,quituplereal,sextuple,sextuplereal,child1,child1real,edad1child1,edad2child1,child2,child2real,edad1child2,edad2child2,child3,child3real,edad1child3,edad2child3,infante,infantereal,edadinfante1,edadinfante2,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_ingresohotel tb_ingresohotel)
        {
            if (ModelState.IsValid)
            {
                db.tb_ingresohotel.Add(tb_ingresohotel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCadena = new SelectList(db.tb_cadenahotelera, "idCadenaHotelera", "nombreCadenaHotelera", tb_ingresohotel.idCadena);
            ViewBag.tarifa = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_ingresohotel.tarifa);
            ViewBag.idHotel = new SelectList(db.tb_hotel, "idHotel", "nombrehotel", tb_ingresohotel.idHotel);
            return View(tb_ingresohotel);
        }

        // GET: IngresosHotel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ingresohotel tb_ingresohotel = db.tb_ingresohotel.Find(id);
            if (tb_ingresohotel == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCadena = new SelectList(db.tb_cadenahotelera, "idCadenaHotelera", "nombreCadenaHotelera", tb_ingresohotel.idCadena);
            ViewBag.tarifa = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 17), "idCategoria", "nombreCategoria",tb_ingresohotel.tarifa);
            ViewBag.idHotel = new SelectList(db.tb_hotel, "idHotel", "nombrehotel", tb_ingresohotel.idHotel);

            ViewBag.idTipoHabitacion = new SelectList(db.tb_tipohabitacion, "idTipoHabitacion", "NombreTipoHabitacion");
            ViewBag.serviciohabitacion1 = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 29), "idCategoria", "NombreCategoria");
            ViewBag.serviciohabitacion2 = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 29), "idCategoria", "NombreCategoria");
            return View(tb_ingresohotel);
        }

        // POST: IngresosHotel/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idIngresoHotel,fecviajeini,fecviajefin,feccompraini,feccomprafin,tarifa,codprom,idCadena,idHotel,idTipoHabitacion,montoadulto,montoniño,porcentaje,doble,doblereal,triple,triplereal,cuadruple,cuadruplereal,simple,simplereal,quintuple,quituplereal,sextuple,sextuplereal,child1,child1real,edad1child1,edad2child1,child2,child2real,edad1child2,edad2child2,child3,child3real,edad1child3,edad2child3,infante,infantereal,edadinfante1,edadinfante2,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_ingresohotel tb_ingresohotel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_ingresohotel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCadena = new SelectList(db.tb_cadenahotelera, "idCadenaHotelera", "nombreCadenaHotelera", tb_ingresohotel.idCadena);
            ViewBag.tarifa = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_ingresohotel.tarifa);
            ViewBag.idHotel = new SelectList(db.tb_hotel, "idHotel", "nombrehotel", tb_ingresohotel.idHotel);
            return View(tb_ingresohotel);
        }

        // GET: IngresosHotel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ingresohotel tb_ingresohotel = db.tb_ingresohotel.Find(id);
            if (tb_ingresohotel == null)
            {
                return HttpNotFound();
            }
            return View(tb_ingresohotel);
        }

        // POST: IngresosHotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_ingresohotel tb_ingresohotel = db.tb_ingresohotel.Find(id);
            db.tb_ingresohotel.Remove(tb_ingresohotel);
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

        /*New Create*/
        [HttpPost]
        public JsonResult SaveIngresoHotel(tb_ingresohotel ingresohotel)
        {
            bool status = false;

            var isValidModel = TryUpdateModel(ingresohotel);

            if (isValidModel)
            {
                using (db)
                {
                    ingresohotel.fecharegistro = DateTime.Today;
                    ingresohotel.usuarioregistro = 1;
                    db.tb_ingresohotel.Add(ingresohotel);
                    db.SaveChanges();
                    status = true;
                }
            }

            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public ActionResult eliminaDetalles(List<tb_detalleingresohotel> tb_detalleingresohotel, int id = 0)
        {
            bool status = false;
            db.Database.ExecuteSqlCommand("DELETE FROM tb_detalleingresohotel WHERE idIngresoHotel = @id", new
            object[] { new System.Data.SqlClient.SqlParameter("id", id) });
            db.Database.Connection.Close();

            if (tb_detalleingresohotel != null)
            {
                foreach (var det in tb_detalleingresohotel)
                {
                    db.tb_detalleingresohotel.Add(det);
                    db.SaveChanges();
                }
            }

            status = true;
            return new JsonResult { Data = new { status = status } };

        }

        public JsonResult EditarIngreso(tb_ingresohotel tb_ingresohotel)
        {
            bool status = false;
            var v = db.tb_ingresohotel.Find(tb_ingresohotel.idIngresoHotel);
            var isValidModel = TryUpdateModel(tb_ingresohotel);
            if (isValidModel)
            {
                using (db)
                {
                    db.Entry(v).CurrentValues.SetValues(tb_ingresohotel);
                    db.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}
