using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerVehicle
{
    public interface IRepository<T> where T : class
    {
        //CRUD Operations
        void Create(T Entity);
        IQueryable<T> Read();
        
        void Update(T Entity);
        void Delete(T Entity);
        
    }
}