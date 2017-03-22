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
        private Repo<Vehicle> vehiclerepo;
        private Repo<Model> modelrepo;
        private Repo<Dealer> dealerrepo;
        public VehicleController()
        {
            vehiclerepo = new Repo<Vehicle>();
            modelrepo = new Repo<Model>();
            dealerrepo = new Repo<Dealer>();

        }
        //VehicleRepo vehiclerepo = new VehicleRepo();
        //ModelRepo modelrepo = new ModelRepo();
        //DealerRepo dealerRepo = new DealerRepo();
        // GET: Vehicle
        public ActionResult Index()
        {

            List<Vehicle> Vehicles = vehiclerepo.Read().ToList();
            return View(Vehicles);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //List<Vehicle> vehicle = vehiclerepo.Read().Where(a => a.VehicleId == id).ToList();
            Vehicle vehicle = vehiclerepo.Read().Where(a => a.VehicleId == id).FirstOrDefault();

            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }


        public ActionResult Create()
        {
            ViewBag.Models = modelrepo.Read().Select(x => new SelectListItem { Text = x.ModelName, Value = x.ModelId.ToString() });
            ViewBag.Dealers = dealerrepo.Read().Select(x => new SelectListItem { Text = x.DealerName, Value = x.Id.ToString() });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehiclerepo.Create(vehicle);


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
            Vehicle vehicle = vehiclerepo.Read().Where(a => a.VehicleId == id).FirstOrDefault();
            ViewBag.Models = modelrepo.Read().Select(x => new SelectListItem { Text = x.ModelName, Value = x.ModelId.ToString() });
            ViewBag.Dealers = dealerrepo.Read().Select(x => new SelectListItem { Text = x.DealerName, Value = x.Id.ToString() });
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

                vehiclerepo.Update(vehicle);

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
            Vehicle vehicle = vehiclerepo.Read().Where(a => a.VehicleId == id).FirstOrDefault();
            ViewBag.Vehicles = modelrepo.Read().Select(x => new SelectListItem { Text = x.ModelName, Value = x.ModelId.ToString() });

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
            Vehicle vehicle = vehiclerepo.Read().Where(a => a.VehicleId == id).FirstOrDefault();
            vehiclerepo.Delete(vehicle);


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
