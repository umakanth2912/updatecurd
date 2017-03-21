using DealerVehicle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerVehicle.Repository
{
    public class DealerRepo
    {
        private DealerVehicleContext context;
        public DealerRepo()
        {
            context = new DealerVehicleContext();
        }
        public List<Dealer> GetDealerAll()
        {
            List<Dealer> AllDealers = context.Dealer.ToList();
            return AllDealers;
        }

        public Dealer GetDealerById(int dealerId)
        {

            Dealer Dealer = context.Dealer.Where(a => a.Id == dealerId).FirstOrDefault();
            return Dealer;
        }
        public Dealer InsertDealer(Dealer dealer)
        {
            context.Dealer.Add(dealer);
            context.SaveChanges();
            return dealer;
        }
        public Dealer UpdateDealer(Dealer dealer)
        {
            context.Entry<Dealer>(dealer).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            
            return (dealer);

        }
        public void DeleteDealer(Dealer dealer)
        {
            context.Dealer.Remove(dealer);
            context.SaveChanges();
        }
    }
}