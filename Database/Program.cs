using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Context db = new Context())
            {
                db.Accounts.ToList().ForEach(o => Console.WriteLine(o.Email));
            }
        }
    }
}
