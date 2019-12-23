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
        [ResponseType(typeof(List<Meeting>))]
        public async Task<IHttpActionResult> GetMeetings()
        {
            try
            {
                var uri = new Uri("https://www.2do2go.ru/oren/");
                return Ok();
            }
            catch
            {
                return StatusCode(HttpStatusCode.BadGateway);
            }
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