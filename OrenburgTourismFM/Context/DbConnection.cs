namespace OrenburgTourismFM
{
    using OrenburgTourismFM.Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Context : DbContext
    {
        // Контекст настроен для использования строки подключения "DbConnection" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "OrenburgTourismFM.Context.DbConnection" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "DbConnection" 
        // в файле конфигурации приложения.
        public Context()
            : base("name=DbConnection")
        {
        }


        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Meeting> Meetings { get; set; }

        public System.Data.Entity.DbSet<OrenburgTourismFM.Models.Place> Places { get; set; }
    }
    
}