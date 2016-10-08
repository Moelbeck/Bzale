namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCompanyIDtoAccount : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Accounts", name: "Company_ID", newName: "CompanyID");
            RenameIndex(table: "dbo.Accounts", name: "IX_Company_ID", newName: "IX_CompanyID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Accounts", name: "IX_CompanyID", newName: "IX_Company_ID");
            RenameColumn(table: "dbo.Accounts", name: "CompanyID", newName: "Company_ID");
        }
    }
}
