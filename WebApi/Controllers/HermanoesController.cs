using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class HermanoesController : ApiController
    {
        private NuevaJerusalenEntities db = new NuevaJerusalenEntities();

        // GET: api/Hermanoes
        public IQueryable<Hermano> GetHermano()
        {
            return db.Hermano;
        }

        // GET: api/Hermanoes/5
        [ResponseType(typeof(Hermano))]
        public IHttpActionResult GetHermano(string id)
        {
            Hermano hermano = db.Hermano.Find(id);
            if (hermano == null)
            {
                return NotFound();
            }

            return Ok(hermano);
        }

        // PUT: api/Hermanoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHermano(string id, Hermano hermano)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hermano.cedula)
            {
                return BadRequest();
            }

            db.Entry(hermano).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HermanoExists(id))
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

        // POST: api/Hermanoes
        [ResponseType(typeof(Hermano))]
        public ObjectResult<InsertaHermanos_Result> PostHermano(Hermano h)
        {


            var result = db.InsertaHermanos(h.cedula, h.nombre, h.apellidos,
                h.IdSexo,h.Fecha_Nac,h.IdProvincia,h.Ciudad,
                h.Direccion, h.Telefono, h.IdEstadoCivil, h.TipoSangre,
                h.Bautizo, h.FechaBautizo,h.activo);
            try
            {
                db.SaveChanges();
                
            }
            catch 
            {
                return result;
            }

            return result ;
        }

        // DELETE: api/Hermanoes/5
        [ResponseType(typeof(Hermano))]
        public IHttpActionResult DeleteHermano(string id)
        {
            Hermano hermano = db.Hermano.Find(id);
            if (hermano == null)
            {
                return NotFound();
            }

            db.Hermano.Remove(hermano);
            db.SaveChanges();

            return Ok(hermano);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HermanoExists(string id)
        {
            return db.Hermano.Count(e => e.cedula == id) > 0;
        }
    }
}