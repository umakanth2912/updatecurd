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
        // GET: DealerVehicle
        public ActionResult Index()
        {
            DealerVehicleContext DB = new DealerVehicleContext();
            List<DealerVehicles> dealervehicles = DB.DealerVehicle.ToList();
            return View(dealervehicles);
        }
        public ActionResult Details(int? id)
        {
            DealerVehicleContext DB = new DealerVehicleContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DealerVehicles dealervehicles = DB.DealerVehicle.Find(id);
            if (dealervehicles == null)
            {
                return HttpNotFound();
            }
            return View(dealervehicles);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DealerVehicles dealervehicles)
        {
            DealerVehicleContext DB = new DealerVehicleContext();
            try
            {
                if (ModelState.IsValid)
                {
                    DB.DealerVehicle.Add(dealervehicles);
                    DB.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(dealervehicles);
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
            var dealervehicleToUpdate = DB.DealerVehicle.Find(id);
            if (TryUpdateModel(dealervehicleToUpdate, ""))
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
            return View(dealervehicleToUpdate);
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
            DealerVehicles dealervehicle = DB.DealerVehicle.Find(id);
            if (dealervehicle == null)
            {
                return HttpNotFound();
            }
            return View(dealervehicle);
        }
    }
}