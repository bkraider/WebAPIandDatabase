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
    builder.EntitySet<donation_status>("donation_status");
    builder.EntitySet<donation>("donations"); 
    builder.EntitySet<wish>("wishes"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class donation_statusController : ODataController
    {
        private charasparkEntities db = new charasparkEntities();

        // GET: odata/donation_status
        [EnableQuery]
        public IQueryable<donation_status> Getdonation_status()
        {
            return db.donation_status;
        }

        // GET: odata/donation_status(5)
        [EnableQuery]
        public SingleResult<donation_status> Getdonation_status([FromODataUri] int key)
        {
            return SingleResult.Create(db.donation_status.Where(donation_status => donation_status.donation_status_id == key));
        }

        // PUT: odata/donation_status(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<donation_status> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            donation_status donation_status = db.donation_status.Find(key);
            if (donation_status == null)
            {
                return NotFound();
            }

            patch.Put(donation_status);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!donation_statusExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(donation_status);
        }

        // POST: odata/donation_status
        public IHttpActionResult Post(donation_status donation_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.donation_status.Add(donation_status);
            db.SaveChanges();

            return Created(donation_status);
        }

        // PATCH: odata/donation_status(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<donation_status> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            donation_status donation_status = db.donation_status.Find(key);
            if (donation_status == null)
            {
                return NotFound();
            }

            patch.Patch(donation_status);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!donation_statusExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(donation_status);
        }

        // DELETE: odata/donation_status(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            donation_status donation_status = db.donation_status.Find(key);
            if (donation_status == null)
            {
                return NotFound();
            }

            db.donation_status.Remove(donation_status);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/donation_status(5)/donations
        [EnableQuery]
        public IQueryable<donation> Getdonations([FromODataUri] int key)
        {
            return db.donation_status.Where(m => m.donation_status_id == key).SelectMany(m => m.donations);
        }

        // GET: odata/donation_status(5)/wishes
        [EnableQuery]
        public IQueryable<wish> Getwishes([FromODataUri] int key)
        {
            return db.donation_status.Where(m => m.donation_status_id == key).SelectMany(m => m.wishes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool donation_statusExists(int key)
        {
            return db.donation_status.Count(e => e.donation_status_id == key) > 0;
        }
    }
}
