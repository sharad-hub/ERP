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
                "dbo.ERPObjectTypes",
                c => new
                    {
                        ERPObjectTypeID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ERPObjectTypeID);
            
            CreateTable(
                "dbo.ErrorLogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ErrorID = c.Int(nullable: false),
                        Errored = c.DateTime(nullable: false),
                        UserName = c.String(),
                        Details = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        UserId = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
                        ControllerName = c.String(),
                        ActionName = c.String(),
                        ModuleName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModuleGroups",
                c => new
                    {
                        ModuleGroupID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        UIStyle_UIStyleID = c.Int(),
                    })
                .PrimaryKey(t => t.ModuleGroupID)
                .ForeignKey("dbo.UIStyles", t => t.UIStyle_UIStyleID)
                .Index(t => t.UIStyle_UIStyleID);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModuleKeyCode = c.String(maxLength: 50),
                        ModuleName = c.String(maxLength: 50),
                        Orderby = c.Int(),
                        Active = c.Boolean(nullable: false),
                        Level = c.Int(nullable: false),
                        ParentModuleID = c.Int(),
                        UIStyle_UIStyleID = c.Int(),
                        UrlContext_UrlContextID = c.Int(),
                        ModuleGroup_ModuleGroupID = c.Int(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Modules", t => t.ParentModuleID)
                .ForeignKey("dbo.UIStyles", t => t.UIStyle_UIStyleID)
                .ForeignKey("dbo.UrlContexts", t => t.UrlContext_UrlContextID)
                .ForeignKey("dbo.ModuleGroups", t => t.ModuleGroup_ModuleGroupID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.ParentModuleID)
                .Index(t => t.UIStyle_UIStyleID)
                .Index(t => t.UrlContext_UrlContextID)
                .Index(t => t.ModuleGroup_ModuleGroupID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.UIStyles",
                c => new
                    {
                        UIStyleID = c.Int(nullable: false, identity: true),
                        CSSClass = c.String(),
                        FontIconClass = c.String(),
                        FontColor = c.String(),
                        BackgroundColor = c.String(),
                    })
                .PrimaryKey(t => t.UIStyleID);
            
            CreateTable(
                "dbo.UrlContexts",
                c => new
                    {
                        UrlContextID = c.Int(nullable: false, identity: true),
                        AreaName = c.String(),
                        ControllerName = c.String(),
                        ActionName = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UrlContextID);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        NotificationTypeID = c.Int(nullable: false),
                        TriggerTime = c.DateTime(nullable: false),
                        ExpiryTime = c.DateTime(nullable: false),
                        ObjectID = c.Int(nullable: false),
                        CreatedBy_UserID = c.Int(),
                        ERPObjectType_ERPObjectTypeID = c.Int(),
                        ForUser_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.NotificationID)
                .ForeignKey("dbo.Users", t => t.CreatedBy_UserID)
                .ForeignKey("dbo.ERPObjectTypes", t => t.ERPObjectType_ERPObjectTypeID)
                .ForeignKey("dbo.Users", t => t.ForUser_UserID)
                .ForeignKey("dbo.NotificationTypes", t => t.NotificationTypeID, cascadeDelete: true)
                .Index(t => t.NotificationTypeID)
                .Index(t => t.CreatedBy_UserID)
                .Index(t => t.ERPObjectType_ERPObjectTypeID)
                .Index(t => t.ForUser_UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(),
                        HashedPassword = c.String(),
                        Salt = c.String(),
                        IsLocked = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        CompId = c.Int(nullable: false),
                        ManagerID = c.Int(),
                        CreatedByUserID = c.Int(),
                        ZoneID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Users", t => t.ManagerID)
                .ForeignKey("dbo.Zones", t => t.ZoneID, cascadeDelete: true)
                .Index(t => t.ManagerID)
                .Index(t => t.ZoneID);
            
            CreateTable(
                "dbo.Zones",
                c => new
                    {
                        ZoneID = c.Int(nullable: false, identity: true),
                        ZoneCode = c.String(),
                        ZoneName = c.String(),
                    })
                .PrimaryKey(t => t.ZoneID);
            
            CreateTable(
                "dbo.NotificationTypes",
                c => new
                    {
                        NotificationTypeID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        TypeCode = c.String(),
                        DefaultText = c.String(),
                    })
                .PrimaryKey(t => t.NotificationTypeID);
            
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
                        AccessTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AutoId, t.MenuId })
                .ForeignKey("dbo.AccessType", t => t.AccessTypeID, cascadeDelete: true)
                .Index(t => t.AccessTypeID);
            
            CreateTable(
                "dbo.UserType",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        ID = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.Roles", t => t.ID, cascadeDelete: true)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        UrlContextID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UrlContexts", t => t.UrlContextID, cascadeDelete: true)
                .Index(t => t.UrlContextID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserType", "ID", "dbo.Roles");
            DropForeignKey("dbo.Roles", "UrlContextID", "dbo.UrlContexts");
            DropForeignKey("dbo.UserRights", "AccessTypeID", "dbo.AccessType");
            DropForeignKey("dbo.Notifications", "NotificationTypeID", "dbo.NotificationTypes");
            DropForeignKey("dbo.Notifications", "ForUser_UserID", "dbo.Users");
            DropForeignKey("dbo.Notifications", "ERPObjectType_ERPObjectTypeID", "dbo.ERPObjectTypes");
            DropForeignKey("dbo.Notifications", "CreatedBy_UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "ZoneID", "dbo.Zones");
            DropForeignKey("dbo.Modules", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "ManagerID", "dbo.Users");
            DropForeignKey("dbo.ModuleGroups", "UIStyle_UIStyleID", "dbo.UIStyles");
            DropForeignKey("dbo.Modules", "ModuleGroup_ModuleGroupID", "dbo.ModuleGroups");
            DropForeignKey("dbo.Modules", "UrlContext_UrlContextID", "dbo.UrlContexts");
            DropForeignKey("dbo.Modules", "UIStyle_UIStyleID", "dbo.UIStyles");
            DropForeignKey("dbo.Modules", "ParentModuleID", "dbo.Modules");
            DropIndex("dbo.Roles", new[] { "UrlContextID" });
            DropIndex("dbo.UserType", new[] { "ID" });
            DropIndex("dbo.UserRights", new[] { "AccessTypeID" });
            DropIndex("dbo.Users", new[] { "ZoneID" });
            DropIndex("dbo.Users", new[] { "ManagerID" });
            DropIndex("dbo.Notifications", new[] { "ForUser_UserID" });
            DropIndex("dbo.Notifications", new[] { "ERPObjectType_ERPObjectTypeID" });
            DropIndex("dbo.Notifications", new[] { "CreatedBy_UserID" });
            DropIndex("dbo.Notifications", new[] { "NotificationTypeID" });
            DropIndex("dbo.Modules", new[] { "User_UserID" });
            DropIndex("dbo.Modules", new[] { "ModuleGroup_ModuleGroupID" });
            DropIndex("dbo.Modules", new[] { "UrlContext_UrlContextID" });
            DropIndex("dbo.Modules", new[] { "UIStyle_UIStyleID" });
            DropIndex("dbo.Modules", new[] { "ParentModuleID" });
            DropIndex("dbo.ModuleGroups", new[] { "UIStyle_UIStyleID" });
            DropTable("dbo.Roles");
            DropTable("dbo.UserType");
            DropTable("dbo.UserRights");
            DropTable("dbo.Titles");
            DropTable("dbo.States");
            DropTable("dbo.NotificationTypes");
            DropTable("dbo.Zones");
            DropTable("dbo.Users");
            DropTable("dbo.Notifications");
            DropTable("dbo.UrlContexts");
            DropTable("dbo.UIStyles");
            DropTable("dbo.Modules");
            DropTable("dbo.ModuleGroups");
            DropTable("dbo.Menus");
            DropTable("dbo.MaritalStatuses");
            DropTable("dbo.Genders");
            DropTable("dbo.FYear");
            DropTable("dbo.Errors");
            DropTable("dbo.ErrorLogs");
            DropTable("dbo.ERPObjectTypes");
            DropTable("dbo.Designations");
            DropTable("dbo.Countries");
            DropTable("dbo.CompanyWiseModule");
            DropTable("dbo.Cities");
            DropTable("dbo.AccessType");
        }
    }
}
