namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedproductrelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblProducts", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.tblProducts", "TariffCodeId", "dbo.Tariffs");
            DropForeignKey("dbo.tblProducts", "UOMMainId", "dbo.UnitOfMaterials");
            DropIndex("dbo.tblProducts", new[] { "UOMMainId" });
            DropIndex("dbo.tblProducts", new[] { "ColorId" });
            DropIndex("dbo.tblProducts", new[] { "TariffCodeId" });
            AlterColumn("dbo.tblProducts", "UOMMainId", c => c.Int());
            AlterColumn("dbo.tblProducts", "ColorId", c => c.Int());
            AlterColumn("dbo.tblProducts", "TariffCodeId", c => c.Int());
            CreateIndex("dbo.tblProducts", "UOMMainId");
            CreateIndex("dbo.tblProducts", "ColorId");
            CreateIndex("dbo.tblProducts", "TariffCodeId");
            AddForeignKey("dbo.tblProducts", "ColorId", "dbo.Colors", "ID");
            AddForeignKey("dbo.tblProducts", "TariffCodeId", "dbo.Tariffs", "ID");
            AddForeignKey("dbo.tblProducts", "UOMMainId", "dbo.UnitOfMaterials", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblProducts", "UOMMainId", "dbo.UnitOfMaterials");
            DropForeignKey("dbo.tblProducts", "TariffCodeId", "dbo.Tariffs");
            DropForeignKey("dbo.tblProducts", "ColorId", "dbo.Colors");
            DropIndex("dbo.tblProducts", new[] { "TariffCodeId" });
            DropIndex("dbo.tblProducts", new[] { "ColorId" });
            DropIndex("dbo.tblProducts", new[] { "UOMMainId" });
            AlterColumn("dbo.tblProducts", "TariffCodeId", c => c.Int(nullable: false));
            AlterColumn("dbo.tblProducts", "ColorId", c => c.Int(nullable: false));
            AlterColumn("dbo.tblProducts", "UOMMainId", c => c.Int(nullable: false));
            CreateIndex("dbo.tblProducts", "TariffCodeId");
            CreateIndex("dbo.tblProducts", "ColorId");
            CreateIndex("dbo.tblProducts", "UOMMainId");
            AddForeignKey("dbo.tblProducts", "UOMMainId", "dbo.UnitOfMaterials", "ID", cascadeDelete: true);
            AddForeignKey("dbo.tblProducts", "TariffCodeId", "dbo.Tariffs", "ID", cascadeDelete: true);
            AddForeignKey("dbo.tblProducts", "ColorId", "dbo.Colors", "ID", cascadeDelete: true);
        }
    }
}
