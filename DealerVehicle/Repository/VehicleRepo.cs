using DealerVehicle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerVehicle.Repository
{
    public class VehicleRepo
    {
        private DealerVehicleContext context;
        public VehicleRepo()
        {
            context = new DealerVehicleContext();
        }

        public List<Vehicle> GetVehicleAll()
        {
            List<Vehicle> AllVehicles = context.Vehicle.ToList();
            return AllVehicles;
        }

        public Vehicle GetVehicleById(int VehicleId)
        {

            Vehicle Vehicle = context.Vehicle.Where(a => a.VehicleId == VehicleId).FirstOrDefault();
            return Vehicle;
        }
        public Vehicle InsertVehicle(Vehicle vehicle)
        {
            context.Vehicle.Add(vehicle);
            context.SaveChanges();
            return (vehicle);
        }
        public Vehicle UpdateVehicle(Vehicle vehicle)
        {
            context.Entry<Vehicle>(vehicle).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return (vehicle);

        }
        public void DeleteVehicle(Vehicle vehicle)
        {
            context.Vehicle.Remove(vehicle);
            context.SaveChanges();
        }
    }
}