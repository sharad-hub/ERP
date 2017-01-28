namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedcompositekeyforbuyerorderItem : DbMigration
    {
        public override void Up()
        {
            //DropPrimaryKey("dbo.BuyerOrderItems");
            //AlterColumn("dbo.BuyerOrderItems", "ProductSkuID", c => c.Int(nullable: false));
            //AddPrimaryKey("dbo.BuyerOrderItems", new[] { "BuyerOrderId", "ProductId", "ProductSkuID" });
        }
        
        public override void Down()
        {
            //DropPrimaryKey("dbo.BuyerOrderItems");
            //AlterColumn("dbo.BuyerOrderItems", "ProductSkuID", c => c.Int());
            //AddPrimaryKey("dbo.BuyerOrderItems", new[] { "BuyerOrderId", "ProductId" });
        }
    }
}
