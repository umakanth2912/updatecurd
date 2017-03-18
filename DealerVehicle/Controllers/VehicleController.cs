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
    public class VehicleController : Controller
    {
        // GET: Vehicle
        public ActionResult Index()
        {
            DealerVehicleContext DB = new DealerVehicleContext();
            List<Vehicle> Vehicles = DB.Vehicle.ToList();
            return View(Vehicles);
        }
        public ActionResult Details(int? id)
        {
            DealerVehicleContext DB = new DealerVehicleContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = DB.Vehicle.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehicle vehicle)
        {
            DealerVehicleContext DB = new DealerVehicleContext();
            try
            {
                if (ModelState.IsValid)
                {
                    DB.Vehicle.Add(vehicle);
                    DB.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(vehicle);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            DealerVehicleContext DB = new DealerVehicleContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicleToUpdate = DB.Vehicle.Find(id);
            if (TryUpdateModel(vehicleToUpdate, ""))
            {
                try
                {
                    DB.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException)
                {

                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(vehicleToUpdate);
        }
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            DealerVehicleContext DB = new DealerVehicleContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Vehicle vehicle = DB.Vehicle.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }
    }
}