namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modified_Module : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Modules", "User_UserID", "dbo.Users");
            DropIndex("dbo.Modules", new[] { "User_UserID" });
            CreateTable(
                "dbo.UserModules",
                c => new
                    {
                        User_UserID = c.Int(nullable: false),
                        Module_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserID, t.Module_Id })
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .ForeignKey("dbo.Modules", t => t.Module_Id, cascadeDelete: true)
                .Index(t => t.User_UserID)
                .Index(t => t.Module_Id);
            
            AddColumn("dbo.ModuleGroups", "Orderby", c => c.Int(nullable: false));
            DropColumn("dbo.ModuleGroups", "Order");
            DropColumn("dbo.Modules", "User_UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Modules", "User_UserID", c => c.Int());
            AddColumn("dbo.ModuleGroups", "Order", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserModules", "Module_Id", "dbo.Modules");
            DropForeignKey("dbo.UserModules", "User_UserID", "dbo.Users");
            DropIndex("dbo.UserModules", new[] { "Module_Id" });
            DropIndex("dbo.UserModules", new[] { "User_UserID" });
            DropColumn("dbo.ModuleGroups", "Orderby");
            DropTable("dbo.UserModules");
            CreateIndex("dbo.Modules", "User_UserID");
            AddForeignKey("dbo.Modules", "User_UserID", "dbo.Users", "UserID");
        }
    }
}
