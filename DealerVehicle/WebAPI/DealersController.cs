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
using DealerVehicle.Repository;

namespace DealerVehicle.WebAPI
{
    public class DealersController : ApiController
    {
        private DealerRepo db = new DealerRepo();

        // GET: api/Dealers
        [ResponseType(typeof(List<Dealer>))]
        public IHttpActionResult GetDealers()
        {
            var result = JsonConvert.SerializeObject(db.GetDealerAll(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Ok(result);
        }

        // GET: api/Dealers/5
        [ResponseType(typeof(Dealer))]
        public IHttpActionResult GetDealer(int id)
        {
            Dealer dealer = db.GetDealerById(id);
            if (dealer == null)
            {
                return NotFound();
            }

            return Ok(dealer);
        }

        // PUT: api/Dealers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDealer(int id, Dealer dealer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dealer.Id)
            {
                return BadRequest();
            }

            db.InsertDealer(dealer);

            try
            {
                //db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DealerExists(id))
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

        // POST: api/Dealers
        [ResponseType(typeof(Dealer))]
        public IHttpActionResult PostDealer(Dealer dealer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InsertDealer(dealer);

            return CreatedAtRoute("DefaultApi", new { id = dealer.Id }, dealer);
        }

        // DELETE: api/Dealers/5
        [ResponseType(typeof(Dealer))]
        public IHttpActionResult DeleteDealer(int id)
        {
            Dealer dealer = db.GetDealerById(id);
            if (dealer == null)
            {
                return NotFound();
            }

            db.DeleteDealer(dealer);

            return Ok(dealer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DealerExists(int id)
        {
            return db.GetDealerAll().Count(e => e.Id == id) > 0;
        }
    }
}