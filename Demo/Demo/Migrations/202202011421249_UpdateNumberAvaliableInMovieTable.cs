namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNumberAvaliableInMovieTable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET NumberAvaliable = 1 WHERE Id = 1");
            Sql("UPDATE Movies SET NumberAvaliable = 2 WHERE Id = 2");
            Sql("UPDATE Movies SET NumberAvaliable = 4 WHERE Id = 3");
            Sql("UPDATE Movies SET NumberAvaliable = 20 WHERE Id = 5");
            Sql("UPDATE Movies SET NumberAvaliable = 11 WHERE Id = 6");
        }
        
        public override void Down()
        {
        }
    }
}
