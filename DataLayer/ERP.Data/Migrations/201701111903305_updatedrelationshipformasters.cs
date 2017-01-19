namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedrelationshipformasters : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ZoneMaster", "CountryId");
            CreateIndex("dbo.CityMaster", "StateId");
            CreateIndex("dbo.StateMaster", "ZoneId");
            AddForeignKey("dbo.ZoneMaster", "CountryId", "dbo.CountryMaster", "Id");
            AddForeignKey("dbo.StateMaster", "ZoneId", "dbo.ZoneMaster", "ZoneId");
            AddForeignKey("dbo.CityMaster", "StateId", "dbo.StateMaster", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CityMaster", "StateId", "dbo.StateMaster");
            DropForeignKey("dbo.StateMaster", "ZoneId", "dbo.ZoneMaster");
            DropForeignKey("dbo.ZoneMaster", "CountryId", "dbo.CountryMaster");
            DropIndex("dbo.StateMaster", new[] { "ZoneId" });
            DropIndex("dbo.CityMaster", new[] { "StateId" });
            DropIndex("dbo.ZoneMaster", new[] { "CountryId" });
        }
    }
}
