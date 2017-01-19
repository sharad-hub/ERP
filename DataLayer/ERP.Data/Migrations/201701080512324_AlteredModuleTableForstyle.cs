namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteredModuleTableForstyle : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Modules", name: "UIStyle_UIStyleID", newName: "UIStyleID");
            RenameIndex(table: "dbo.Modules", name: "IX_UIStyle_UIStyleID", newName: "IX_UIStyleID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Modules", name: "IX_UIStyleID", newName: "IX_UIStyle_UIStyleID");
            RenameColumn(table: "dbo.Modules", name: "UIStyleID", newName: "UIStyle_UIStyleID");
        }
    }
}
