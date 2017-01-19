namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTypeCodeprop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccessType", "TypeCode", c => c.String());
            AddColumn("dbo.ModuleGroups", "TypeCode", c => c.String());
            AddColumn("dbo.RoleGroups", "TypeCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoleGroups", "TypeCode");
            DropColumn("dbo.ModuleGroups", "TypeCode");
            DropColumn("dbo.AccessType", "TypeCode");
        }
    }
}
