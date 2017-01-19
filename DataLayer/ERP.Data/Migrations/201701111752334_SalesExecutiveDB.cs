namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesExecutiveDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesExecutiveMaster", "SalesExecUserID", c => c.Int(nullable: false));
            CreateIndex("dbo.SalesExecutiveMaster", "SalesExecDesignationId");
            CreateIndex("dbo.SalesExecutiveMaster", "SalesExecUserID");
            AddForeignKey("dbo.SalesExecutiveMaster", "SalesExecDesignationId", "dbo.DesignationMaster", "Id");
            AddForeignKey("dbo.SalesExecutiveMaster", "SalesExecUserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesExecutiveMaster", "SalesExecUserID", "dbo.Users");
            DropForeignKey("dbo.SalesExecutiveMaster", "SalesExecDesignationId", "dbo.DesignationMaster");
            DropIndex("dbo.SalesExecutiveMaster", new[] { "SalesExecUserID" });
            DropIndex("dbo.SalesExecutiveMaster", new[] { "SalesExecDesignationId" });
            DropColumn("dbo.SalesExecutiveMaster", "SalesExecUserID");
        }
    }
}
