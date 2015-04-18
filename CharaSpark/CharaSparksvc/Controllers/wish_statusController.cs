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
    builder.EntitySet<wish_status>("wish_status");
    builder.EntitySet<wish>("wishes"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class wish_statusController : ODataController
    {
        private charasparkEntities db = new charasparkEntities();

        // GET: odata/wish_status
        [EnableQuery]
        public IQueryable<wish_status> Getwish_status()
        {
            return db.wish_status;
        }

        // GET: odata/wish_status(5)
        [EnableQuery]
        public SingleResult<wish_status> Getwish_status([FromODataUri] int key)
        {
            return SingleResult.Create(db.wish_status.Where(wish_status => wish_status.wish_status_id == key));
        }

        // PUT: odata/wish_status(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<wish_status> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            wish_status wish_status = db.wish_status.Find(key);
            if (wish_status == null)
            {
                return NotFound();
            }

            patch.Put(wish_status);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!wish_statusExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(wish_status);
        }

        // POST: odata/wish_status
        public IHttpActionResult Post(wish_status wish_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.wish_status.Add(wish_status);
            db.SaveChanges();

            return Created(wish_status);
        }

        // PATCH: odata/wish_status(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<wish_status> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            wish_status wish_status = db.wish_status.Find(key);
            if (wish_status == null)
            {
                return NotFound();
            }

            patch.Patch(wish_status);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!wish_statusExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(wish_status);
        }

        // DELETE: odata/wish_status(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            wish_status wish_status = db.wish_status.Find(key);
            if (wish_status == null)
            {
                return NotFound();
            }

            db.wish_status.Remove(wish_status);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/wish_status(5)/wishes
        [EnableQuery]
        public IQueryable<wish> Getwishes([FromODataUri] int key)
        {
            return db.wish_status.Where(m => m.wish_status_id == key).SelectMany(m => m.wishes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool wish_statusExists(int key)
        {
            return db.wish_status.Count(e => e.wish_status_id == key) > 0;
        }
    }
}
