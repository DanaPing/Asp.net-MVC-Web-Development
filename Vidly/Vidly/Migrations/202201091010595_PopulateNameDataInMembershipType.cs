namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNameDataInMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay As You Go' WHERE id = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
