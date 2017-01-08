namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRoleProvider : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserSettings", "UserID", "dbo.Users");
            DropIndex("dbo.UserSettings", new[] { "UserID" });
            CreateTable(
                "dbo.RolesProviders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        UserID = c.Int(),
                        UserRoleID = c.Int(),
                        CanProvideRoleID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Roles", t => t.CanProvideRoleID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .ForeignKey("dbo.Roles", t => t.UserRoleID)
                .Index(t => t.UserID)
                .Index(t => t.UserRoleID)
                .Index(t => t.CanProvideRoleID);
            
            CreateTable(
                "dbo.RoleGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.UserSettings", "RoleID", c => c.Int());
            AddColumn("dbo.Roles", "RoleGroupID", c => c.Int());
            AlterColumn("dbo.UserSettings", "UserID", c => c.Int());
            AlterColumn("dbo.UserSettings", "Key", c => c.String(maxLength: 50));
            CreateIndex("dbo.Roles", "RoleGroupID");
            CreateIndex("dbo.UserSettings", "UserID");
            CreateIndex("dbo.UserSettings", "RoleID");
            AddForeignKey("dbo.Roles", "RoleGroupID", "dbo.RoleGroups", "ID");
            AddForeignKey("dbo.UserSettings", "RoleID", "dbo.Roles", "ID");
            AddForeignKey("dbo.UserSettings", "UserID", "dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSettings", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserSettings", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.RolesProviders", "UserRoleID", "dbo.Roles");
            DropForeignKey("dbo.RolesProviders", "UserID", "dbo.Users");
            DropForeignKey("dbo.RolesProviders", "CanProvideRoleID", "dbo.Roles");
            DropForeignKey("dbo.Roles", "RoleGroupID", "dbo.RoleGroups");
            DropIndex("dbo.UserSettings", new[] { "RoleID" });
            DropIndex("dbo.UserSettings", new[] { "UserID" });
            DropIndex("dbo.Roles", new[] { "RoleGroupID" });
            DropIndex("dbo.RolesProviders", new[] { "CanProvideRoleID" });
            DropIndex("dbo.RolesProviders", new[] { "UserRoleID" });
            DropIndex("dbo.RolesProviders", new[] { "UserID" });
            AlterColumn("dbo.UserSettings", "Key", c => c.String());
            AlterColumn("dbo.UserSettings", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.Roles", "RoleGroupID");
            DropColumn("dbo.UserSettings", "RoleID");
            DropTable("dbo.RoleGroups");
            DropTable("dbo.RolesProviders");
            CreateIndex("dbo.UserSettings", "UserID");
            AddForeignKey("dbo.UserSettings", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
    }
}
