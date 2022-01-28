namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToCustomerTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Customers ON");
            Sql("INSERT INTO Customers (Id, Name, IsSubscribedToNewsletter, MembershipTypeId, Birthday) VALUES(1, 'John Smith', 0, 1, null)");
            Sql("INSERT INTO Customers (Id, Name, IsSubscribedToNewsletter, MembershipTypeId, Birthday) VALUES(2, 'Mary Jane', 0, 2, null)");


        }
        
        public override void Down()
        {
        }
    }
}
