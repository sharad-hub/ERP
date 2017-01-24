namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductIdentity_modified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BuyerOrderItems", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.ProductColors", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.ProductFactoryAllocations", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.ProductImages", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.ProductSKUs", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.ProductOpeningBalances", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.Schemes", "ProductId", "dbo.tblProducts");
            DropPrimaryKey("dbo.tblProducts");
            AlterColumn("dbo.tblProducts", "ProductID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.tblProducts", "ProductID");
            AddForeignKey("dbo.BuyerOrderItems", "ProductId", "dbo.tblProducts", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.ProductColors", "ProductId", "dbo.tblProducts", "ProductID");
            AddForeignKey("dbo.ProductFactoryAllocations", "ProductId", "dbo.tblProducts", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.ProductImages", "ProductId", "dbo.tblProducts", "ProductID");
            AddForeignKey("dbo.ProductSKUs", "ProductId", "dbo.tblProducts", "ProductID");
            AddForeignKey("dbo.ProductOpeningBalances", "ProductId", "dbo.tblProducts", "ProductID");
            AddForeignKey("dbo.Schemes", "ProductId", "dbo.tblProducts", "ProductID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schemes", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.ProductOpeningBalances", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.ProductSKUs", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.ProductImages", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.ProductFactoryAllocations", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.ProductColors", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.BuyerOrderItems", "ProductId", "dbo.tblProducts");
            DropPrimaryKey("dbo.tblProducts");
            AlterColumn("dbo.tblProducts", "ProductID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.tblProducts", "ProductID");
            AddForeignKey("dbo.Schemes", "ProductId", "dbo.tblProducts", "ProductID");
            AddForeignKey("dbo.ProductOpeningBalances", "ProductId", "dbo.tblProducts", "ProductID");
            AddForeignKey("dbo.ProductSKUs", "ProductId", "dbo.tblProducts", "ProductID");
            AddForeignKey("dbo.ProductImages", "ProductId", "dbo.tblProducts", "ProductID");
            AddForeignKey("dbo.ProductFactoryAllocations", "ProductId", "dbo.tblProducts", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.ProductColors", "ProductId", "dbo.tblProducts", "ProductID");
            AddForeignKey("dbo.BuyerOrderItems", "ProductId", "dbo.tblProducts", "ProductID", cascadeDelete: true);
        }
    }
}
