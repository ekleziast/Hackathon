using Database;
using Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace OrenburgTourismFM.Controllers
{
    public class UserController : ApiController
    { 
        [HttpPost]
        public HttpStatusCode Registration ([FromBody]Account account)
        {
            if (!CheckRegistration(account))
            {
                return HttpStatusCode.BadRequest;
            }
            try
            {
                using (Context db = new Context())
                {
                    db.Accounts.Add(account);
                    db.SaveChanges();
                }
            }
            catch
            {
                return HttpStatusCode.BadGateway;
            }
            return HttpStatusCode.OK;
        }
        private static bool CheckRegistration(Account account)
        {
            try
            {
                var email = new System.Net.Mail.MailAddress(account.Email);
                if(email.Address != account.Email)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            if (String.IsNullOrWhiteSpace(account.Password))
            {
                return false;
            }
            if (String.IsNullOrWhiteSpace(account.FirstName))
            {
                return false;
            }
            if (String.IsNullOrWhiteSpace(account.MiddleName))
            {
                return false;
            }
            if (String.IsNullOrWhiteSpace(account.LastName))
            {
                return false;
            }

            return true;
        }

        [HttpPost]
        public Account Login([FromUri]string email, [FromUri]string password)
        {
            try
            {
                using (Context db = new Context())
                {
                    var account = db.Accounts.Where(o => o.Email == email && o.Password == password).FirstOrDefault();
                    if(account == null)
                    {
                        throw new HttpResponseException(HttpStatusCode.Forbidden);
                    }
                    return account;
                }
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.BadGateway);
            }
        }
    }
}
