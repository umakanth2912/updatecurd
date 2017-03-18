using DealerVehicle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerVehicle.Repository
{
    public class DealerVehicleRepo
    {
        private DealerVehicleContext context;
        public DealerVehicleRepo()
        {
            context = new DealerVehicleContext();
        }
        public List<DealerVehicles> GetDealerVehicleAll()
        {
            List<DealerVehicles> AllDealerVehicles = context.DealerVehicle.ToList();
            return AllDealerVehicles;
        }
        public DealerVehicles GetDealerVehicleById(int dealervehicleId)
        {

            DealerVehicles dealervehicle = context.DealerVehicle.Where(a => a.DealerVehicleId == dealervehicleId).FirstOrDefault();
            return dealervehicle;
        }
        public void DeleteDealerVehicle(DealerVehicles dealervehicle)
        {
            context.DealerVehicle.Remove(dealervehicle);
            context.SaveChanges();
        }


    }
}