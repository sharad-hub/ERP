namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedurllinkTousertype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserTypes", "UrlContextID", c => c.Int());
            CreateIndex("dbo.UserTypes", "UrlContextID");
            AddForeignKey("dbo.UserTypes", "UrlContextID", "dbo.UrlContexts", "UrlContextID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTypes", "UrlContextID", "dbo.UrlContexts");
            DropIndex("dbo.UserTypes", new[] { "UrlContextID" });
            DropColumn("dbo.UserTypes", "UrlContextID");
        }
    }
}
