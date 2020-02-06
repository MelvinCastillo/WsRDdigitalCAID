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
    public class SMX00100Controller : ApiController
    {
        private CAIDEntities db = new CAIDEntities();

        // GET: api/SMX00100
        public IQueryable<SMX00100> GetSMX00100()
        {
            return db.SMX00100;
        }

        // GET: api/SMX00100/5
        [ResponseType(typeof(SMX00100))]
        public IHttpActionResult GetSMX00100(string id)
        {
            SMX00100 sMX00100 = db.SMX00100.Find(id);
            if (sMX00100 == null)
            {
                return NotFound();
            }

            return Ok(sMX00100);
        }

        // GET: api/SMX00100/REFGUID=?&ROWSGXID=?
        [ResponseType(typeof(SMX00100))]
        public IHttpActionResult GetSMX00100_REFGUIDxROWSGXID(string REFGUID, string ROWSGXID)
        {
           var data = db.SMX00100.Where(x => x.REFGUID.Equals(REFGUID) && (x.ROWSGXID== ROWSGXID));

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        // PUT: api/SMX00100/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSMX00100(string id, SMX00100 sMX00100)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sMX00100.ROWGUID)
            {
                return BadRequest();
            }

            db.Entry(sMX00100).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SMX00100Exists(id))
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

        // POST: api/SMX00100
        [ResponseType(typeof(SMX00100))]
        public IHttpActionResult PostSMX00100(SMX00100 sMX00100)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SMX00100.Add(sMX00100);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SMX00100Exists(sMX00100.ROWGUID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sMX00100.ROWGUID }, sMX00100);
        }

        // DELETE: api/SMX00100/5
        [ResponseType(typeof(SMX00100))]
        public IHttpActionResult DeleteSMX00100(string id)
        {
            SMX00100 sMX00100 = db.SMX00100.Find(id);
            if (sMX00100 == null)
            {
                return NotFound();
            }

            db.SMX00100.Remove(sMX00100);
            db.SaveChanges();

            return Ok(sMX00100);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SMX00100Exists(string id)
        {
            return db.SMX00100.Count(e => e.ROWGUID == id) > 0;
        }
    }
}