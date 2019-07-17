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
    public class HotelController : Controller
    {
        private ModeloMR db = new ModeloMR();

        // GET: Hotel
        public ActionResult Index()
        {
            var tb_hotel = db.tb_hotel.Include(t => t.tb_cadenahotelera).Include(t => t.tb_categoria).Include(t => t.tb_ciudad).Include(t => t.tb_pais).Include(t => t.tb_vigencia).Include(t => t.tb_zona);
            return View(tb_hotel.ToList());
        }

        // GET: Hotel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_hotel tb_hotel = db.tb_hotel.Find(id);
            if (tb_hotel == null)
            {
                return HttpNotFound();
            }
            return View(tb_hotel);
        }

        // GET: Hotel/Create
        public ActionResult Create()
        {
            ViewBag.idCadenaHotelera = new SelectList(db.tb_cadenahotelera, "idCadenaHotelera", "nombreCadenaHotelera");
            ViewBag.idCategoria = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 1), "idCategoria", "nombreCategoria");
            ViewBag.idCiudad = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad");
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais");
            ViewBag.idVigencia = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia");
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona");
            ViewBag.idCategoria1 = new SelectList(db.tb_categoria.Where(x => x.idTipocategoria == 11), "idCategoria", "nombreCategoria");
            return View();
        }

        // POST: Hotel/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idHotel,nombrehotel,idCadenaHotelera,idZona,idPais,idCiudad,idCategoria,direccionhotel,correohotel,telefono1hotel,telefono2hotel,idVigencia,linkhotel,checkinhotel,checkouthotel,mapahotel,logohotel,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_hotel tb_hotel)
        {
            if (ModelState.IsValid)
            {
                tb_hotel.fecharegistro = DateTime.Today;
                tb_hotel.usuarioregistro = 1;
                db.tb_hotel.Add(tb_hotel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCadenaHotelera = new SelectList(db.tb_cadenahotelera, "idCadenaHotelera", "nombreCadenaHotelera", tb_hotel.idCadenaHotelera);
            ViewBag.idCategoria = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_hotel.idCategoria);
            ViewBag.idCiudad = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_hotel.idCiudad);
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_hotel.idPais);
            ViewBag.idVigencia = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_hotel.idVigencia);
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_hotel.idZona);
            return View(tb_hotel);
        }

        // GET: Hotel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_hotel tb_hotel = db.tb_hotel.Find(id);
            if (tb_hotel == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCadenaHotelera = new SelectList(db.tb_cadenahotelera, "idCadenaHotelera", "nombreCadenaHotelera", tb_hotel.idCadenaHotelera);
            ViewBag.idCategoria = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_hotel.idCategoria);
            ViewBag.idCiudad = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_hotel.idCiudad);
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_hotel.idPais);
            ViewBag.idVigencia = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_hotel.idVigencia);
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_hotel.idZona);
            return View(tb_hotel);
        }

        // POST: Hotel/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idHotel,nombrehotel,idCadenaHotelera,idZona,idPais,idCiudad,idCategoria,direccionhotel,correohotel,telefono1hotel,telefono2hotel,idVigencia,linkhotel,checkinhotel,checkouthotel,mapahotel,logohotel,fecharegistro,usuarioregistro,fechamodificacion,usuariomodificacion")] tb_hotel tb_hotel)
        {
            if (ModelState.IsValid)
            {
                tb_hotel.fechamodificacion = DateTime.Today;
                tb_hotel.usuariomodificacion = 1;
                db.Entry(tb_hotel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCadenaHotelera = new SelectList(db.tb_cadenahotelera, "idCadenaHotelera", "nombreCadenaHotelera", tb_hotel.idCadenaHotelera);
            ViewBag.idCategoria = new SelectList(db.tb_categoria, "idCategoria", "nombreCategoria", tb_hotel.idCategoria);
            ViewBag.idCiudad = new SelectList(db.tb_ciudad, "idCiudad", "nombreCiudad", tb_hotel.idCiudad);
            ViewBag.idPais = new SelectList(db.tb_pais, "idPais", "NombrePais", tb_hotel.idPais);
            ViewBag.idVigencia = new SelectList(db.tb_vigencia, "idVigencia", "nombreVigencia", tb_hotel.idVigencia);
            ViewBag.idZona = new SelectList(db.tb_zona, "idZona", "nombreZona", tb_hotel.idZona);
            return View(tb_hotel);
        }

        // GET: Hotel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_hotel tb_hotel = db.tb_hotel.Find(id);
            if (tb_hotel == null)
            {
                return HttpNotFound();
            }
            return View(tb_hotel);
        }

        // POST: Hotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_hotel tb_hotel = db.tb_hotel.Find(id);
            db.tb_hotel.Remove(tb_hotel);
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

        /*Save Hotel with Contacts*/
        [HttpPost]
        public JsonResult SaveHotel(tb_hotel hotel)
        {
            bool status = false;

            var isValidModel = TryUpdateModel(hotel);

            if (isValidModel)
            {
                using (db)
                {
                    hotel.fecharegistro = DateTime.Today;
                    hotel.usuarioregistro = 1;
                    hotel.idVigencia = 2;
                    db.tb_hotel.Add(hotel);
                    db.SaveChanges();
                    status = true;
                }
            }

            return new JsonResult { Data = new { status = status } };
        }        
    }
}
