namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedBuyerAndFactory : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserModules1", newName: "ModuleUsers");
            DropPrimaryKey("dbo.ModuleUsers");
            AddColumn("dbo.BuyerMaster", "SuperUserId", c => c.Int(nullable: false));
            AddColumn("dbo.BuyerMaster", "CreatedByUserId", c => c.Int());
            AddColumn("dbo.FactoryMaster", "SuperUserId", c => c.Int(nullable: false));
            AddColumn("dbo.FactoryMaster", "CreatedByUserId", c => c.Int());
            AddColumn("dbo.FactoryMaster", "CreatedByUser_UserID", c => c.Int());
            AlterColumn("dbo.BuyerMaster", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.FactoryMaster", "CreatedDate", c => c.DateTime());
            AddPrimaryKey("dbo.ModuleUsers", new[] { "Module_Id", "User_UserID" });
            CreateIndex("dbo.BuyerMaster", "SuperUserId");
            CreateIndex("dbo.BuyerMaster", "CreatedByUserId");
            CreateIndex("dbo.FactoryMaster", "SuperUserId");
            CreateIndex("dbo.FactoryMaster", "CreatedByUser_UserID");
            AddForeignKey("dbo.BuyerMaster", "CreatedByUserId", "dbo.Users", "UserID");
            AddForeignKey("dbo.BuyerMaster", "SuperUserId", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.FactoryMaster", "CreatedByUser_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.FactoryMaster", "SuperUserId", "dbo.Users", "UserID", cascadeDelete: true);
            DropColumn("dbo.BuyerMaster", "SuperUserLoginId");
            DropColumn("dbo.BuyerMaster", "SuperUserLoginPassword");
            DropColumn("dbo.BuyerMaster", "CreatedBy");
            DropColumn("dbo.FactoryMaster", "SuperUserLoginId");
            DropColumn("dbo.FactoryMaster", "SuperUserLoginPassword");
            DropColumn("dbo.FactoryMaster", "CreatedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FactoryMaster", "CreatedBy", c => c.Int());
            AddColumn("dbo.FactoryMaster", "SuperUserLoginPassword", c => c.String(maxLength: 50));
            AddColumn("dbo.FactoryMaster", "SuperUserLoginId", c => c.String(maxLength: 50));
            AddColumn("dbo.BuyerMaster", "CreatedBy", c => c.Int());
            AddColumn("dbo.BuyerMaster", "SuperUserLoginPassword", c => c.String(maxLength: 50));
            AddColumn("dbo.BuyerMaster", "SuperUserLoginId", c => c.String(maxLength: 50));
            DropForeignKey("dbo.FactoryMaster", "SuperUserId", "dbo.Users");
            DropForeignKey("dbo.FactoryMaster", "CreatedByUser_UserID", "dbo.Users");
            DropForeignKey("dbo.BuyerMaster", "SuperUserId", "dbo.Users");
            DropForeignKey("dbo.BuyerMaster", "CreatedByUserId", "dbo.Users");
            DropIndex("dbo.FactoryMaster", new[] { "CreatedByUser_UserID" });
            DropIndex("dbo.FactoryMaster", new[] { "SuperUserId" });
            DropIndex("dbo.BuyerMaster", new[] { "CreatedByUserId" });
            DropIndex("dbo.BuyerMaster", new[] { "SuperUserId" });
            DropPrimaryKey("dbo.ModuleUsers");
            AlterColumn("dbo.FactoryMaster", "CreatedDate", c => c.Int());
            AlterColumn("dbo.BuyerMaster", "CreatedDate", c => c.Int());
            DropColumn("dbo.FactoryMaster", "CreatedByUser_UserID");
            DropColumn("dbo.FactoryMaster", "CreatedByUserId");
            DropColumn("dbo.FactoryMaster", "SuperUserId");
            DropColumn("dbo.BuyerMaster", "CreatedByUserId");
            DropColumn("dbo.BuyerMaster", "SuperUserId");
            AddPrimaryKey("dbo.ModuleUsers", new[] { "User_UserID", "Module_Id" });
            RenameTable(name: "dbo.ModuleUsers", newName: "UserModules1");
        }
    }
}
