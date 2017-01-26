namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsertypeMasterdata : DbMigration
    {
        public override void Up()
        {
            //Sql("SET IDENTITY_INSERT [dbo].[UserTypes] ON");
            //Sql("INSERT [dbo].[UserTypes] ([ID], [TypeCode], [UserTypeName]) VALUES (5, N'BUYR', N'Buyer')") ;
            //Sql("INSERT [dbo].[UserTypes] ([ID], [TypeCode], [UserTypeName]) VALUES (4, N'FCT', N'Factory')") ;
            //Sql("INSERT [dbo].[UserTypes] ([ID], [TypeCode], [UserTypeName]) VALUES (3, N'SLEX', N'Sales Executive')") ;
            //Sql("INSERT [dbo].[UserTypes] ([ID], [TypeCode], [UserTypeName]) VALUES (2, N'SADM', N'Super Admin')") ;
            //Sql("INSERT [dbo].[UserTypes] ([ID], [TypeCode], [UserTypeName]) VALUES (1, N'SYS', N'System')") ;
            //Sql("SET IDENTITY_INSERT [dbo].[UserTypes] OFF");
           
        }
        
        public override void Down()
        {
        }
    }
}
