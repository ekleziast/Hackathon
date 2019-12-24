namespace OrenburgTourismFM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotoPlace : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "Photo", c => c.String());
            DropColumn("dbo.PlaceTypes", "NeedPremession");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlaceTypes", "NeedPremession", c => c.Boolean(nullable: false));
            DropColumn("dbo.Places", "Photo");
        }
    }
}
