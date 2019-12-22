using System.Data.Entity;
using Database.Model;

namespace Database
{
    public class Context : DbContext
    {
        public Context() : base("DbConnection"){
            Database.CreateIfNotExists();
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Meeting> Meetings { get; set; }
    }
}