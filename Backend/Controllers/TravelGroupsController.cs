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
using Backend.Models;
using Backend.Models.Domain;

namespace Backend.Controllers
{
    public class TravelGroupsController : ApiController
    {
        private BackendContext db = new BackendContext();

        // GET: api/TravelGroups
        public IQueryable<TravelGroup> GetTravelGroups()
        {
            return db.TravelGroups;
        }

        // GET: api/TravelGroups/5
        [ResponseType(typeof(TravelGroup))]
        public IHttpActionResult GetTravelGroup(int id)
        {
            TravelGroup travelGroup = db.TravelGroups.Find(id);
            if (travelGroup == null)
            {
                return NotFound();
            }

            return Ok(travelGroup);
        }

        // PUT: api/TravelGroups/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTravelGroup(int id, TravelGroup travelGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != travelGroup.TravelGroupId)
            {
                return BadRequest();
            }

            db.Entry(travelGroup).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelGroupExists(id))
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

        // POST: api/TravelGroups
        [ResponseType(typeof(TravelGroup))]
        public IHttpActionResult PostTravelGroup(TravelGroup travelGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TravelGroups.Add(travelGroup);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = travelGroup.TravelGroupId }, travelGroup);
        }

        // DELETE: api/TravelGroups/5
        [ResponseType(typeof(TravelGroup))]
        public IHttpActionResult DeleteTravelGroup(int id)
        {
            TravelGroup travelGroup = db.TravelGroups.Find(id);
            if (travelGroup == null)
            {
                return NotFound();
            }

            db.TravelGroups.Remove(travelGroup);
            db.SaveChanges();

            return Ok(travelGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TravelGroupExists(int id)
        {
            return db.TravelGroups.Count(e => e.TravelGroupId == id) > 0;
        }
    }
}