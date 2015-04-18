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
    builder.EntitySet<error_log>("error_log");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class error_logController : ODataController
    {
        private charasparkEntities db = new charasparkEntities();

        // GET: odata/error_log
        [EnableQuery]
        public IQueryable<error_log> Geterror_log()
        {
            return db.error_log;
        }

        // GET: odata/error_log(5)
        [EnableQuery]
        public SingleResult<error_log> Geterror_log([FromODataUri] int key)
        {
            return SingleResult.Create(db.error_log.Where(error_log => error_log.error_id == key));
        }

        // PUT: odata/error_log(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<error_log> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            error_log error_log = db.error_log.Find(key);
            if (error_log == null)
            {
                return NotFound();
            }

            patch.Put(error_log);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!error_logExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(error_log);
        }

        // POST: odata/error_log
        public IHttpActionResult Post(error_log error_log)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.error_log.Add(error_log);
            db.SaveChanges();

            return Created(error_log);
        }

        // PATCH: odata/error_log(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<error_log> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            error_log error_log = db.error_log.Find(key);
            if (error_log == null)
            {
                return NotFound();
            }

            patch.Patch(error_log);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!error_logExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(error_log);
        }

        // DELETE: odata/error_log(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            error_log error_log = db.error_log.Find(key);
            if (error_log == null)
            {
                return NotFound();
            }

            db.error_log.Remove(error_log);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool error_logExists(int key)
        {
            return db.error_log.Count(e => e.error_id == key) > 0;
        }
    }
}
