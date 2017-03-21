using DealerVehicle.Models;
using DealerVehicle.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DealerVehicle.Controllers
{
    public class VehicleController : Controller
    {
        VehicleRepo vehiclerepo = new VehicleRepo();
        ModelRepo modelrepo = new ModelRepo();
        DealerRepo dealerRepo = new DealerRepo();
        // GET: Vehicle
        public ActionResult Index()
        {

            List<Vehicle> Vehicles = vehiclerepo.GetVehicleAll();
            return View(Vehicles);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = vehiclerepo.GetVehicleById(id.Value);

            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }


        public ActionResult Create()
        {
            ViewBag.Models = modelrepo.GetModelsAll().Select(x => new SelectListItem { Text = x.ModelName, Value = x.ModelId.ToString() });
            ViewBag.Dealers = dealerRepo.GetDealerAll().Select(x => new SelectListItem { Text = x.DealerName, Value = x.Id.ToString() });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehiclerepo.InsertVehicle(vehicle);


                return RedirectToAction("Index");
            }

            return View(vehicle);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = vehiclerepo.GetVehicleById(id.Value);
            ViewBag.Models = modelrepo.GetModelsAll().Select(x => new SelectListItem { Text = x.ModelName, Value = x.ModelId.ToString() });
            ViewBag.Dealers = dealerRepo.GetDealerAll().Select(x => new SelectListItem { Text = x.DealerName, Value = x.Id.ToString() });
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {

                vehiclerepo.UpdateVehicle(vehicle);

                return RedirectToAction("Index");
            }
            return View(vehicle);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = vehiclerepo.GetVehicleById(id.Value);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = vehiclerepo.GetVehicleById(id);
            vehiclerepo.DeleteVehicle(vehicle);


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
