namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrequireForNameInMovieTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        GenreType = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "Birthday", c => c.DateTime());
            AddColumn("dbo.MembershipTypes", "Name", c => c.String(maxLength: 4000));
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "AddDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "AddDate");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.Movies", "GenreId");
            DropColumn("dbo.MembershipTypes", "Name");
            DropColumn("dbo.Customers", "Birthday");
            DropTable("dbo.Genres");
        }
    }
}
