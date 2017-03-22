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
        private Repo<Model> model;
        private Repo<Brand> brand;
        public ModelController()
        {
            brand = new Repo<Brand>();
            model = new Repo<Model>();
        }
       // ModelRepo modelrepo = new ModelRepo();
        //BrandRepo brandRepo = new BrandRepo();
        // GET: Model
        public ActionResult Index()
        {

            List<Model> Models = model.Read().ToList();
            return View(Models);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model models = model.Read().Where(x => x.ModelId == id).FirstOrDefault();

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(models);
        }


        public ActionResult Create()
        {
            ViewBag.Brands = brand.Read().Select(x => new SelectListItem { Text = x.BrandName, Value = x.BrandId.ToString() });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Model modeel)
        {
            if (ModelState.IsValid)
            {
                model.Create(modeel);


                return RedirectToAction("Index");
            }

            return View(modeel);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model models = model.Read().Where(x => x.ModelId == id).FirstOrDefault();
            ViewBag.Brands = brand.Read().Select(x => new SelectListItem { Text = x.BrandName, Value = x.BrandId.ToString() });
            if (models == null)
            {
                return HttpNotFound();
            }
            return View(models);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Model models)
        {
            if (ModelState.IsValid)
            {
                model.Update(models);


                return RedirectToAction("Index");
            }
            return View(models);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model models = model.Read().Where(x => x.ModelId == id).FirstOrDefault();
            if (models == null)
            {
                return HttpNotFound();
            }
            return View(models);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Model models = model.Read().Where(x => x.ModelId == id).FirstOrDefault();
            model.Delete(models);


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
