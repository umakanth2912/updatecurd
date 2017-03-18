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
    public class ModelController : Controller
    {
        // GET: Model
        public ActionResult Index()
        {
            DealerVehicleContext DB = new DealerVehicleContext();
            List<Model> Models = DB.Model.ToList();
            return View(Models);
        }
        public ActionResult Details(int? id)
        {
            DealerVehicleContext DB = new DealerVehicleContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = DB.Model.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModelName,ModelColor,ModelYear")]Model model)
        {
            DealerVehicleContext DB = new DealerVehicleContext();
            try
            {
                if (ModelState.IsValid)
                {
                    DB.Model.Add(model);
                    DB.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(model);
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
            var modelToUpdate = DB.Model.Find(id);
            if (TryUpdateModel(modelToUpdate, "",
               new string[] { "ModelName","ModelColor","ModelYear" }))
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
            return View(modelToUpdate);
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
            Model model = DB.Model.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
    }
}