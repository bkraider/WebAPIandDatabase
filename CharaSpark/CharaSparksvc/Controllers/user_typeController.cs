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
    builder.EntitySet<user_type>("user_type");
    builder.EntitySet<user>("users"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class user_typeController : ODataController
    {
        private charasparkEntities db = new charasparkEntities();

        // GET: odata/user_type
        [EnableQuery]
        public IQueryable<user_type> Getuser_type()
        {
            return db.user_type;
        }

        // GET: odata/user_type(5)
        [EnableQuery]
        public SingleResult<user_type> Getuser_type([FromODataUri] int key)
        {
            return SingleResult.Create(db.user_type.Where(user_type => user_type.user_type_id == key));
        }

        // PUT: odata/user_type(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<user_type> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            user_type user_type = db.user_type.Find(key);
            if (user_type == null)
            {
                return NotFound();
            }

            patch.Put(user_type);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!user_typeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(user_type);
        }

        // POST: odata/user_type
        public IHttpActionResult Post(user_type user_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.user_type.Add(user_type);
            db.SaveChanges();

            return Created(user_type);
        }

        // PATCH: odata/user_type(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<user_type> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            user_type user_type = db.user_type.Find(key);
            if (user_type == null)
            {
                return NotFound();
            }

            patch.Patch(user_type);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!user_typeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(user_type);
        }

        // DELETE: odata/user_type(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            user_type user_type = db.user_type.Find(key);
            if (user_type == null)
            {
                return NotFound();
            }

            db.user_type.Remove(user_type);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/user_type(5)/users
        [EnableQuery]
        public IQueryable<user> Getusers([FromODataUri] int key)
        {
            return db.user_type.Where(m => m.user_type_id == key).SelectMany(m => m.users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool user_typeExists(int key)
        {
            return db.user_type.Count(e => e.user_type_id == key) > 0;
        }
    }
}
