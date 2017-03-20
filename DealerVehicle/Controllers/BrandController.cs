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
    public class BrandController : Controller
    {
        BrandRepo brandrepo = new BrandRepo();
        
        // GET: Brand
        public ActionResult Index()
        {

            List<Brand> Brands = brandrepo.GetBrandAll();
            return View(Brands);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = brandrepo.GetBrandById(id.Value);

            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                brandrepo.InsertBrand(brand);
                //DB.Brand.Add(brand);
                //DB.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(brand);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = brandrepo.GetBrandById(id.Value);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {
                brandrepo.UpdateBrand(brand);
               // DB.Brand.Add(brand);
                //DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brand);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = brandrepo.GetBrandById(id.Value);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brand brand = brandrepo.GetBrandById(id);
            brandrepo.DeleteBrand(brand);
            

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
