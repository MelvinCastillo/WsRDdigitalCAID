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

namespace WsRDdigitalCAID
{
    public class PAX00001Controller : ApiController
    {
        private CAIDEntities db = new CAIDEntities();

        // GET: api/PAX00001
        public IQueryable<PAX00001> GetPAX00001()
        {
            return db.PAX00001;
        }

        // GET: api/PAX00001/5
        [ResponseType(typeof(PAX00001))]
        public IHttpActionResult GetPAX00001(string id)
        {
            PAX00001 pAX00001 = db.PAX00001.Find(id);
            if (pAX00001 == null)
            {
                return NotFound();
            }

            return Ok(pAX00001);
        }

        // GET: api/pAX00001/REFGUID=?&ROWSGXID=?
        [ResponseType(typeof(PAX00001))]
        public IHttpActionResult GetpAX00001_REFGUIDxROWSGXID(string REFGUID, string ROWSGXID)
        {
            var data = db.PAX00001.Where(x => x.REFGUID.Equals(REFGUID) && (x.ROWSGXID == ROWSGXID));

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        // PUT: api/PAX00001/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPAX00001(string id, PAX00001 pAX00001)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pAX00001.ROWGUID)
            {
                return BadRequest();
            }

            db.Entry(pAX00001).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PAX00001Exists(id))
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

        // POST: api/PAX00001
        [ResponseType(typeof(PAX00001))]
        public IHttpActionResult PostPAX00001(PAX00001 pAX00001)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PAX00001.Add(pAX00001);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PAX00001Exists(pAX00001.ROWGUID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pAX00001.ROWGUID }, pAX00001);
        }

        // DELETE: api/PAX00001/5
        [ResponseType(typeof(PAX00001))]
        public IHttpActionResult DeletePAX00001(string id)
        {
            PAX00001 pAX00001 = db.PAX00001.Find(id);
            if (pAX00001 == null)
            {
                return NotFound();
            }

            db.PAX00001.Remove(pAX00001);
            db.SaveChanges();

            return Ok(pAX00001);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PAX00001Exists(string id)
        {
            return db.PAX00001.Count(e => e.ROWGUID == id) > 0;
        }
    }
}