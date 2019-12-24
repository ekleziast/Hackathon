namespace OrenburgTourismFM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Meetings", "Place_Id", "dbo.Places");
            DropIndex("dbo.Meetings", new[] { "Place_Id" });
            RenameColumn(table: "dbo.Meetings", name: "Place_Id", newName: "PlaceID");
            RenameColumn(table: "dbo.Places", name: "PlaceType_Id", newName: "PlaceTypeID");
            RenameIndex(table: "dbo.Places", name: "IX_PlaceType_Id", newName: "IX_PlaceTypeID");
            AlterColumn("dbo.Meetings", "PlaceID", c => c.Int(nullable: false));
            CreateIndex("dbo.Meetings", "PlaceID");
            AddForeignKey("dbo.Meetings", "PlaceID", "dbo.Places", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meetings", "PlaceID", "dbo.Places");
            DropIndex("dbo.Meetings", new[] { "PlaceID" });
            AlterColumn("dbo.Meetings", "PlaceID", c => c.Int());
            RenameIndex(table: "dbo.Places", name: "IX_PlaceTypeID", newName: "IX_PlaceType_Id");
            RenameColumn(table: "dbo.Places", name: "PlaceTypeID", newName: "PlaceType_Id");
            RenameColumn(table: "dbo.Meetings", name: "PlaceID", newName: "Place_Id");
            CreateIndex("dbo.Meetings", "Place_Id");
            AddForeignKey("dbo.Meetings", "Place_Id", "dbo.Places", "Id");
        }
    }
}
