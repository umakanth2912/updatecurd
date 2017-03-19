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
        DealerVehicleContext DB = new DealerVehicleContext();
        // GET: Model
        public ActionResult Index()
        {
            
            List<Model> Models = DB.Model.ToList();
            return View(Models);
        }
        public ActionResult Details(int? id)
        {
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


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Model model)
        {
            if (ModelState.IsValid)
            {
                DB.Model.Add(model);
                DB.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }


        public ActionResult Edit(int? id)
        {
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
        public ActionResult Edit(Model model)
        {
            if (ModelState.IsValid)
            {

                DB.Model.Add(model);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public ActionResult Delete(int? id)
        {
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


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Model model = DB.Model.Find(id);
            DB.Model.Remove(model);
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
