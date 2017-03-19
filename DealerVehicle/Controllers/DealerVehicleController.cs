using DealerVehicle.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DealerVehicle.Controllers
{
    public class DealerVehicleController : Controller
    {
        DealerVehicleContext DB = new DealerVehicleContext();
        // GET: DealerVehicle
        public ActionResult Index()
        {
            
            List<DealerVehicles> dealervehicles = DB.DealerVehicle.ToList();
            return View(dealervehicles);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DealerVehicles dealervehicle = DB.DealerVehicle.Find(id);

            if (dealervehicle == null)
            {
                return HttpNotFound();
            }
            return View(dealervehicle);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DealerVehicles dealervehicle)
        {
            if (ModelState.IsValid)
            {
                DB.DealerVehicle.Add(dealervehicle);
                DB.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(dealervehicle);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DealerVehicles dealervehicle = DB.DealerVehicle.Find(id);
            if (dealervehicle == null)
            {
                return HttpNotFound();
            }
            return View(dealervehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DealerVehicles dealervehicle)
        {
            if (ModelState.IsValid)
            {

                DB.DealerVehicle.Add(dealervehicle);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dealervehicle);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DealerVehicles dealervehicle = DB.DealerVehicle.Find(id);
            if (dealervehicle == null)
            {
                return HttpNotFound();
            }
            return View(dealervehicle);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DealerVehicles dealervehicle = DB.DealerVehicle.Find(id);
            DB.DealerVehicle.Remove(dealervehicle);
            DB.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}
