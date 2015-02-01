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
using GifAtMe.DAL;
using GifAtMe.Models;

namespace GifAtMe.Controllers
{
    public class GifEntriesController : ApiController
    {
        private GifAtMeContext db = new GifAtMeContext();

        // GET: api/GifEntries
        public IQueryable<GifEntry> GetGifEntries()
        {
            return db.GifEntries;
        }

        // GET: api/GifEntries/5
        [ResponseType(typeof(GifEntry))]
        public async Task<IHttpActionResult> GetGifEntry(int id)
        {
            GifEntry gifEntry = await db.GifEntries.FindAsync(id);
            if (gifEntry == null)
            {
                return NotFound();
            }

            return Ok(gifEntry);
        }

        // GET: api/GifEntries/thisguy
        [ResponseType(typeof(System.String))]
        public async Task<IHttpActionResult> GetGifEntry(string keyword)
        {
            GifEntry gifEntry = await db.GifEntries.Where(e => e.Keyword.Equals(keyword, StringComparison.OrdinalIgnoreCase) && e.AlternateId == 0).FirstOrDefaultAsync();
            if (gifEntry == null)
            {
                return NotFound();
            }

            return Ok(gifEntry.Url);
        }

        // PUT: api/GifEntries/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGifEntry(int id, GifEntry gifEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gifEntry.ID)
            {
                return BadRequest();
            }

            db.Entry(gifEntry).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GifEntryExists(id))
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

        // POST: api/GifEntries
        [ResponseType(typeof(GifEntry))]
        public async Task<IHttpActionResult> PostGifEntry(GifEntry gifEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GifEntries.Add(gifEntry);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = gifEntry.ID }, gifEntry);
        }

        // DELETE: api/GifEntries/5
        [ResponseType(typeof(GifEntry))]
        public async Task<IHttpActionResult> DeleteGifEntry(int id)
        {
            GifEntry gifEntry = await db.GifEntries.FindAsync(id);
            if (gifEntry == null)
            {
                return NotFound();
            }

            db.GifEntries.Remove(gifEntry);
            await db.SaveChangesAsync();

            return Ok(gifEntry);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GifEntryExists(int id)
        {
            return db.GifEntries.Count(e => e.ID == id) > 0;
        }
    }
}