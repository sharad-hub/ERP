namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SettingGropuAndSortName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SettingsGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SortDscription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Modules", "ModuleGroupName", c => c.String());
            AddColumn("dbo.Modules", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.UIStyles", "SortName", c => c.String());
            AddColumn("dbo.UrlContexts", "SortName", c => c.String());
            AddColumn("dbo.UserSettings", "SettingsGroupID", c => c.Int());
            CreateIndex("dbo.UserSettings", "SettingsGroupID");
            AddForeignKey("dbo.UserSettings", "SettingsGroupID", "dbo.SettingsGroups", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSettings", "SettingsGroupID", "dbo.SettingsGroups");
            DropIndex("dbo.UserSettings", new[] { "SettingsGroupID" });
            DropColumn("dbo.UserSettings", "SettingsGroupID");
            DropColumn("dbo.UrlContexts", "SortName");
            DropColumn("dbo.UIStyles", "SortName");
            DropColumn("dbo.Modules", "Discriminator");
            DropColumn("dbo.Modules", "ModuleGroupName");
            DropTable("dbo.SettingsGroups");
        }
    }
}
