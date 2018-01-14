using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using CarCmsWebApi.Models;

namespace CarCmsWebApi.Controllers
{
    public class PerformancesController : ApiController
    {
        private readonly ApplicationDBContext db = new ApplicationDBContext();

        // GET: api/Performances
        public IQueryable<Performance> GetPerformances()
        {
            return db.Performances;
        }

        // GET: api/Performances/5
        [ResponseType(typeof(Performance))]
        public IHttpActionResult GetPerformance(int id)
        {
            Performance performance = db.Performances.Find(id);
            if (performance == null)
            {
                return NotFound();
            }

            return Ok(performance);
        }

        // PUT: api/Performances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerformance(int id, Performance performance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != performance.Id)
            {
                return BadRequest();
            }

            db.Entry(performance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerformanceExists(id))
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

        // POST: api/Performances
        [ResponseType(typeof(Performance))]
        public IHttpActionResult PostPerformance(Performance performance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Performances.Add(performance);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = performance.Id }, performance);
        }

        // DELETE: api/Performances/5
        [ResponseType(typeof(Performance))]
        public IHttpActionResult DeletePerformance(int id)
        {
            Performance performance = db.Performances.Find(id);
            if (performance == null)
            {
                return NotFound();
            }

            db.Performances.Remove(performance);
            db.SaveChanges();

            return Ok(performance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PerformanceExists(int id)
        {
            return db.Performances.Count(e => e.Id == id) > 0;
        }
    }
}