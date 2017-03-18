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

            Dealer Dealer = context.Dealer.Where(a => a.DealerId == dealerId).FirstOrDefault();
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
            Dealer DealerToUpdate = context.Dealer.Where(a => a.DealerId == dealer.DealerId).FirstOrDefault();
            DealerToUpdate.DealerName = dealer.DealerName;
            DealerToUpdate.DealerCity = dealer.DealerCity;
            DealerToUpdate.DealerCountry = dealer.DealerCountry;
            DealerToUpdate.DealerPhoneNumber = dealer.DealerPhoneNumber;
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