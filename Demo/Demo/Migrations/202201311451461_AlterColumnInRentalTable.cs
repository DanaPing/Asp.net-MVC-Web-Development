namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterColumnInRentalTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rentals", "DateReturn", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rentals", "DateReturn", c => c.String(nullable: false));
        }
    }
}
