using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WsRDdigitalCAID
{
    public class vCLASIFICADORESController : ApiController
    {
        private CAIDEntities db = new CAIDEntities();
        //private readonly Expression<Func<vCLASIFICADORES, bool>> WS;

        // GET: api/vCLASIFICADORES
        //Catalogo de Informaciones a intercambiar con RD Digital.
        public IQueryable<vCLASIFICADORES> GetvCLASIFICADORES()
        {
            return db.vCLASIFICADORES;
        }

        // GET: api/vCLASIFICADORES/5
        [ResponseType(typeof(vCLASIFICADORES))]
        //melvin
        public IHttpActionResult GetvCLASIFICADORES(string id)
        {
            //melvin
            //vCLASIFICADORES vCLASIFICADORES = db.vCLASIFICADORES.Find(id);
            vCLASIFICADORES vCLASIFICADORES = db.vCLASIFICADORES.Find(id);
            
            if (vCLASIFICADORES == null)
            {
                return NotFound();
            }

            return Ok(vCLASIFICADORES);
        }
         
        // GET: api/vCLASIFICADORES/atipoclas=?
        [ResponseType(typeof(vCLASIFICADORES))] 
        public IHttpActionResult GetvCLASIFICADORESxatipoclas(string atipoclas)
        {
            //melvin
            //vCLASIFICADORES vCLASIFICADORES = db.vCLASIFICADORES.Find(id);

            //vCLASIFICADORES vCLASIFICADORES = db.vCLASIFICADORES.Find(id);

            //if (vCLASIFICADORES == null)
            //{
            //    return NotFound();
            //}

            //return Ok(vCLASIFICADORES);

            var data = db.vCLASIFICADORES.Where(x => x.atipoclas.Equals(atipoclas));

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);

        }

        // PUT: api/vCLASIFICADORES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutvCLASIFICADORES(string id, vCLASIFICADORES vCLASIFICADORES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vCLASIFICADORES.atipoclas)
            {
                return BadRequest();
            }

            db.Entry(vCLASIFICADORES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vCLASIFICADORESExists(id))
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

        // POST: api/vCLASIFICADORES
        [ResponseType(typeof(vCLASIFICADORES))]
        public IHttpActionResult PostvCLASIFICADORES(vCLASIFICADORES vCLASIFICADORES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.vCLASIFICADORES.Add(vCLASIFICADORES);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (vCLASIFICADORESExists(vCLASIFICADORES.atipoclas))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vCLASIFICADORES.atipoclas }, vCLASIFICADORES);
        }

        // DELETE: api/vCLASIFICADORES/5
        [ResponseType(typeof(vCLASIFICADORES))]
        public IHttpActionResult DeletevCLASIFICADORES(string id)
        {
            vCLASIFICADORES vCLASIFICADORES = db.vCLASIFICADORES.Find(id);
            if (vCLASIFICADORES == null)
            {
                return NotFound();
            }

            db.vCLASIFICADORES.Remove(vCLASIFICADORES);
            db.SaveChanges();

            return Ok(vCLASIFICADORES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vCLASIFICADORESExists(string id)
        {
            return db.vCLASIFICADORES.Count(e => e.atipoclas == id) > 0;
        }
    }
}