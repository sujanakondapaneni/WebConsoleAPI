using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebConsoleAPI.Context;
using WebConsoleAPI.Models;

namespace WebConsoleAPI.Controllers
{
    public class ConsoleModelsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/ConsoleModels
        public IQueryable<ConsoleModel> GetConsoleMessage()
        {
            db.SaveChanges();
            return db.ConsoleMessage;
        }

        // GET: api/ConsoleModels/5
        [ResponseType(typeof(ConsoleModel))]
        public async Task<IHttpActionResult> GetConsoleModel(int id)
        {
            ConsoleModel consoleModel = await db.ConsoleMessage.FindAsync(id);
            if (consoleModel == null)
            {
                return NotFound();
            }

            return Ok(consoleModel);
        }

        // PUT: api/ConsoleModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutConsoleModel(int id, ConsoleModel consoleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consoleModel.MessageId)
            {
                return BadRequest();
            }

            db.Entry(consoleModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsoleModelExists(id))
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

        // POST: api/ConsoleModels
        [ResponseType(typeof(ConsoleModel))]
        public async Task<IHttpActionResult> PostConsoleModel(ConsoleModel consoleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ConsoleMessage.Add(consoleModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = consoleModel.MessageId }, consoleModel);
        }

        // DELETE: api/ConsoleModels/5
        [ResponseType(typeof(ConsoleModel))]
        public async Task<IHttpActionResult> DeleteConsoleModel(int id)
        {
            ConsoleModel consoleModel = await db.ConsoleMessage.FindAsync(id);
            if (consoleModel == null)
            {
                return NotFound();
            }

            db.ConsoleMessage.Remove(consoleModel);
            await db.SaveChangesAsync();

            return Ok(consoleModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConsoleModelExists(int id)
        {
            return db.ConsoleMessage.Count(e => e.MessageId == id) > 0;
        }
    }
}