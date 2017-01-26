namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adding_other_Masterdata : DbMigration
    {
        public override void Up()
        {           
            SqlFile(@"..\..\SPs\GetUserClaims.sql");

        }
        
        public override void Down()
        {
            
            
        }
    }
}
