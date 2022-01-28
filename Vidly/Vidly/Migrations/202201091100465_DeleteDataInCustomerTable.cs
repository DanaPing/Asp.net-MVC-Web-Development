namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDataInCustomerTable : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE Customers WHERE id =2");
            Sql("DELETE Customers WHERE id =4");
            Sql("DELETE Customers WHERE id =6");
        }
        
        public override void Down()
        {
        }
    }
}
