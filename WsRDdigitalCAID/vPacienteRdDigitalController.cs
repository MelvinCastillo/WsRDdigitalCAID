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
    public class vPacienteRdDigitalController : ApiController
    {
        private CAIDEntities db = new CAIDEntities();

        // GET: api/vPacienteRdDigitals
        public IQueryable<vPacienteRdDigital> GetvPacienteRdDigital()
        {
            return db.vPacienteRdDigital;
        }

        // GET: api/vPacienteRdDigitals/5
        [ResponseType(typeof(vPacienteRdDigital))]
        public IHttpActionResult GetvPacienteRdDigital(string id)
        {
            vPacienteRdDigital vPacienteRdDigital = db.vPacienteRdDigital.Find(id);
            if (vPacienteRdDigital == null)
            {
                return NotFound();
            }

            return Ok(vPacienteRdDigital);
        }


        // GET: api/vPacienteRdDigitals/RECORDID=?&ROWSGXID=?
        [ResponseType(typeof(vPacienteRdDigital))]
        public IHttpActionResult GetvPaciente_RECORDIDxROWSGXID(int RECORDID, string ROWSGXID)
        {
            var data = db.vPacienteRdDigital.Where(x => x.RECORDID.Equals(RECORDID) && (x.ROWSGXID == ROWSGXID));

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
            //vPacienteRdDigital vPacienteRdDigital = db.vPacienteRdDigital.Find(id);
            //if (vPacienteRdDigital == null)
            //{
            //    return NotFound();
            //}

            //return Ok(vPacienteRdDigital);

        } 

        // PUT: api/vPacienteRdDigitals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutvPacienteRdDigital(string id, vPacienteRdDigital vPacienteRdDigital)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vPacienteRdDigital.CENTRO)
            {
                return BadRequest();
            }

            db.Entry(vPacienteRdDigital).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vPacienteRdDigitalExists(id))
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

        // POST: api/vPacienteRdDigitals
        [ResponseType(typeof(vPacienteRdDigital))]
        public IHttpActionResult PostvPacienteRdDigital(vPacienteRdDigital vPacienteRdDigital)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.vPacienteRdDigital.Add(vPacienteRdDigital);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (vPacienteRdDigitalExists(vPacienteRdDigital.CENTRO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vPacienteRdDigital.CENTRO }, vPacienteRdDigital);
        }

        // DELETE: api/vPacienteRdDigitals/5
        [ResponseType(typeof(vPacienteRdDigital))]
        public IHttpActionResult DeletevPacienteRdDigital(string id)
        {
            vPacienteRdDigital vPacienteRdDigital = db.vPacienteRdDigital.Find(id);
            if (vPacienteRdDigital == null)
            {
                return NotFound();
            }

            db.vPacienteRdDigital.Remove(vPacienteRdDigital);
            db.SaveChanges();

            return Ok(vPacienteRdDigital);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vPacienteRdDigitalExists(string id)
        {
            return db.vPacienteRdDigital.Count(e => e.CENTRO == id) > 0;
        }
    }
}