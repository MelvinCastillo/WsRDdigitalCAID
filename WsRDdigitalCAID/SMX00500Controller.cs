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
    public class SMX00500Controller : ApiController
    {
        private CAIDEntities db = new CAIDEntities();

        // GET: api/SMX00500
        public IQueryable<SMX00500> GetSMX00500()
        {
            return db.SMX00500;
        }

        // GET: api/SMX00500/5
        [ResponseType(typeof(SMX00500))]
        public IHttpActionResult GetSMX00500(string id)
        {
            SMX00500 sMX00500 = db.SMX00500.Find(id);
            if (sMX00500 == null)
            {
                return NotFound();
            }

            return Ok(sMX00500);
        }

        // GET: api/SMX00500/REFGUID=?&ROWSGXID=?
        [ResponseType(typeof(SMX00500))]
        public IHttpActionResult GetSMX00500_REFGUIDxROWSGXID(string REFGUID, string ROWSGXID)
        {
            var data = db.SMX00500.Where(x => x.REFGUID.Equals(REFGUID) && (x.ROWSGXID == ROWSGXID));

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        // PUT: api/SMX00500/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSMX00500(string id, SMX00500 sMX00500)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sMX00500.ROWGUID)
            {
                return BadRequest();
            }

            db.Entry(sMX00500).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SMX00500Exists(id))
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

        // POST: api/SMX00500
        [ResponseType(typeof(SMX00500))]
        public IHttpActionResult PostSMX00500(SMX00500 sMX00500)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SMX00500.Add(sMX00500);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SMX00500Exists(sMX00500.ROWGUID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sMX00500.ROWGUID }, sMX00500);
        }

        // DELETE: api/SMX00500/5
        [ResponseType(typeof(SMX00500))]
        public IHttpActionResult DeleteSMX00500(string id)
        {
            SMX00500 sMX00500 = db.SMX00500.Find(id);
            if (sMX00500 == null)
            {
                return NotFound();
            }

            db.SMX00500.Remove(sMX00500);
            db.SaveChanges();

            return Ok(sMX00500);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SMX00500Exists(string id)
        {
            return db.SMX00500.Count(e => e.ROWGUID == id) > 0;
        }
    }
}