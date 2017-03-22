using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DealerVehicle
{
    public class Repo<T> : IRepository<T> where T : class
        
    {
        DealerVehicleContext DB = new DealerVehicleContext();
        public void Create(T Entity)
        {
            DB.Set<T>().Add(Entity);
            DB.SaveChanges();
            
        }

       
        public void Delete(T Entity)
        {
            DB.Set<T>().Remove(Entity);
            DB.SaveChanges();   
        }

        public IQueryable<T> Read()
        {
            return DB.Set<T>().AsQueryable();
        }

        public void Update(T Entity)
        {
            DB.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
        }
    }
}