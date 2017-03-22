using DealerVehicle.Models;
using DealerVehicle.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DealerVehicle;

namespace DealerVehicle.Controllers
{
    public class DealerController : Controller
    {
        //private DealerRepo dealerRepo;
        //private VehicleRepo vehiclerepo;
        private Repo<Vehicle> Vehicle;
        private Repo<Dealer> Dealer;

        public DealerController()
        {
            Dealer = new Repo<Dealer>();
            //vehiclerepo = new VehicleRepo();
            Vehicle = new Repo<Vehicle>();
        }


        //DealerRepo dealerRepo = new DealerRepo();
        //VehicleRepo vehiclerepo = new VehicleRepo();
        

        // GET: Dealer
        public ActionResult Index()
        {


            List<Dealer> Dealers = Dealer.Read().ToList();
            return View(Dealers);
        }
        public ActionResult DealerInventory(int dealerid)
        {
            ViewBag.Dealer = Dealer.Read().Where(x=> x.Id== dealerid);
            Vehicle vehicleslist = Vehicle.Read().Where(x => x.DealerId == dealerid).FirstOrDefault();
            return View(vehicleslist);

        }

        public ActionResult Details(int ?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Dealer dealer = Dealer.Read().Where(x => x.Id == id).FirstOrDefault();
        
            
            if (dealer == null)
            {
                return HttpNotFound();
            }
            return View(dealer);
        }

        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dealer dealer)
        {
            if (ModelState.IsValid)
            {
                //DB.Dealer.Add(dealer);
                //DB.SaveChanges();

                Dealer.Create(dealer);
              
                return RedirectToAction("Index");
            }

            return View(dealer);
        }

        [Authorize(Roles ="Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dealer dealer = Dealer.Read().Where(a => a.Id == id).FirstOrDefault();
            if (dealer == null)
            {
                return HttpNotFound();
            }
            return View(dealer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Dealer dealer)
        {
            if (ModelState.IsValid)
            {

                //DB.Dealer.Add(dealer);
                //DB.SaveChanges();
                Dealer.Update(dealer);
                return RedirectToAction("Index");
            }
            return View(dealer);
        }

        [Authorize(Roles ="Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dealer dealer = Dealer.Read().Where(a => a.Id == id).FirstOrDefault();
            if (dealer == null)
            {
                return HttpNotFound();
            }
            return View(dealer);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dealer dealer = Dealer.Read().Where(a => a.Id == id).FirstOrDefault();

            Dealer.Delete(dealer);
            
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
     

  