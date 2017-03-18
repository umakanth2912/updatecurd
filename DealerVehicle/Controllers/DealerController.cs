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
    public class DealerController : Controller
    {
        // GET: Dealer
        public ActionResult Index()
        {
            DealerVehicleContext DB = new DealerVehicleContext();
            List<Dealer> Dealers = DB.Dealer.ToList();
            return View(Dealers);
        }
        public ActionResult Details(int? id)
        {
            DealerVehicleContext DB = new DealerVehicleContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dealer dealer = DB.Dealer.Find(id);
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
        public ActionResult Create(Dealer dealer)
        {
            DealerVehicleContext DB = new DealerVehicleContext();
            try
            {
                if (ModelState.IsValid)
                {
                    DB.Dealer.Add(dealer);
                    DB.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException )
            {
                
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(dealer);
        }
        [HttpPost]
        public ActionResult Edit(Dealer dealer)
        {
            DealerVehicleContext DB = new DealerVehicleContext();
            if(ModelState.IsValid)
            {
                DB.Dealer.Add(dealer);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("","Unable to save changes");
            }
            return View();
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
            Dealer dealer = DB.Dealer.Find(id);
            if (dealer == null)
            {
                return HttpNotFound();
            }
            return View(dealer);
        }

    }
}