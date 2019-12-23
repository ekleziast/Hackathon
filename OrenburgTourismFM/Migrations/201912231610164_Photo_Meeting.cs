namespace OrenburgTourismFM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Photo_Meeting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meetings", "PhotoSource", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meetings", "PhotoSource");
        }
    }
}
