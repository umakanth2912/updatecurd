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
    public class DealerVehicleController : Controller
    {
        DealerVehicleRepo dealervehiclerepo = new DealerVehicleRepo();
        DealerRepo dealerRepo = new DealerRepo();

        VehicleRepo vehiclerepo = new VehicleRepo();

        // GET: DealerVehicle
        public ActionResult Index()
        {

            List<DealerVehicles> dealervehicles = dealervehiclerepo.GetDealerVehicleAll();
            return View(dealervehicles);
        }
        public ActionResult DealerInventory(int dealerid)
        {
            ViewBag.Dealer = dealerRepo.GetDealerById(dealerid);
            List<DealerVehicles> dealervehicleslist = dealervehiclerepo.GetDealerVehicleAll().Where(x => x.DealerId == dealerid).ToList();
            return View(dealervehicleslist);

        }

        [HttpPost]
        public ActionResult AssignVehicle(DealerVehicles dealervehicle)
        {
            if(ModelState.IsValid)
            {
                dealervehiclerepo.InsertDealerVehicle(dealervehicle);
            }
            return RedirectToAction("Details","Dealer", new { id = dealervehicle.DealerId });
        }

        public ActionResult AssignVehicle(int dealerid)
        {
            ViewBag.Vehicles = vehiclerepo.GetVehicleAll().Select(x => new SelectListItem { Text = x.Model.ModelName, Value = x.VehicleId.ToString() });
            ViewBag.DealerId = dealerid;
            return View();
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DealerVehicles dealervehicle = dealervehiclerepo.GetDealerVehicleById(id.Value);

            if (dealervehicle == null)
            {
                return HttpNotFound();
            }
            return View(dealervehicle);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DealerVehicles dealervehicle = dealervehiclerepo.GetDealerVehicleById(id.Value);
            if (dealervehicle == null)
            {
                return HttpNotFound();
            }
            return View(dealervehicle);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DealerVehicles dealervehicle = dealervehiclerepo.GetDealerVehicleById(id);
            dealervehiclerepo.DeleteDealerVehicle(dealervehicle);


            return RedirectToAction("Index", "Dealer", new { id = dealervehicle.DealerId });
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
