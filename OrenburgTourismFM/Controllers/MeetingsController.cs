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
using OrenburgTourismFM;
using OrenburgTourismFM.Model;

namespace OrenburgTourismFM.Controllers
{
    public class MeetingsController : ApiController
    {
        private Context db = new Context();

        // GET: api/Meetings
        public IQueryable<Meeting> GetMeetings()
        {
            return db.Meetings;
        }

        // GET: api/Meetings/5
        [ResponseType(typeof(Meeting))]
        public async Task<IHttpActionResult> GetMeeting(Guid id)
        {
            Meeting meeting = await db.Meetings.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }

            return Ok(meeting);
        }

        // PUT: api/Meetings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMeeting(Guid id, Meeting meeting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != meeting.ID)
            {
                return BadRequest();
            }

            db.Entry(meeting).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetingExists(id))
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

        // POST: api/Meetings
        [ResponseType(typeof(Meeting))]
        public async Task<IHttpActionResult> PostMeeting(Meeting meeting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Meetings.Add(meeting);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = meeting.ID }, meeting);
        }

        // DELETE: api/Meetings/5
        [ResponseType(typeof(Meeting))]
        public async Task<IHttpActionResult> DeleteMeeting(Guid id)
        {
            Meeting meeting = await db.Meetings.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }

            db.Meetings.Remove(meeting);
            await db.SaveChangesAsync();

            return Ok(meeting);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MeetingExists(Guid id)
        {
            return db.Meetings.Count(e => e.ID == id) > 0;
        }
    }
}