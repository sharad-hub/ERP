namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedrestrictionFromUsers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "ZoneID", "dbo.Zones");
            DropIndex("dbo.Users", new[] { "ZoneID" });
            AlterColumn("dbo.Users", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.Users", "ZoneID", c => c.Int());
            CreateIndex("dbo.Users", "ZoneID");
            AddForeignKey("dbo.Users", "ZoneID", "dbo.Zones", "ZoneID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "ZoneID", "dbo.Zones");
            DropIndex("dbo.Users", new[] { "ZoneID" });
            AlterColumn("dbo.Users", "ZoneID", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "DateCreated", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Users", "ZoneID");
            AddForeignKey("dbo.Users", "ZoneID", "dbo.Zones", "ZoneID", cascadeDelete: true);
        }
    }
}
