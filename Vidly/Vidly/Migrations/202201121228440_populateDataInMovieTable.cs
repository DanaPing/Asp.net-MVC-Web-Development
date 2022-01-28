namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateDataInMovieTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Movies ON");
            Sql("INSERT INTO Movies (Id, Name, GenreId, ReleaseDate, AddDate, NumberInStock) VALUES (7, 'Allien', 3, 01/01/1998, 01/01/2022, 1)");
        }
        
        public override void Down()
        {
        }
    }
}
