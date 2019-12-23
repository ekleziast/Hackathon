namespace OrenburgTourismFM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Date_Meeting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meetings", "Date", c => c.String());
            AddColumn("dbo.Meetings", "Cost", c => c.String());
            AddColumn("dbo.Places", "Street", c => c.String());
            AddColumn("dbo.Places", "Latitude", c => c.String());
            AddColumn("dbo.Places", "Longitude", c => c.String());
            DropColumn("dbo.Meetings", "MeetingDate");
            DropColumn("dbo.Meetings", "Price");
            DropColumn("dbo.Places", "Width");
            DropColumn("dbo.Places", "Height");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Places", "Height", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Places", "Width", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Meetings", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Meetings", "MeetingDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Places", "Longitude");
            DropColumn("dbo.Places", "Latitude");
            DropColumn("dbo.Places", "Street");
            DropColumn("dbo.Meetings", "Cost");
            DropColumn("dbo.Meetings", "Date");
        }
    }
}
