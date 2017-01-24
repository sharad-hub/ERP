namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSchemesEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schemes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        SchemeTypeId = c.Int(),
                        SOQtyLimit = c.Int(nullable: false),
                        EveryPeriodforQty = c.Int(nullable: false),
                        FreeQty = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblProducts", t => t.ProductId)
                .ForeignKey("dbo.SchemeTypes", t => t.SchemeTypeId)
                .Index(t => t.ProductId)
                .Index(t => t.SchemeTypeId);
            
            CreateTable(
                "dbo.SchemeTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SchemeTypeName = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);



            Sql("SET IDENTITY_INSERT [dbo].[SchemeTypes] ON");
            Sql("INSERT [dbo].[SchemeTypes] ([ID], [SchemeTypeName], [Status]) VALUES (1, N'Trade Scheme',1) ");
            Sql("INSERT [dbo].[SchemeTypes] ([ID], [SchemeTypeName], [Status]) VALUES (2, N'Special Scheme',1) ");
            Sql("INSERT [dbo].[SchemeTypes] ([ID], [SchemeTypeName], [Status]) VALUES (3, N'Other Scheme',1) ");
            Sql("SET IDENTITY_INSERT [dbo].[SchemeTypes] OFF");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schemes", "SchemeTypeId", "dbo.SchemeTypes");
            DropForeignKey("dbo.Schemes", "ProductId", "dbo.tblProducts");
            DropIndex("dbo.Schemes", new[] { "SchemeTypeId" });
            DropIndex("dbo.Schemes", new[] { "ProductId" });
            DropTable("dbo.SchemeTypes");
            DropTable("dbo.Schemes");
        }
    }
}
