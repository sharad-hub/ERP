namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Usersettings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserSettings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Key = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSettings", "UserID", "dbo.Users");
            DropIndex("dbo.UserSettings", new[] { "UserID" });
            DropTable("dbo.UserSettings");
        }
    }
}
