namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class USerTypeAndRef : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserType", newName: "UserRole");
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TypeCode = c.String(),
                        UserTypeName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Users", "UserTypeID", c => c.Int());
            AddColumn("dbo.Users", "UserReferenceID", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "UserTypeID");
            AddForeignKey("dbo.Users", "UserTypeID", "dbo.UserTypes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserTypeID", "dbo.UserTypes");
            DropIndex("dbo.Users", new[] { "UserTypeID" });
            DropColumn("dbo.Users", "UserReferenceID");
            DropColumn("dbo.Users", "UserTypeID");
            DropTable("dbo.UserTypes");
            RenameTable(name: "dbo.UserRole", newName: "UserType");
        }
    }
}
