namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productSkuKeymodified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductSKUs", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.ProductImages", "ProductSKUsId", "dbo.ProductSKUs");
            DropForeignKey("dbo.ProductOpeningBalances", "ProductSKUsId", "dbo.ProductSKUs");
            DropIndex("dbo.ProductImages", new[] { "ProductSKUsId" });
            DropIndex("dbo.ProductSKUs", new[] { "ProductId" });
            DropIndex("dbo.ProductOpeningBalances", new[] { "ProductSKUsId" });
           // DropPrimaryKey("dbo.BuyerOrderItems");
            DropPrimaryKey("dbo.ProductSKUs");
            //AlterColumn("dbo.BuyerOrderItems", "ProductSkuID", c => c.Long(nullable: false));
            AlterColumn("dbo.ProductImages", "ProductSKUsId", c => c.Long(nullable: false));
            AlterColumn("dbo.ProductSKUs", "ID", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.ProductSKUs", "ProductId", c => c.Long(nullable: false));
            AlterColumn("dbo.ProductOpeningBalances", "ProductSKUsId", c => c.Long(nullable: false));
           // AddPrimaryKey("dbo.BuyerOrderItems", new[] { "BuyerOrderId", "ProductId", "ProductSkuID" });
            AddPrimaryKey("dbo.ProductSKUs", "ID");
            CreateIndex("dbo.ProductImages", "ProductSKUsId");
            CreateIndex("dbo.ProductSKUs", "ProductId");
            CreateIndex("dbo.ProductOpeningBalances", "ProductSKUsId");
            AddForeignKey("dbo.ProductSKUs", "ProductId", "dbo.tblProducts", "ProductID", cascadeDelete: false);
            AddForeignKey("dbo.ProductImages", "ProductSKUsId", "dbo.ProductSKUs", "ID", cascadeDelete: false);
            AddForeignKey("dbo.ProductOpeningBalances", "ProductSKUsId", "dbo.ProductSKUs", "ID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductOpeningBalances", "ProductSKUsId", "dbo.ProductSKUs");
            DropForeignKey("dbo.ProductImages", "ProductSKUsId", "dbo.ProductSKUs");
            DropForeignKey("dbo.ProductSKUs", "ProductId", "dbo.tblProducts");
            DropIndex("dbo.ProductOpeningBalances", new[] { "ProductSKUsId" });
            DropIndex("dbo.ProductSKUs", new[] { "ProductId" });
            DropIndex("dbo.ProductImages", new[] { "ProductSKUsId" });
            DropPrimaryKey("dbo.ProductSKUs");
            DropPrimaryKey("dbo.BuyerOrderItems");
            AlterColumn("dbo.ProductOpeningBalances", "ProductSKUsId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductSKUs", "ProductId", c => c.Long());
            AlterColumn("dbo.ProductSKUs", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ProductImages", "ProductSKUsId", c => c.Int(nullable: false));
            AlterColumn("dbo.BuyerOrderItems", "ProductSkuID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProductSKUs", "ID");
            AddPrimaryKey("dbo.BuyerOrderItems", new[] { "BuyerOrderId", "ProductId", "ProductSkuID" });
            CreateIndex("dbo.ProductOpeningBalances", "ProductSKUsId");
            CreateIndex("dbo.ProductSKUs", "ProductId");
            CreateIndex("dbo.ProductImages", "ProductSKUsId");
            AddForeignKey("dbo.ProductOpeningBalances", "ProductSKUsId", "dbo.ProductSKUs", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ProductImages", "ProductSKUsId", "dbo.ProductSKUs", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ProductSKUs", "ProductId", "dbo.tblProducts", "ProductID");
        }
    }
}
