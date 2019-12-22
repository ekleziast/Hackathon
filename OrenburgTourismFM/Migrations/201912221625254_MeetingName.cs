namespace OrenburgTourismFM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MeetingName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meetings", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meetings", "Name");
        }
    }
}
