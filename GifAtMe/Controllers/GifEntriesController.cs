﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GifAtMe.SL.Services;
using GifAtMe.SL.DTOs;

namespace GifAtMe.Controllers
{
    public class GifEntriesController : ApiController
    {
        private GifEntryService _ges = new GifEntryService();

        // GET: api/GifEntries/mknowles
        public IList<GifEntryDTO> GetGifEntries(string userName)
        {
            //ctx.GifEntries.Where(g => g.UserName.Equals(userName, StringComparison.InvariantCultureIgnoreCase));
            return _ges.GetGifEntriesByUserName(userName);
        }

        // GET: api/GifEntries/5
        [ResponseType(typeof(GifEntryDTO))]
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
        public async Task<IHttpActionResult> GetGifEntry(string keyword, string userName, int? alternateID)
        {
            try
            {
                GifEntry gif;
                if (!alternateID.HasValue)
                {
                    // If user doesn't want a specific gif from their alternates for the chosen keyword, select a random one for them
                    var totalUserGifsForKeyword = await db.GifEntries.Where(g => g.Keyword.Equals(keyword, StringComparison.OrdinalIgnoreCase)
                        && g.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase)).ToListAsync();
                    int rand = new Random().Next(totalUserGifsForKeyword.Count());

                    gif = totalUserGifsForKeyword.Skip(rand).First();
                }
                else
                {
                    gif = await db.GifEntries
                        .Where(e => e.Keyword.Equals(keyword, StringComparison.OrdinalIgnoreCase)
                            && e.AlternateId == alternateID
                            && e.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase))
                        .SingleOrDefaultAsync();
                }
                if (gif == null)
                {
                    return NotFound();
                }
                return Ok(gif);
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT: api/GifEntries/highfive
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGifEntry(string keyword, GifEntry gifEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (keyword != gifEntry.Keyword)
            {
                return BadRequest();
            }

            try
            {
                // Check to see if the client new the gifs id when sending update request
                if (gifEntry.ID == 0)
                {
                    // Because clients do not pass an id for this method,
                    // select the appropriate item by keyword field
                    gifEntry.ID = db.GifEntries.Where(g => g.Keyword.Equals(keyword, StringComparison.OrdinalIgnoreCase)
                        && g.AlternateId == gifEntry.AlternateId
                        && g.UserName.Equals(gifEntry.UserName, StringComparison.OrdinalIgnoreCase)).SingleOrDefault().ID;
                }

                db.Entry(gifEntry).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (ex is ArgumentNullException || ex is InvalidOperationException)
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

            try
            {
                // Set the alternate ID of the new entry to 1 more than the previous for the same keyword
                var latestEntryByAlternateID = await db.GifEntries.Where(g => g.Keyword.Equals(gifEntry.Keyword, StringComparison.OrdinalIgnoreCase)
                    && g.UserName.Equals(gifEntry.UserName, StringComparison.OrdinalIgnoreCase)).OrderByDescending(g => g.AlternateId).FirstOrDefaultAsync();
                if (latestEntryByAlternateID != null)
                {
                    gifEntry.AlternateId = latestEntryByAlternateID.AlternateId + 1;
                }
            }
            catch
            {

            }
            db.GifEntries.Add(gifEntry);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = gifEntry.ID }, gifEntry);
        }

        // DELETE: api/GifEntries/5
        [ResponseType(typeof(GifEntry))]
        public async Task<IHttpActionResult> DeleteGifEntry(GifEntry gifEntry)
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