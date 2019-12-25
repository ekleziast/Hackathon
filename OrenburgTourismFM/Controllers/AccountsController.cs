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
    public class AccountsController : ApiController
    {
        private Context db = new Context();

        // POST: api/Accounts
        [ResponseType(typeof(Account))]
        public async Task<IHttpActionResult> PostAccount(Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Accounts.Add(account);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = account.ID }, account);
        }

        // GET: api/Accounts
        [ResponseType(typeof(Account))]
        public async Task<IHttpActionResult> GetAccount(string email, string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account = await db.Accounts.Where(o => o.Email == email && o.Password == password).FirstOrDefaultAsync();
            if(account != null)
            {
                return CreatedAtRoute("DefaultApi", new { id = account.ID }, account);
            }
            else
            {
                return NotFound();
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

        private bool AccountExists(Guid id)
        {
            return db.Accounts.Count(e => e.ID == id) > 0;
        }
    }
}