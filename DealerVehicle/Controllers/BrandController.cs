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
    public class BrandController : Controller
    {
        // GET: Brand
        public ActionResult Index()
        {
            DealerVehicleContext Db = new DealerVehicleContext();
            List<Brand> Brands = Db.Brand.ToList();
            return View(Brands);
        }
        public ActionResult Details(int? id)
        {
            DealerVehicleContext DB = new DealerVehicleContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = DB.Brand.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BrandName")]Brand brand)
        {
            DealerVehicleContext DB = new DealerVehicleContext();
            try
            {
                if (ModelState.IsValid)
                {
                    DB.Brand.Add(brand);
                    DB.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(brand);
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
            var brandToUpdate = DB.Dealer.Find(id);
            if (TryUpdateModel(brandToUpdate, "",
               new string[] { "BrandName"}))
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
            return View(brandToUpdate);
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
            Brand brand = DB.Brand.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }
    }
}