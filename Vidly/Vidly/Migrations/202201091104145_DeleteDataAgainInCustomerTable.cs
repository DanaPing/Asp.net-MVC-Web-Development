namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDataAgainInCustomerTable : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE Customers Where id = 7");
            Sql("DELETE Customers Where id = 8");
        }
        
        public override void Down()
        {
        }
    }
}
