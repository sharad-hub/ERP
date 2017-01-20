namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class buyerorder : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.FactoryMaster");
            CreateTable(
                "dbo.BuyerOrderItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BuyerOrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ProductName = c.String(),
                        UnitId = c.Int(nullable: false),
                        UnitPrice = c.Int(nullable: false),
                        MRP = c.Int(nullable: false),
                        Quintity = c.Int(nullable: false),
                        SchemeId = c.Int(nullable: false),
                        SchemeFreeQty = c.Int(nullable: false),
                        TotalOrderQty = c.Int(nullable: false),
                        TotalOrderAmt = c.Int(nullable: false),
                        TotalSchemeFreeAmt = c.Int(nullable: false),
                        DiscPercentage = c.Int(nullable: false),
                        DiscAmount = c.Int(nullable: false),
                        SalesTaxAmount = c.Int(nullable: false),
                        TaxPercentage = c.Int(nullable: false),
                        TotalOrderCost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BuyerOrders", t => t.BuyerOrderId, cascadeDelete: true)
                .ForeignKey("dbo.tblProducts", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.BuyerOrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.BuyerOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BuyerID = c.Long(nullable: false),
                        FinYearId = c.Int(nullable: false),
                        BuyerOrderNo = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        BuyerOrderStatusId = c.Int(nullable: false),
                        BuyerOrderTrackerStatusId = c.Int(nullable: false),
                        Remarks = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        LastmodifiedDate = c.DateTime(nullable: false),
                        LastModifiedById = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BuyerMaster", t => t.BuyerID, cascadeDelete: true)
                .ForeignKey("dbo.FinYears", t => t.FinYearId, cascadeDelete: true)
                .Index(t => t.BuyerID)
                .Index(t => t.FinYearId);
            
            CreateTable(
                "dbo.FinYears",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FinYearName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ColorCode = c.String(nullable: false),
                        HexadecimalCode = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Godowns",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GodownName = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductSubGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductGroupId = c.Int(),
                        ProductSubGroupName = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductGroups", t => t.ProductGroupId)
                .Index(t => t.ProductGroupId);
            
            CreateTable(
                "dbo.ProductGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductGroupName = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                        PrefixCode = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tariffs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TariffCode = c.String(nullable: false, maxLength: 10),
                        TariffName = c.String(maxLength: 50),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UnitOfMaterials",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UOM = c.String(nullable: false, maxLength: 50),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ImageTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TypeCode = c.String(nullable: false),
                        TypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductColors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(),
                        ColorId = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Colors", t => t.ColorId, cascadeDelete: true)
                .ForeignKey("dbo.tblProducts", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.ColorId);
            
            CreateTable(
                "dbo.ProductFactoryAllocations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        FactoryId = c.Int(nullable: false),
                        CapacityInDays = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FactoryMaster", t => t.FactoryId, cascadeDelete: true)
                .ForeignKey("dbo.tblProducts", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.FactoryId);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderNumber = c.Int(nullable: false),
                        ImageTypeId = c.Int(nullable: false),
                        ProductId = c.Int(),
                        ProductSKUsId = c.Int(nullable: false),
                        ProductImagePath = c.String(),
                        ImageByte = c.Binary(),
                        ImageDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ImageTypes", t => t.ImageTypeId, cascadeDelete: true)
                .ForeignKey("dbo.tblProducts", t => t.ProductId)
                .ForeignKey("dbo.ProductSKUs", t => t.ProductSKUsId, cascadeDelete: true)
                .Index(t => t.ImageTypeId)
                .Index(t => t.ProductId)
                .Index(t => t.ProductSKUsId);
            
            CreateTable(
                "dbo.ProductSKUs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(),
                        SKUSize = c.String(),
                        MRP = c.Single(nullable: false),
                        UnitPrice = c.Single(nullable: false),
                        BasicPrice = c.Single(nullable: false),
                        ProductGrossWeight = c.Single(nullable: false),
                        ProductNetWeight = c.Single(nullable: false),
                        ReOrderLevel = c.Single(nullable: false),
                        MinimumStockLevel = c.Single(nullable: false),
                        MaximumStockLevel = c.Single(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblProducts", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductOpeningBalances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BatchNoFlag = c.Boolean(nullable: false),
                        PartNoFlag = c.Boolean(nullable: false),
                        ExpiryDateFlag = c.Boolean(nullable: false),
                        OpeningQty = c.Single(nullable: false),
                        OpeningValue = c.Single(nullable: false),
                        GodownId = c.Int(nullable: false),
                        ProductId = c.Int(),
                        ProductSKUsId = c.Int(nullable: false),
                        FactoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FactoryMaster", t => t.FactoryId, cascadeDelete: true)
                .ForeignKey("dbo.Godowns", t => t.GodownId, cascadeDelete: true)
                .ForeignKey("dbo.tblProducts", t => t.ProductId)
                .ForeignKey("dbo.ProductSKUs", t => t.ProductSKUsId, cascadeDelete: true)
                .Index(t => t.GodownId)
                .Index(t => t.ProductId)
                .Index(t => t.ProductSKUsId)
                .Index(t => t.FactoryId);
            
            AddColumn("dbo.BuyerMaster", "EmailId", c => c.String());
            AddColumn("dbo.tblProducts", "ProductCode", c => c.String(nullable: false));
            AddColumn("dbo.tblProducts", "ProductSubGroupId", c => c.Int(nullable: false));
            AddColumn("dbo.tblProducts", "ProductTypeId", c => c.Int());
            AddColumn("dbo.tblProducts", "UOMMainId", c => c.Int(nullable: false));
            AddColumn("dbo.tblProducts", "ColorId", c => c.Int(nullable: false));
            AddColumn("dbo.tblProducts", "TariffCodeId", c => c.Int(nullable: false));
            AddColumn("dbo.tblProducts", "GodownId", c => c.Int(nullable: false));
            AddColumn("dbo.tblProducts", "ProductDescription", c => c.String());
            AddColumn("dbo.tblProducts", "Packing", c => c.Int(nullable: false));
            AddColumn("dbo.tblProducts", "MRP", c => c.Single(nullable: false));
            AddColumn("dbo.tblProducts", "AbatmentPercentage", c => c.Single(nullable: false));
            AddColumn("dbo.tblProducts", "UnitPrice", c => c.Single(nullable: false));
            AddColumn("dbo.tblProducts", "BasicPrice", c => c.Single(nullable: false));
            AddColumn("dbo.tblProducts", "BrandName", c => c.String());
            AddColumn("dbo.tblProducts", "Size", c => c.String());
            AddColumn("dbo.tblProducts", "ProductGrossWeight", c => c.Single(nullable: false));
            AddColumn("dbo.tblProducts", "ProductNetWeight", c => c.Single(nullable: false));
            AddColumn("dbo.tblProducts", "MinimumStockLevel", c => c.Single(nullable: false));
            AddColumn("dbo.tblProducts", "MaximumStockLevel", c => c.Single(nullable: false));
            AddColumn("dbo.tblProducts", "TaxableFlag", c => c.Boolean(nullable: false));
            AddColumn("dbo.tblProducts", "TaxPercentage", c => c.Single(nullable: false));
            AddColumn("dbo.tblProducts", "ExciseableFlag", c => c.Boolean(nullable: false));
            AddColumn("dbo.tblProducts", "ExcisePerc", c => c.Single(nullable: false));
            AddColumn("dbo.tblProducts", "PartNoFlag", c => c.Boolean(nullable: false));
            AddColumn("dbo.tblProducts", "BatchNoFlag", c => c.Boolean(nullable: false));
            AddColumn("dbo.tblProducts", "ExpiryDateFlag", c => c.Boolean(nullable: false));
            AddColumn("dbo.tblProducts", "FactoryFlag", c => c.Boolean(nullable: false));
            AddColumn("dbo.tblProducts", "ReOrderLevel", c => c.Single(nullable: false));
            AddColumn("dbo.tblProducts", "OpeningQty", c => c.Int(nullable: false));
            AddColumn("dbo.tblProducts", "OpeningValue", c => c.Int(nullable: false));
            AddColumn("dbo.tblProducts", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.tblProducts", "IsMultipleSKUs", c => c.Boolean(nullable: false));
            AddColumn("dbo.tblProducts", "IsMultipleColors", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Modules", "ModuleName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.FactoryMaster", "FactoryId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.FactoryMaster", "FactoryName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.FactoryMaster", "FactoryCityId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.FactoryMaster", "FactoryId");
            CreateIndex("dbo.tblProducts", "ProductSubGroupId");
            CreateIndex("dbo.tblProducts", "ProductTypeId");
            CreateIndex("dbo.tblProducts", "UOMMainId");
            CreateIndex("dbo.tblProducts", "ColorId");
            CreateIndex("dbo.tblProducts", "TariffCodeId");
            CreateIndex("dbo.tblProducts", "GodownId");
            AddForeignKey("dbo.tblProducts", "ColorId", "dbo.Colors", "ID", cascadeDelete: true);
            AddForeignKey("dbo.tblProducts", "GodownId", "dbo.Godowns", "ID", cascadeDelete: true);
            AddForeignKey("dbo.tblProducts", "ProductSubGroupId", "dbo.ProductSubGroups", "ID", cascadeDelete: true);
            AddForeignKey("dbo.tblProducts", "ProductTypeId", "dbo.ProductTypes", "ID");
            AddForeignKey("dbo.tblProducts", "TariffCodeId", "dbo.Tariffs", "ID", cascadeDelete: true);
            AddForeignKey("dbo.tblProducts", "UOMMainId", "dbo.UnitOfMaterials", "ID", cascadeDelete: true);
            DropColumn("dbo.tblProducts", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblProducts", "Type", c => c.String(maxLength: 50));
            DropForeignKey("dbo.ProductOpeningBalances", "ProductSKUsId", "dbo.ProductSKUs");
            DropForeignKey("dbo.ProductOpeningBalances", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.ProductOpeningBalances", "GodownId", "dbo.Godowns");
            DropForeignKey("dbo.ProductOpeningBalances", "FactoryId", "dbo.FactoryMaster");
            DropForeignKey("dbo.ProductImages", "ProductSKUsId", "dbo.ProductSKUs");
            DropForeignKey("dbo.ProductSKUs", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.ProductImages", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.ProductImages", "ImageTypeId", "dbo.ImageTypes");
            DropForeignKey("dbo.ProductFactoryAllocations", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.ProductFactoryAllocations", "FactoryId", "dbo.FactoryMaster");
            DropForeignKey("dbo.ProductColors", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.ProductColors", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.BuyerOrderItems", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.tblProducts", "UOMMainId", "dbo.UnitOfMaterials");
            DropForeignKey("dbo.tblProducts", "TariffCodeId", "dbo.Tariffs");
            DropForeignKey("dbo.tblProducts", "ProductTypeId", "dbo.ProductTypes");
            DropForeignKey("dbo.tblProducts", "ProductSubGroupId", "dbo.ProductSubGroups");
            DropForeignKey("dbo.ProductSubGroups", "ProductGroupId", "dbo.ProductGroups");
            DropForeignKey("dbo.tblProducts", "GodownId", "dbo.Godowns");
            DropForeignKey("dbo.tblProducts", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.BuyerOrderItems", "BuyerOrderId", "dbo.BuyerOrders");
            DropForeignKey("dbo.BuyerOrders", "FinYearId", "dbo.FinYears");
            DropForeignKey("dbo.BuyerOrders", "BuyerID", "dbo.BuyerMaster");
            DropIndex("dbo.ProductOpeningBalances", new[] { "FactoryId" });
            DropIndex("dbo.ProductOpeningBalances", new[] { "ProductSKUsId" });
            DropIndex("dbo.ProductOpeningBalances", new[] { "ProductId" });
            DropIndex("dbo.ProductOpeningBalances", new[] { "GodownId" });
            DropIndex("dbo.ProductSKUs", new[] { "ProductId" });
            DropIndex("dbo.ProductImages", new[] { "ProductSKUsId" });
            DropIndex("dbo.ProductImages", new[] { "ProductId" });
            DropIndex("dbo.ProductImages", new[] { "ImageTypeId" });
            DropIndex("dbo.ProductFactoryAllocations", new[] { "FactoryId" });
            DropIndex("dbo.ProductFactoryAllocations", new[] { "ProductId" });
            DropIndex("dbo.ProductColors", new[] { "ColorId" });
            DropIndex("dbo.ProductColors", new[] { "ProductId" });
            DropIndex("dbo.ProductSubGroups", new[] { "ProductGroupId" });
            DropIndex("dbo.tblProducts", new[] { "GodownId" });
            DropIndex("dbo.tblProducts", new[] { "TariffCodeId" });
            DropIndex("dbo.tblProducts", new[] { "ColorId" });
            DropIndex("dbo.tblProducts", new[] { "UOMMainId" });
            DropIndex("dbo.tblProducts", new[] { "ProductTypeId" });
            DropIndex("dbo.tblProducts", new[] { "ProductSubGroupId" });
            DropIndex("dbo.BuyerOrders", new[] { "FinYearId" });
            DropIndex("dbo.BuyerOrders", new[] { "BuyerID" });
            DropIndex("dbo.BuyerOrderItems", new[] { "ProductId" });
            DropIndex("dbo.BuyerOrderItems", new[] { "BuyerOrderId" });
            DropPrimaryKey("dbo.FactoryMaster");
            AlterColumn("dbo.FactoryMaster", "FactoryCityId", c => c.Int());
            AlterColumn("dbo.FactoryMaster", "FactoryName", c => c.String(maxLength: 50));
            AlterColumn("dbo.FactoryMaster", "FactoryId", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Modules", "ModuleName", c => c.String(maxLength: 50));
            DropColumn("dbo.tblProducts", "IsMultipleColors");
            DropColumn("dbo.tblProducts", "IsMultipleSKUs");
            DropColumn("dbo.tblProducts", "Status");
            DropColumn("dbo.tblProducts", "OpeningValue");
            DropColumn("dbo.tblProducts", "OpeningQty");
            DropColumn("dbo.tblProducts", "ReOrderLevel");
            DropColumn("dbo.tblProducts", "FactoryFlag");
            DropColumn("dbo.tblProducts", "ExpiryDateFlag");
            DropColumn("dbo.tblProducts", "BatchNoFlag");
            DropColumn("dbo.tblProducts", "PartNoFlag");
            DropColumn("dbo.tblProducts", "ExcisePerc");
            DropColumn("dbo.tblProducts", "ExciseableFlag");
            DropColumn("dbo.tblProducts", "TaxPercentage");
            DropColumn("dbo.tblProducts", "TaxableFlag");
            DropColumn("dbo.tblProducts", "MaximumStockLevel");
            DropColumn("dbo.tblProducts", "MinimumStockLevel");
            DropColumn("dbo.tblProducts", "ProductNetWeight");
            DropColumn("dbo.tblProducts", "ProductGrossWeight");
            DropColumn("dbo.tblProducts", "Size");
            DropColumn("dbo.tblProducts", "BrandName");
            DropColumn("dbo.tblProducts", "BasicPrice");
            DropColumn("dbo.tblProducts", "UnitPrice");
            DropColumn("dbo.tblProducts", "AbatmentPercentage");
            DropColumn("dbo.tblProducts", "MRP");
            DropColumn("dbo.tblProducts", "Packing");
            DropColumn("dbo.tblProducts", "ProductDescription");
            DropColumn("dbo.tblProducts", "GodownId");
            DropColumn("dbo.tblProducts", "TariffCodeId");
            DropColumn("dbo.tblProducts", "ColorId");
            DropColumn("dbo.tblProducts", "UOMMainId");
            DropColumn("dbo.tblProducts", "ProductTypeId");
            DropColumn("dbo.tblProducts", "ProductSubGroupId");
            DropColumn("dbo.tblProducts", "ProductCode");
            DropColumn("dbo.BuyerMaster", "EmailId");
            DropTable("dbo.ProductOpeningBalances");
            DropTable("dbo.ProductSKUs");
            DropTable("dbo.ProductImages");
            DropTable("dbo.ProductFactoryAllocations");
            DropTable("dbo.ProductColors");
            DropTable("dbo.ImageTypes");
            DropTable("dbo.UnitOfMaterials");
            DropTable("dbo.Tariffs");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.ProductGroups");
            DropTable("dbo.ProductSubGroups");
            DropTable("dbo.Godowns");
            DropTable("dbo.Colors");
            DropTable("dbo.FinYears");
            DropTable("dbo.BuyerOrders");
            DropTable("dbo.BuyerOrderItems");
            AddPrimaryKey("dbo.FactoryMaster", "FactoryId");
        }
    }
}
