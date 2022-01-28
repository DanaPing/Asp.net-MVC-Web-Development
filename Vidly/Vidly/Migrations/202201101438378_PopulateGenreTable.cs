namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Genres ON");
            Sql("INSERT INTO Genres (Id, GenreType) VALUES (1, 'Comedy') ");
            Sql("INSERT INTO Genres (Id, GenreType) VALUES (2, 'Romance') ");
            Sql("INSERT INTO Genres (Id, GenreType) VALUES (3, 'Action') ");
            Sql("INSERT INTO Genres (Id, GenreType) VALUES (4, 'Horror') ");
        }
        
        public override void Down()
        {
        }
    }
}
