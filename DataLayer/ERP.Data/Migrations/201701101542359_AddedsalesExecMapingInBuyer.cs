namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedsalesExecMapingInBuyer : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.BuyerMaster", "SalesExecId");
            AddForeignKey("dbo.BuyerMaster", "SalesExecId", "dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BuyerMaster", "SalesExecId", "dbo.Users");
            DropIndex("dbo.BuyerMaster", new[] { "SalesExecId" });
        }
    }
}
