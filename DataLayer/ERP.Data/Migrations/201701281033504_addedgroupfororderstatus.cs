namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedgroupfororderstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderStatus", "GroupName", c => c.String());
            //DropColumn("dbo.BuyerOrderItems", "BuyerOrderNo");
        }
        
        public override void Down()
        {
           // AddColumn("dbo.BuyerOrderItems", "BuyerOrderNo", c => c.String());
            DropColumn("dbo.OrderStatus", "GroupName");
        }
    }
}
