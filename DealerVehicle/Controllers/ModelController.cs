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
    public class ModelController : Controller
    {
        ModelRepo modelrepo = new ModelRepo();
        BrandRepo brandRepo = new BrandRepo();
        // GET: Model
        public ActionResult Index()
        {

            List<Model> Models = modelrepo.GetModelsAll();
            return View(Models);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = modelrepo.GetModelById(id.Value);

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }


        public ActionResult Create()
        {
            ViewBag.Brands = brandRepo.GetBrandAll().Select(x => new SelectListItem { Text = x.BrandName, Value = x.BrandId.ToString() });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Model model)
        {
            if (ModelState.IsValid)
            {
                modelrepo.InsertModel(model);


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
            Model model = modelrepo.GetModelById(id.Value);
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
                modelrepo.UpdateModel(model);


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
            Model model = modelrepo.GetModelById(id.Value);
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
            Model model = modelrepo.GetModelById(id);
            modelrepo.DeleteModel(model);


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
