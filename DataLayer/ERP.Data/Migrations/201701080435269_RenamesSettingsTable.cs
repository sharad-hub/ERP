namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamesSettingsTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserSettings", newName: "SystemSettingMaster");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.SystemSettingMaster", newName: "UserSettings");
        }
    }
}
