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
        public Repo<Brand> Brand;
        public BrandController()
        {
            Brand = new Repo<Brand>();
        }
       
        
        // GET: Brand
        public ActionResult Index()
        {

            List<Brand> Brands = Brand.Read().ToList();
            return View(Brands);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = Brand.Read().Where(a => a.BrandId == id).FirstOrDefault();

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
                Brand.Create(brand);
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
            Brand brand = Brand.Read().Where(x => x.BrandId == id).FirstOrDefault();
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
                Brand.Update(brand);
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
            Brand brand = Brand.Read().Where(x => x.BrandId == id).FirstOrDefault();
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
            Brand brand = Brand.Read().Where(x => x.BrandId == id).FirstOrDefault();
            Brand.Delete(brand);
            

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
