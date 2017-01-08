namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserModules : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserModules", newName: "UserModules1");
            CreateTable(
                "dbo.UserModules",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ModuleID = c.Int(nullable: false),
                        AccessTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AccessType", t => t.AccessTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Modules", t => t.ModuleID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.ModuleID)
                .Index(t => t.AccessTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserModules", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserModules", "ModuleID", "dbo.Modules");
            DropForeignKey("dbo.UserModules", "AccessTypeID", "dbo.AccessType");
            DropIndex("dbo.UserModules", new[] { "AccessTypeID" });
            DropIndex("dbo.UserModules", new[] { "ModuleID" });
            DropIndex("dbo.UserModules", new[] { "UserID" });
            DropTable("dbo.UserModules");
            RenameTable(name: "dbo.UserModules1", newName: "UserModules");
        }
    }
}
