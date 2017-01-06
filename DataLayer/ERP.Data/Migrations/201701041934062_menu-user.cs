namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menuuser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Modules", new[] { "User_ID", "User_CompId" }, "dbo.Users");
            DropIndex("dbo.Modules", new[] { "User_ID", "User_CompId" });
            AddColumn("dbo.Menus", "User_ID", c => c.Int());
            AddColumn("dbo.Menus", "User_CompId", c => c.Int());
            CreateIndex("dbo.Menus", new[] { "User_ID", "User_CompId" });
            AddForeignKey("dbo.Menus", new[] { "User_ID", "User_CompId" }, "dbo.Users", new[] { "ID", "CompId" });
            DropColumn("dbo.Modules", "User_ID");
            DropColumn("dbo.Modules", "User_CompId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Modules", "User_CompId", c => c.Int());
            AddColumn("dbo.Modules", "User_ID", c => c.Int());
            DropForeignKey("dbo.Menus", new[] { "User_ID", "User_CompId" }, "dbo.Users");
            DropIndex("dbo.Menus", new[] { "User_ID", "User_CompId" });
            DropColumn("dbo.Menus", "User_CompId");
            DropColumn("dbo.Menus", "User_ID");
            CreateIndex("dbo.Modules", new[] { "User_ID", "User_CompId" });
            AddForeignKey("dbo.Modules", new[] { "User_ID", "User_CompId" }, "dbo.Users", new[] { "ID", "CompId" });
        }
    }
}
