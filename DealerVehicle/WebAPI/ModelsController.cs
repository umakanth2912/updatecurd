using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DealerVehicle;
using DealerVehicle.Models;
using Newtonsoft.Json;

namespace DealerVehicle.WebAPI
{
    public class ModelsController : ApiController
    {
        //private Repository.ModelRepo db = new Repository.ModelRepo();
        private Repo<Model> modelrepo;
        public ModelsController()
        {
            modelrepo = new Repo<Model>();
        }

        // GET: api/Models
        [ResponseType(typeof(List<Model>))]
        public IHttpActionResult GetModels()
        {
            var result = JsonConvert.SerializeObject(modelrepo.Read(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Ok(result);
        }
        [Route("api/models/checkmodel/{modelname}")]
        [HttpGet]
        public IHttpActionResult GetModelByModelName(string modelname)
        {
            var resultmodel = modelrepo.Read().Where(a => a.ModelName == modelname).Count(); 
            
            return Ok(resultmodel);

        }

        // GET: api/Models/5
        [ResponseType(typeof(Model))]

        public IHttpActionResult GetModel(int id)
        {
            Model model = modelrepo.Read().Where(x=>x.ModelId==id).FirstOrDefault();
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // PUT: api/Models/5
        [ResponseType(typeof(void))]
        [Route]
        public IHttpActionResult PutModel(int id, Model model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.ModelId)
            {
                return BadRequest();
            }

            modelrepo.Create(model);

            try
            {
                //db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Models
        [ResponseType(typeof(Model))]
        public IHttpActionResult PostModel(Model model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           modelrepo.Create(model);
            return CreatedAtRoute("DefaultApi", new { id = model.ModelId }, model);
        }

        // DELETE: api/Models/5
        [ResponseType(typeof(Model))]
        public IHttpActionResult DeleteModel(int id)
        {
            Model model = modelrepo.Read().Where(x => x.ModelId == id).FirstOrDefault();
            if (model == null)
            {
                return NotFound();
            }

            modelrepo.Delete(model);

            return Ok(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModelExists(int id)
        {
            return modelrepo.Read().Count(e => e.ModelId == id) > 0;
        }
    }
}