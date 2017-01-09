namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedBuyerAndMastersi : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Cities", newName: "CityMaster");
            RenameTable(name: "dbo.Countries", newName: "CountryMaster");
            RenameTable(name: "dbo.Designations", newName: "DesignationMaster");
            RenameTable(name: "dbo.Zones", newName: "ZoneMaster");
            RenameTable(name: "dbo.States", newName: "StateMaster");
            RenameColumn(table: "dbo.CityMaster", name: "Id", newName: "CityId");
            CreateTable(
                "dbo.BuyerMaster",
                c => new
                    {
                        BuyerId = c.Long(nullable: false, identity: true),
                        SalesExecId = c.Int(),
                        BuyerCode = c.String(),
                        BuyerName = c.String(maxLength: 50),
                        BuyerAddress = c.String(maxLength: 500),
                        BuyerBillingCityId = c.Int(),
                        BuyerDeliveryAddress = c.String(maxLength: 500),
                        BuyerDeliveryCityId = c.Int(),
                        BuyerBillingPinCode = c.String(maxLength: 10),
                        BuyerDeliveryPinCode = c.String(maxLength: 10),
                        BuyerMobileNo = c.String(maxLength: 50),
                        BuyerPhoneNo = c.String(maxLength: 50),
                        BuyerFaxNo = c.String(maxLength: 50),
                        BuyerEmailId = c.String(maxLength: 50),
                        BuyerWebSite = c.String(maxLength: 100),
                        BuyerTINNo = c.String(maxLength: 50),
                        BuyerPANNo = c.String(maxLength: 50),
                        BuyerCSTNo = c.String(maxLength: 50),
                        BuyerLSTNo = c.String(maxLength: 50),
                        BuyerGSTNo = c.String(maxLength: 50),
                        BuyerServiceTaxNo = c.String(maxLength: 50),
                        ECCCode = c.String(maxLength: 50),
                        Range = c.String(maxLength: 50),
                        Division = c.String(maxLength: 50),
                        Commissionarate = c.String(maxLength: 50),
                        ContactPersonName = c.String(maxLength: 50),
                        ContactPersonMobileNo = c.String(maxLength: 50),
                        ContactPersonEmailId = c.String(maxLength: 50),
                        SuperUserLoginId = c.String(maxLength: 50),
                        SuperUserLoginPassword = c.String(maxLength: 50),
                        SalesTaxFormId = c.Int(),
                        RoadPermitNoReq = c.Boolean(),
                        TaxType = c.Int(),
                        TaxPerc = c.Double(),
                        Status = c.Boolean(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.Int(),
                    })
                .PrimaryKey(t => t.BuyerId);
            
            CreateTable(
                "dbo.DepartmentMaster",
                c => new
                    {
                        DepartId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(maxLength: 50),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.DepartId);
            
            CreateTable(
                "dbo.FactoryMaster",
                c => new
                    {
                        FactoryId = c.Long(nullable: false, identity: true),
                        FactoryCode = c.String(),
                        FactoryName = c.String(maxLength: 50),
                        FactoryAddress = c.String(maxLength: 500),
                        FactoryCityId = c.Int(),
                        FactoryPinCode = c.String(maxLength: 10),
                        FactoryMobileNo = c.String(maxLength: 50),
                        FactoryPhoneNo = c.String(maxLength: 50),
                        FactoryFaxNo = c.String(maxLength: 50),
                        FactoryEmailId = c.String(maxLength: 50),
                        FactoryWebSite = c.String(maxLength: 100),
                        FactoryTINNo = c.String(maxLength: 50),
                        FactoryPANNo = c.String(maxLength: 50),
                        FactoryCSTNo = c.String(maxLength: 50),
                        FactoryLSTNo = c.String(maxLength: 50),
                        FactoryGSTNo = c.String(maxLength: 50),
                        FactoryServiceTaxNo = c.String(maxLength: 50),
                        ECCCode = c.String(maxLength: 50),
                        Range = c.String(maxLength: 50),
                        Division = c.String(maxLength: 50),
                        Commissionarate = c.String(maxLength: 50),
                        SuperUserLoginId = c.String(maxLength: 50),
                        SuperUserLoginPassword = c.String(maxLength: 50),
                        Status = c.Boolean(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.Int(),
                    })
                .PrimaryKey(t => t.FactoryId);
            
            CreateTable(
                "dbo.tblProducts",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        ProductTitle = c.String(maxLength: 256),
                        Type = c.String(maxLength: 50),
                        Price = c.Decimal(precision: 18, scale: 2),
                        CreatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.SalesExecutiveMaster",
                c => new
                    {
                        SalesExecId = c.Int(nullable: false, identity: true),
                        SalesExecName = c.String(maxLength: 100),
                        SalesExecDesignationId = c.Int(),
                        ParentId = c.Int(),
                        MobileNo = c.String(maxLength: 50),
                        EmailId = c.String(maxLength: 50),
                        CountryId = c.Int(),
                        ZoneId = c.Int(),
                        StateId = c.Int(),
                        CityId = c.Int(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.SalesExecId);
            
            AddColumn("dbo.CityMaster", "StateId", c => c.Int());
            AddColumn("dbo.CityMaster", "CityName", c => c.String(maxLength: 50));
            AddColumn("dbo.CityMaster", "Status", c => c.Boolean());
            AddColumn("dbo.CountryMaster", "Status", c => c.Boolean());
            AddColumn("dbo.DesignationMaster", "DesignationName", c => c.String(maxLength: 50));
            AddColumn("dbo.ZoneMaster", "CountryId", c => c.Int());
            AddColumn("dbo.ZoneMaster", "Status", c => c.Boolean());
            AddColumn("dbo.StateMaster", "ZoneId", c => c.Int());
            AddColumn("dbo.StateMaster", "Status", c => c.Boolean());
            AlterColumn("dbo.ZoneMaster", "ZoneName", c => c.String(maxLength: 50));
            DropColumn("dbo.CityMaster", "City");
            DropColumn("dbo.DesignationMaster", "compId");
            DropColumn("dbo.DesignationMaster", "Designation");
            DropColumn("dbo.ZoneMaster", "ZoneCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ZoneMaster", "ZoneCode", c => c.String());
            AddColumn("dbo.DesignationMaster", "Designation", c => c.String(maxLength: 50));
            AddColumn("dbo.DesignationMaster", "compId", c => c.Int());
            AddColumn("dbo.CityMaster", "City", c => c.String(maxLength: 50));
            AlterColumn("dbo.ZoneMaster", "ZoneName", c => c.String());
            DropColumn("dbo.StateMaster", "Status");
            DropColumn("dbo.StateMaster", "ZoneId");
            DropColumn("dbo.ZoneMaster", "Status");
            DropColumn("dbo.ZoneMaster", "CountryId");
            DropColumn("dbo.DesignationMaster", "DesignationName");
            DropColumn("dbo.CountryMaster", "Status");
            DropColumn("dbo.CityMaster", "Status");
            DropColumn("dbo.CityMaster", "CityName");
            DropColumn("dbo.CityMaster", "StateId");
            DropTable("dbo.SalesExecutiveMaster");
            DropTable("dbo.tblProducts");
            DropTable("dbo.FactoryMaster");
            DropTable("dbo.DepartmentMaster");
            DropTable("dbo.BuyerMaster");
            RenameColumn(table: "dbo.CityMaster", name: "CityId", newName: "Id");
            RenameTable(name: "dbo.StateMaster", newName: "States");
            RenameTable(name: "dbo.ZoneMaster", newName: "Zones");
            RenameTable(name: "dbo.DesignationMaster", newName: "Designations");
            RenameTable(name: "dbo.CountryMaster", newName: "Countries");
            RenameTable(name: "dbo.CityMaster", newName: "Cities");
        }
    }
}
