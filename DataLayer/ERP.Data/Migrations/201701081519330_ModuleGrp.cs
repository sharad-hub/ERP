namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModuleGrp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Modules", "ModuleGroupID", "dbo.ModuleGroups");
            DropIndex("dbo.Modules", new[] { "ModuleGroupID" });
            AlterColumn("dbo.Modules", "ModuleGroupID", c => c.Int(nullable: false));
            CreateIndex("dbo.Modules", "ModuleGroupID");
            AddForeignKey("dbo.Modules", "ModuleGroupID", "dbo.ModuleGroups", "ModuleGroupID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modules", "ModuleGroupID", "dbo.ModuleGroups");
            DropIndex("dbo.Modules", new[] { "ModuleGroupID" });
            AlterColumn("dbo.Modules", "ModuleGroupID", c => c.Int());
            CreateIndex("dbo.Modules", "ModuleGroupID");
            AddForeignKey("dbo.Modules", "ModuleGroupID", "dbo.ModuleGroups", "ModuleGroupID");
        }
    }
}
