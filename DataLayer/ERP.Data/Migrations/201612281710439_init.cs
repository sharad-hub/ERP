namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 100),
                        status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanyWiseModule",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompId = c.Int(),
                        ModuleId = c.Int(),
                        ModuleName = c.String(maxLength: 50),
                        Orderby = c.Int(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        compId = c.Int(),
                        Designation = c.String(maxLength: 50),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FYear",
                c => new
                    {
                        CompId = c.Int(nullable: false),
                        FinYear = c.String(nullable: false, maxLength: 20),
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompId, t.FinYear });
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Gender = c.String(maxLength: 10),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Icons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IconName = c.String(maxLength: 100),
                        IconClass = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MaritalStatuses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompId = c.Int(),
                        MaritalStatus = c.String(maxLength: 20),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModuleId = c.Int(),
                        ParentId = c.Int(),
                        MenuCode = c.String(maxLength: 30),
                        MenuName = c.String(maxLength: 50),
                        ImageIndexNo = c.String(maxLength: 50),
                        FormName = c.String(maxLength: 100),
                        Orderby = c.Int(),
                        ItemImageURL = c.String(maxLength: 500),
                        Status = c.Boolean(),
                        IconID = c.Int(),
                        backgroundColor = c.String(maxLength: 50),
                        FontColor = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModuleKeyCode = c.String(maxLength: 50),
                        ModuleName = c.String(maxLength: 50),
                        ImageIndexNo = c.String(maxLength: 50),
                        Orderby = c.Int(),
                        Status = c.Boolean(),
                        BackgroundColor = c.String(maxLength: 50),
                        FontColor = c.String(maxLength: 50),
                        User_ID = c.Int(),
                        User_CompId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => new { t.User_ID, t.User_CompId })
                .Index(t => new { t.User_ID, t.User_CompId });
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompId = c.Int(),
                        Title = c.String(maxLength: 20),
                        Gender = c.String(maxLength: 50),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRights",
                c => new
                    {
                        AutoId = c.Long(nullable: false, identity: true),
                        MenuId = c.Int(nullable: false),
                        User = c.Int(nullable: false),
                        AccessTypeID = c.Int(),
                    })
                .PrimaryKey(t => new { t.AutoId, t.MenuId });
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompId = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(),
                        HashedPassword = c.String(),
                        Salt = c.String(),
                        IsLocked = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ID, t.CompId });
            
            CreateTable(
                "dbo.UserType",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        ID = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        User_ID = c.Int(),
                        User_CompId = c.Int(),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.Roles", t => t.ID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => new { t.User_ID, t.User_CompId })
                .Index(t => t.ID)
                .Index(t => new { t.User_ID, t.User_CompId });
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserType", new[] { "User_ID", "User_CompId" }, "dbo.Users");
            DropForeignKey("dbo.UserType", "ID", "dbo.Roles");
            DropForeignKey("dbo.Modules", new[] { "User_ID", "User_CompId" }, "dbo.Users");
            DropIndex("dbo.UserType", new[] { "User_ID", "User_CompId" });
            DropIndex("dbo.UserType", new[] { "ID" });
            DropIndex("dbo.Modules", new[] { "User_ID", "User_CompId" });
            DropTable("dbo.Roles");
            DropTable("dbo.UserType");
            DropTable("dbo.Users");
            DropTable("dbo.UserRights");
            DropTable("dbo.Titles");
            DropTable("dbo.States");
            DropTable("dbo.Modules");
            DropTable("dbo.Menus");
            DropTable("dbo.MaritalStatuses");
            DropTable("dbo.Icons");
            DropTable("dbo.Genders");
            DropTable("dbo.FYear");
            DropTable("dbo.Designations");
            DropTable("dbo.Countries");
            DropTable("dbo.CompanyWiseModule");
            DropTable("dbo.Cities");
            DropTable("dbo.AccessType");
        }
    }
}
