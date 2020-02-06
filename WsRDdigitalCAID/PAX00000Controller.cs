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
    public class PAX00000Controller : ApiController
    {
        private CAIDEntities db = new CAIDEntities();

        // GET: api/PAX00000
        public IQueryable<PAX00000> GetPAX00000()
        {
            return db.PAX00000;
        }

        // GET: api/PAX00000/5
        [ResponseType(typeof(PAX00000))]
        public IHttpActionResult GetPAX00000(string id)
        {
            PAX00000 pAX00000 = db.PAX00000.Find(id);
            if (pAX00000 == null)
            {
                return NotFound();
            }

            return Ok(pAX00000);
        }

        // GET: api/PAX00000/ROWGUID=?&ROWSGXID=?
        [ResponseType(typeof(PAX00000))]
        public IHttpActionResult GetPAX00000_ROWGUIDxROWSGXID(string ROWGUID, string ROWSGXID)
        {
            var data = db.PAX00000.Where(x => x.ROWGUID.Equals(ROWGUID) && (x.ROWSGXID == ROWSGXID));

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        // GET: api/PAX00000/RECORDID=?&ROWSGXID=?
        [ResponseType(typeof(PAX00000))]
        public IHttpActionResult GetPAX00000_RECORDIDxROWSGXID(int RECORDID, string ROWSGXID)
        {
            var data = db.PAX00000.Where(x => x.RECORDID.Equals(RECORDID) && (x.ROWSGXID == ROWSGXID));

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        // PUT: api/PAX00000/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPAX00000(string id, PAX00000 pAX00000)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pAX00000.ROWGUID)
            {
                return BadRequest();
            }

            db.Entry(pAX00000).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PAX00000Exists(id))
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

        // POST: api/PAX00000
        [ResponseType(typeof(PAX00000))]
        public IHttpActionResult PostPAX00000(PAX00000 pAX00000)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PAX00000.Add(pAX00000);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PAX00000Exists(pAX00000.ROWGUID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pAX00000.ROWGUID }, pAX00000);
        }

        // DELETE: api/PAX00000/5
        [ResponseType(typeof(PAX00000))]
        public IHttpActionResult DeletePAX00000(string id)
        {
            PAX00000 pAX00000 = db.PAX00000.Find(id);
            if (pAX00000 == null)
            {
                return NotFound();
            }

            db.PAX00000.Remove(pAX00000);
            db.SaveChanges();

            return Ok(pAX00000);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PAX00000Exists(string id)
        {
            return db.PAX00000.Count(e => e.ROWGUID == id) > 0;
        }
    }
}