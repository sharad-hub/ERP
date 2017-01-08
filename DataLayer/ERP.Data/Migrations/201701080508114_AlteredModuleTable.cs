namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteredModuleTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Modules", name: "ModuleGroup_ModuleGroupID", newName: "ModuleGroupID");
            RenameColumn(table: "dbo.Modules", name: "UrlContext_UrlContextID", newName: "UrlContextID");
            RenameIndex(table: "dbo.Modules", name: "IX_ModuleGroup_ModuleGroupID", newName: "IX_ModuleGroupID");
            RenameIndex(table: "dbo.Modules", name: "IX_UrlContext_UrlContextID", newName: "IX_UrlContextID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Modules", name: "IX_UrlContextID", newName: "IX_UrlContext_UrlContextID");
            RenameIndex(table: "dbo.Modules", name: "IX_ModuleGroupID", newName: "IX_ModuleGroup_ModuleGroupID");
            RenameColumn(table: "dbo.Modules", name: "UrlContextID", newName: "UrlContext_UrlContextID");
            RenameColumn(table: "dbo.Modules", name: "ModuleGroupID", newName: "ModuleGroup_ModuleGroupID");
        }
    }
}
