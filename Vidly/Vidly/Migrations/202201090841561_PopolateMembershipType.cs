namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopolateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, SignUpFree, DurationInMonths, DiscountRate) VALUES(1, 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFree, DurationInMonths, DiscountRate) VALUES(2, 30, 30, 30)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFree, DurationInMonths, DiscountRate) VALUES(3, 10, 10, 10)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFree, DurationInMonths, DiscountRate) VALUES(4, 90, 90, 15)");
        }
        
        public override void Down()
        {
        }
    }
}
