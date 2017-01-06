namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menupath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "ControllerName", c => c.String());
            AddColumn("dbo.Menus", "ActionName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "ActionName");
            DropColumn("dbo.Menus", "ControllerName");
        }
    }
}
