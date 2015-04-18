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
    builder.EntitySet<wish>("wishes");
    builder.EntitySet<donation_status>("donation_status"); 
    builder.EntitySet<user>("users"); 
    builder.EntitySet<wish_status>("wish_status"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class wishesController : ODataController
    {
        private charasparkEntities db = new charasparkEntities();

        // GET: odata/wishes
        [EnableQuery]
        public IQueryable<wish> Getwishes()
        {
            return db.wishes;
        }

        // GET: odata/wishes(5)
        [EnableQuery]
        public SingleResult<wish> Getwish([FromODataUri] int key)
        {
            return SingleResult.Create(db.wishes.Where(wish => wish.wish_id == key));
        }

        // PUT: odata/wishes(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<wish> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            wish wish = db.wishes.Find(key);
            if (wish == null)
            {
                return NotFound();
            }

            patch.Put(wish);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!wishExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(wish);
        }

        // POST: odata/wishes
        public IHttpActionResult Post(wish wish)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.wishes.Add(wish);
            db.SaveChanges();

            return Created(wish);
        }

        // PATCH: odata/wishes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<wish> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            wish wish = db.wishes.Find(key);
            if (wish == null)
            {
                return NotFound();
            }

            patch.Patch(wish);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!wishExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(wish);
        }

        // DELETE: odata/wishes(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            wish wish = db.wishes.Find(key);
            if (wish == null)
            {
                return NotFound();
            }

            db.wishes.Remove(wish);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/wishes(5)/donation_status
        [EnableQuery]
        public SingleResult<donation_status> Getdonation_status([FromODataUri] int key)
        {
            return SingleResult.Create(db.wishes.Where(m => m.wish_id == key).Select(m => m.donation_status));
        }

        // GET: odata/wishes(5)/user
        [EnableQuery]
        public SingleResult<user> Getuser([FromODataUri] int key)
        {
            return SingleResult.Create(db.wishes.Where(m => m.wish_id == key).Select(m => m.user));
        }

        // GET: odata/wishes(5)/wish_status
        [EnableQuery]
        public SingleResult<wish_status> Getwish_status([FromODataUri] int key)
        {
            return SingleResult.Create(db.wishes.Where(m => m.wish_id == key).Select(m => m.wish_status));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool wishExists(int key)
        {
            return db.wishes.Count(e => e.wish_id == key) > 0;
        }
    }
}
