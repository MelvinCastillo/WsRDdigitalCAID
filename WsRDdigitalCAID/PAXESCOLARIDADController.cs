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
    public class PAXESCOLARIDADController : ApiController
    {
        private CAIDEntities db = new CAIDEntities();

        // GET: api/PAXESCOLARIDAD
        public IQueryable<PAXESCOLARIDAD> GetPAXESCOLARIDAD()
        {
            return db.PAXESCOLARIDAD;
        }

        // GET: api/PAXESCOLARIDAD/5
        [ResponseType(typeof(PAXESCOLARIDAD))]
        public IHttpActionResult GetPAXESCOLARIDAD(string id)
        {
            PAXESCOLARIDAD pAXESCOLARIDAD = db.PAXESCOLARIDAD.Find(id);
            if (pAXESCOLARIDAD == null)
            {
                return NotFound();
            }

            return Ok(pAXESCOLARIDAD);
        }

        // GET: api/PAXESCOLARIDAD/RECORDID=?&ROWSGXID=?
        [ResponseType(typeof(PAXESCOLARIDAD))]
        public IHttpActionResult GetPAXESCOLARIDAD_RECORDIDxROWSGXID(Int64 RECORDID, string ROWSGXID)
        {
            var data = db.PAXESCOLARIDAD.Where(x => x.RECORDID.Equals(RECORDID) && (x.ROWSGXID == ROWSGXID));

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        // PUT: api/PAXESCOLARIDAD/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPAXESCOLARIDAD(string id, PAXESCOLARIDAD pAXESCOLARIDAD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pAXESCOLARIDAD.ROWGUID)
            {
                return BadRequest();
            }

            db.Entry(pAXESCOLARIDAD).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PAXESCOLARIDADExists(id))
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

        // POST: api/PAXESCOLARIDAD
        [ResponseType(typeof(PAXESCOLARIDAD))]
        public IHttpActionResult PostPAXESCOLARIDAD(PAXESCOLARIDAD pAXESCOLARIDAD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PAXESCOLARIDAD.Add(pAXESCOLARIDAD);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PAXESCOLARIDADExists(pAXESCOLARIDAD.ROWGUID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pAXESCOLARIDAD.ROWGUID }, pAXESCOLARIDAD);
        }

        // DELETE: api/PAXESCOLARIDAD/5
        [ResponseType(typeof(PAXESCOLARIDAD))]
        public IHttpActionResult DeletePAXESCOLARIDAD(string id)
        {
            PAXESCOLARIDAD pAXESCOLARIDAD = db.PAXESCOLARIDAD.Find(id);
            if (pAXESCOLARIDAD == null)
            {
                return NotFound();
            }

            db.PAXESCOLARIDAD.Remove(pAXESCOLARIDAD);
            db.SaveChanges();

            return Ok(pAXESCOLARIDAD);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PAXESCOLARIDADExists(string id)
        {
            return db.PAXESCOLARIDAD.Count(e => e.ROWGUID == id) > 0;
        }
    }
}