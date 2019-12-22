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

        private Context context = new Context();
        [HttpPost]
        public void Registration ([FromBody]Account account)
        {

            try
            {

                context.Accounts.Add(account);
                context.SaveChanges();
            }
            catch
            {
            }
        }
    }
}
