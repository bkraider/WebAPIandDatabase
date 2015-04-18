using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using CharaSparksvc.Models;

namespace CharaSparksvc.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using CharaSparksvc.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<donation>("donations");
    builder.EntitySet<donation_status>("donation_status"); 
    builder.EntitySet<user>("users"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class donationsController : ODataController
    {
        private charasparkEntities db = new charasparkEntities();

        // GET: odata/donations
        [EnableQuery]
        public IQueryable<donation> Getdonations()
        {
            return db.donations;
        }

        // GET: odata/donations(5)
        [EnableQuery]
        public SingleResult<donation> Getdonation([FromODataUri] int key)
        {
            return SingleResult.Create(db.donations.Where(donation => donation.donation_id == key));
        }

        // PUT: odata/donations(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<donation> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            donation donation = db.donations.Find(key);
            if (donation == null)
            {
                return NotFound();
            }

            patch.Put(donation);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!donationExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(donation);
        }

        // POST: odata/donations
        public IHttpActionResult Post(donation donation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.donations.Add(donation);
            db.SaveChanges();

            return Created(donation);
        }

        // PATCH: odata/donations(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<donation> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            donation donation = db.donations.Find(key);
            if (donation == null)
            {
                return NotFound();
            }

            patch.Patch(donation);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!donationExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(donation);
        }

        // DELETE: odata/donations(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            donation donation = db.donations.Find(key);
            if (donation == null)
            {
                return NotFound();
            }

            db.donations.Remove(donation);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/donations(5)/donation_status
        [EnableQuery]
        public SingleResult<donation_status> Getdonation_status([FromODataUri] int key)
        {
            return SingleResult.Create(db.donations.Where(m => m.donation_id == key).Select(m => m.donation_status));
        }

        // GET: odata/donations(5)/user
        [EnableQuery]
        public SingleResult<user> Getuser([FromODataUri] int key)
        {
            return SingleResult.Create(db.donations.Where(m => m.donation_id == key).Select(m => m.user));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool donationExists(int key)
        {
            return db.donations.Count(e => e.donation_id == key) > 0;
        }
    }
}
