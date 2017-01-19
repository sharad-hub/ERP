namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class skinMaster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SkinMasters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SkinClass = c.String(),
                        Name = c.String(),
                        ThumbnailUrl = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SkinMasters");
        }
    }
}
