namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateNumberAvaliable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies Set NumberAvaliable = NumberInStock ");
        }
        
        public override void Down()
        {
        }
    }
}
