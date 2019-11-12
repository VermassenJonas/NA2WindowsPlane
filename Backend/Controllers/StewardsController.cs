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
    public class StewardsController : ApiController
    {
        private BackendContext db = new BackendContext();

        // GET: api/Stewards
        public IQueryable<Steward> GetStewards()
        {
            return db.Stewards;
        }

        // GET: api/Stewards/5
        [ResponseType(typeof(Steward))]
        public IHttpActionResult GetSteward(int id)
        {
            Steward steward = db.Stewards.Find(id);
            if (steward == null)
            {
                return NotFound();
            }

            return Ok(steward);
        }

        // PUT: api/Stewards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSteward(int id, Steward steward)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != steward.PersonnelNumber)
            {
                return BadRequest();
            }

            db.Entry(steward).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StewardExists(id))
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

        // POST: api/Stewards
        [ResponseType(typeof(Steward))]
        public IHttpActionResult PostSteward(Steward steward)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stewards.Add(steward);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = steward.PersonnelNumber }, steward);
        }

        // DELETE: api/Stewards/5
        [ResponseType(typeof(Steward))]
        public IHttpActionResult DeleteSteward(int id)
        {
            Steward steward = db.Stewards.Find(id);
            if (steward == null)
            {
                return NotFound();
            }

            db.Stewards.Remove(steward);
            db.SaveChanges();

            return Ok(steward);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StewardExists(int id)
        {
            return db.Stewards.Count(e => e.PersonnelNumber == id) > 0;
        }
    }
}