namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedOrderStatusForeignKeyinBuyerOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BuyerOrders", "OrderStatusId", c => c.Int());
            CreateIndex("dbo.BuyerOrders", "OrderStatusId");
            AddForeignKey("dbo.BuyerOrders", "OrderStatusId", "dbo.OrderStatus", "ID");
            DropColumn("dbo.BuyerOrders", "BuyerOrderStatusId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BuyerOrders", "BuyerOrderStatusId", c => c.Int(nullable: false));
            DropForeignKey("dbo.BuyerOrders", "OrderStatusId", "dbo.OrderStatus");
            DropIndex("dbo.BuyerOrders", new[] { "OrderStatusId" });
            DropColumn("dbo.BuyerOrders", "OrderStatusId");
        }
    }
}
