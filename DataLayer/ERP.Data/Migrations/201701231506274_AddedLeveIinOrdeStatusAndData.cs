namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLeveIinOrdeStatusAndData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderStatus", "Level", c => c.Int(nullable: false));
            AlterColumn("dbo.UnitOfMeasurements", "UOM", c => c.String(nullable: false));
             Sql("SET IDENTITY_INSERT [dbo].[OrderStatus] ON");
             Sql("INSERT [dbo].[OrderStatus] ([ID], [TypeCode], [Name], [Status], [Level]) VALUES (1, N'Buyer', N'Order Entered by Buyer', 1, 1) ");
             Sql("INSERT [dbo].[OrderStatus] ([ID], [TypeCode], [Name], [Status], [Level]) VALUES (2, N'Buyer', N'Order Posted to Shahnaz', 1, 2)  ");
             Sql("INSERT [dbo].[OrderStatus] ([ID], [TypeCode], [Name], [Status], [Level]) VALUES (3, N'Sales & Mrkt', N'Order Received by Executive', 1, 3)");
             Sql("INSERT [dbo].[OrderStatus] ([ID], [TypeCode], [Name], [Status], [Level]) VALUES (4, N'Sales & Mrkt', N'Order Approved by Marketing', 1, 4)");
             Sql("INSERT [dbo].[OrderStatus] ([ID], [TypeCode], [Name], [Status], [Level]) VALUES (5, N'Accounts', N'Order Approved by Accounts', 1, 5)");
             Sql("INSERT [dbo].[OrderStatus] ([ID], [TypeCode], [Name], [Status], [Level]) VALUES (6, N'Factory', N'Order Forwarded to Factories', 1, 6)");
             Sql("INSERT [dbo].[OrderStatus] ([ID], [TypeCode], [Name], [Status], [Level]) VALUES (7, N'Factory', N'Order Forwarded to Production', 1, 7)");
             Sql("INSERT [dbo].[OrderStatus] ([ID], [TypeCode], [Name], [Status], [Level]) VALUES (8, N'Factory', N'Order Ready for Packing', 1, 8)");
             Sql("INSERT [dbo].[OrderStatus] ([ID], [TypeCode], [Name], [Status], [Level]) VALUES (9, N'Factory', N'Order Ready for Despatch', 1, 9)");
             Sql("INSERT [dbo].[OrderStatus] ([ID], [TypeCode], [Name], [Status], [Level]) VALUES (10, N'Factory', N'Order Delivered', 1, 10)");
             Sql("INSERT [dbo].[OrderStatus] ([ID], [TypeCode], [Name], [Status], [Level]) VALUES (11, N'Factory', N'Order Received by Buyer', 1, 11)");
             Sql("INSERT [dbo].[OrderStatus] ([ID], [TypeCode], [Name], [Status], [Level]) VALUES (12, N'Factory', N'Order Completed by Factory', 1, 12)");
             Sql("INSERT [dbo].[OrderStatus] ([ID], [TypeCode], [Name], [Status], [Level]) VALUES (13, N'Factory', N'Order Completed by Buyer', 1, 13)");
             Sql("INSERT [dbo].[OrderStatus] ([ID], [TypeCode], [Name], [Status], [Level]) VALUES (14, N'Buyer', N'Order Cancelled by Buyer', 1, 14)");
             Sql("INSERT [dbo].[OrderStatus] ([ID], [TypeCode], [Name], [Status], [Level]) VALUES (15, N'Buyer', N'Odrer Hold by Buyer', 1, 15)");
             Sql("INSERT [dbo].[OrderStatus] ([ID], [TypeCode], [Name], [Status], [Level]) VALUES (16, N'Sales & Mrkt', N'Order Cancelled by Management(Mrkt / Account)', 1, 16)");
             Sql("INSERT [dbo].[OrderStatus] ([ID], [TypeCode], [Name], [Status], [Level]) VALUES (17, N'Sales & Mrkt', N'Order Hold by Management (Mrkt/ Account)', 1, 17)");
             Sql("SET IDENTITY_INSERT [dbo].[OrderStatus] OFF");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UnitOfMeasurements", "UOM", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.OrderStatus", "Level");
        }
    }
}
