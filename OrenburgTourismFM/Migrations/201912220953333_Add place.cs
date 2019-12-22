namespace OrenburgTourismFM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addplace : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Meetings", "AccountID", "dbo.Account");
            DropIndex("dbo.Meetings", new[] { "AccountID" });
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Width = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PlaceType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlaceTypes", t => t.PlaceType_Id)
                .Index(t => t.PlaceType_Id);
            
            CreateTable(
                "dbo.PlaceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NeedPremession = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Account", "Meeting_ID", c => c.Guid());
            AddColumn("dbo.Meetings", "MeetingDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Meetings", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Meetings", "Place_Id", c => c.Int());
            CreateIndex("dbo.Account", "Meeting_ID");
            CreateIndex("dbo.Meetings", "Place_Id");
            AddForeignKey("dbo.Account", "Meeting_ID", "dbo.Meetings", "ID");
            AddForeignKey("dbo.Meetings", "Place_Id", "dbo.Places", "Id");
            DropColumn("dbo.Meetings", "AccountID");
            DropColumn("dbo.Meetings", "Name");
            DropColumn("dbo.Meetings", "Street");
            DropColumn("dbo.Meetings", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meetings", "DateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Meetings", "Street", c => c.String());
            AddColumn("dbo.Meetings", "Name", c => c.String());
            AddColumn("dbo.Meetings", "AccountID", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Places", "PlaceType_Id", "dbo.PlaceTypes");
            DropForeignKey("dbo.Meetings", "Place_Id", "dbo.Places");
            DropForeignKey("dbo.Account", "Meeting_ID", "dbo.Meetings");
            DropIndex("dbo.Places", new[] { "PlaceType_Id" });
            DropIndex("dbo.Meetings", new[] { "Place_Id" });
            DropIndex("dbo.Account", new[] { "Meeting_ID" });
            DropColumn("dbo.Meetings", "Place_Id");
            DropColumn("dbo.Meetings", "Price");
            DropColumn("dbo.Meetings", "MeetingDate");
            DropColumn("dbo.Account", "Meeting_ID");
            DropTable("dbo.PlaceTypes");
            DropTable("dbo.Places");
            CreateIndex("dbo.Meetings", "AccountID");
            AddForeignKey("dbo.Meetings", "AccountID", "dbo.Account", "ID", cascadeDelete: true);
        }
    }
}
