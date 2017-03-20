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
    public class DealerController : Controller
    {
        DealerRepo dealerRepo = new DealerRepo();
        DealerVehicleRepo dealervehiclerepo = new DealerVehicleRepo();

        // GET: Dealer
        public ActionResult Index()
        {

            List<Dealer> Dealers = dealerRepo.GetDealerAll();
            return View(Dealers);
        }
        


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dealer dealer = dealerRepo.GetDealerById(id.Value);
            
            if (dealer == null)
            {
                return HttpNotFound();
            }
            return View(dealer);
        }


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

                dealerRepo.InsertDealer(dealer);
              
                return RedirectToAction("Index");
            }

            return View(dealer);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dealer dealer = dealerRepo.GetDealerById(id.Value);
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
                dealerRepo.UpdateDealer(dealer);
                return RedirectToAction("Index");
            }
            return View(dealer);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dealer dealer = dealerRepo.GetDealerById(id.Value);
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
            Dealer dealer = dealerRepo.GetDealerById(id);

            dealerRepo.DeleteDealer(dealer);
            
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
     

  