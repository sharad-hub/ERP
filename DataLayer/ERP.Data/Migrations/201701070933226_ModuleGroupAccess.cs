namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModuleGroupAccess : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModuleGroupAccesses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ModuleGroupID = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ModuleGroups", t => t.ModuleGroupID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.ModuleGroupID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ModuleGroupAccesses", "UserID", "dbo.Users");
            DropForeignKey("dbo.ModuleGroupAccesses", "ModuleGroupID", "dbo.ModuleGroups");
            DropIndex("dbo.ModuleGroupAccesses", new[] { "ModuleGroupID" });
            DropIndex("dbo.ModuleGroupAccesses", new[] { "UserID" });
            DropTable("dbo.ModuleGroupAccesses");
        }
    }
}
