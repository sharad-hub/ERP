namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uom_code : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UnitOfMaterials", newName: "UnitOfMeasurements");
            AddColumn("dbo.UnitOfMeasurements", "UOMCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UnitOfMeasurements", "UOMCode");
            RenameTable(name: "dbo.UnitOfMeasurements", newName: "UnitOfMaterials");
        }
    }
}
