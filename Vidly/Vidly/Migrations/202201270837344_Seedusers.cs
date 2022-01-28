namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2cbe728b-8b82-497f-924e-8a341cf12682', N'admin@Vidly.com', 0, N'ACCv53/8NNDHpK5h50M1piF3K24GO01yTBRN842FStTUJB5igp+iy+Oz2GGSnKNuFw==', N'547026fb-020b-4771-b941-a3e21b2a48c5', NULL, 0, 0, NULL, 1, 0, N'admin@Vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e38e506d-4607-4c23-8e1a-9d41e35c95a3', N'guest@Vidly.com', 0, N'ADQ5TvM6A3r3F3oYVdRef0es3RZsnrMoFTgVQ0HUgsjTwq103O4Pgm5AgqhJGlrzGA==', N'fd470632-f86a-4a9d-b48c-060ec955725b', NULL, 0, 0, NULL, 1, 0, N'guest@Vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'29c633ed-49ad-4da9-adba-cf1f7c734ba2', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2cbe728b-8b82-497f-924e-8a341cf12682', N'29c633ed-49ad-4da9-adba-cf1f7c734ba2')
"
);
        }
        
        public override void Down()
        {
        }
    }
}
