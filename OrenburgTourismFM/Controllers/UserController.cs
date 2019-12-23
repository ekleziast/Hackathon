using OrenburgTourismFM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace OrenburgTourismFM.Controllers
{
    public class UserController : ApiController
    { 
        /// <summary>
        /// Метод позволяет зарегистрировать пользователя в системе
        /// </summary>
        /// <param name="account">Аккаунт для регистрации</param>
        /// <returns>Код состояния</returns>
        [HttpPost]
        public HttpStatusCode Registration ([FromBody]Account account)
        {
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

        /// <summary>
        /// Метод позволяет пользователю авторизоваться в системе
        /// </summary>
        /// <param name="email">Электронная почта</param>
        /// <param name="password">Пароль</param>
        /// <returns><see cref="Account"/>, если авторизация прошла успешно.
        /// Иначе - код ошибки</returns>
        [HttpGet]
        public IHttpActionResult Login([FromUri]string email, [FromUri]string password)
        {
            try
            {
                using (Context db = new Context())
                {
                    var account = db.Accounts.Where(o => o.Email == email && o.Password == password).FirstOrDefault();
                    if(account == null)
                    {
                        return NotFound();
                    }
                    return Ok(account);
                }
            }
            catch
            {
                return StatusCode(HttpStatusCode.BadGateway);
            }
        }
    }
}
