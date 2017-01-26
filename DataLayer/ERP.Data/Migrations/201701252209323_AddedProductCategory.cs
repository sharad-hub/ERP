namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProductCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductCategoryName = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.tblProducts", "ProductCategoryID", c => c.Int());
            CreateIndex("dbo.tblProducts", "ProductCategoryID");
            AddForeignKey("dbo.tblProducts", "ProductCategoryID", "dbo.ProductCategories", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblProducts", "ProductCategoryID", "dbo.ProductCategories");
            DropIndex("dbo.tblProducts", new[] { "ProductCategoryID" });
            DropColumn("dbo.tblProducts", "ProductCategoryID");
            DropTable("dbo.ProductCategories");
        }
    }
}
