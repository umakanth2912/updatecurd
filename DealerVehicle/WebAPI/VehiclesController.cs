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
    public class VehiclesController : ApiController
    {
        //private Repository.VehicleRepo db = new Repository.VehicleRepo();
        private Repo<Vehicle> vehiclerepo;
        public VehiclesController()
        {
            vehiclerepo = new Repo<Vehicle>();
        }
        // GET: api/Vehicles
        [ResponseType(typeof(List<Vehicle>))]
        public IHttpActionResult GetVehicles()
        {
            var result = JsonConvert.SerializeObject(vehiclerepo.Read(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Ok(result);
        }
        [Route("api/vehicles/checkvin/{vin}")]
        [HttpGet]
        public IHttpActionResult GetVIN(string vin)
        {
            var vehiclevin = vehiclerepo.Read().Where(x => x.VIN == vin).Count();
            return Ok(vehiclevin);
        }

        // GET: api/Vehicles/5
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult GetVehicle(int id)
        {
            Vehicle vehicle = vehiclerepo.Read().Where(x => x.DealerId == id).FirstOrDefault(); 
            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        // PUT: api/Vehicles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicle(int id, Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicle.VehicleId)
            {
                return BadRequest();
            }

            vehiclerepo.Create(vehicle);

            try
            {
                //db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(id))
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

        // POST: api/Vehicles
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult PostVehicle(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           vehiclerepo.Create(vehicle);

            return CreatedAtRoute("DefaultApi", new { id = vehicle.VehicleId }, vehicle);
        }

        // DELETE: api/Vehicles/5
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult DeleteVehicle(int id)
        {
            Vehicle vehicle = vehiclerepo.Read().Where(x => x.DealerId == id).FirstOrDefault();
            if (vehicle == null)
            {
                return NotFound();
            }

           vehiclerepo.Delete(vehicle);

            return Ok(vehicle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleExists(int id)
        {
            return vehiclerepo.Read().Count(e => e.VehicleId == id) > 0;
        }
    }
}