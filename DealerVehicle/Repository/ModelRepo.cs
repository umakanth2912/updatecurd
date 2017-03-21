using DealerVehicle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerVehicle.Repository
{
    public class ModelRepo
    {
        private DealerVehicleContext context;
        public ModelRepo()
        {
            context = new DealerVehicleContext();
        }

        public List<Model> GetModelsAll()
        {
            List<Model> AllModels = context.Model.ToList();
            return AllModels;
        }
        public Model GetModelById(int ModelId)
        {

            Model Model = context.Model.Where(a => a.ModelId == ModelId).FirstOrDefault();
            return Model;
        }
        public Model InsertModel(Model model)
        {
            context.Model.Add(model);
            context.SaveChanges();
            return (model);
        }
        public Model UpdateModel(Model model)
        {
            context.Entry<Model>(model).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return (model);

        }
        public void DeleteModel(Model model)
        {
            context.Model.Remove(model);
            context.SaveChanges();
        }
    }
}