using DealerVehicle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerVehicle.Repository
{
    public class BrandRepo
    {
        private DealerVehicleContext context;
        public BrandRepo()
        {
            context = new DealerVehicleContext();
        }

        public List<Brand> GetBrandAll()
        {
            List<Brand> AllBrands = context.Brand.ToList();
            return AllBrands;
        }
        public Brand GetBrandById(int brandId)
        {

            Brand Brand = context.Brand.Where(a => a.BrandId == brandId).FirstOrDefault();
            return Brand;
        }
        public Brand InsertBrand(Brand brand)
        {
            context.Brand.Add(brand);
            context.SaveChanges();
            return (brand);
        }
        public Brand UpdateBrand(Brand brand)
        {
            context.Entry<Brand>(brand).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            
            return (brand);

        }
        public void DeleteBrand(Brand brand)
        {
            context.Brand.Remove(brand);
            context.SaveChanges();
        }
    }
}