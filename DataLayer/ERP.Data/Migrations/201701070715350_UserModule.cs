namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserModule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ModuleGroups", "Description", c => c.String());
            AddColumn("dbo.Modules", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Modules", "Description");
            DropColumn("dbo.ModuleGroups", "Description");
        }
    }
}
