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
using CharaSparksvc.Models;

namespace CharaSparksvc.Controllers
{
    public class donationsController : ApiController
    {
        private charasparkEntities db = new charasparkEntities();

        // GET: api/donations
        public IQueryable<donation> Getdonations()
        {
            return db.donations;
        }

        // GET: api/donations/5
        [ResponseType(typeof(donation))]
        public IHttpActionResult Getdonation(int id)
        {
            donation donation = db.donations.Find(id);
            if (donation == null)
            {
                return NotFound();
            }

            return Ok(donation);
        }

        // PUT: api/donations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdonation(int id, donation donation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donation.donation_id)
            {
                return BadRequest();
            }

            db.Entry(donation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!donationExists(id))
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

        // POST: api/donations
        [ResponseType(typeof(donation))]
        public IHttpActionResult Postdonation(donation donation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.donations.Add(donation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = donation.donation_id }, donation);
        }

        // DELETE: api/donations/5
        [ResponseType(typeof(donation))]
        public IHttpActionResult Deletedonation(int id)
        {
            donation donation = db.donations.Find(id);
            if (donation == null)
            {
                return NotFound();
            }

            db.donations.Remove(donation);
            db.SaveChanges();

            return Ok(donation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool donationExists(int id)
        {
            return db.donations.Count(e => e.donation_id == id) > 0;
        }
    }
}