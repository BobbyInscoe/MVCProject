namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'28e4da9b-2009-4b50-aa3d-bea2d85fa7ed', N'guest@vidly.com', 0, N'AOq9vMi0DlAZg0PERiibmUF0MoVNCp5EyHEPDdyD9sS5IYLRGzG4nvllF2g8VJsXwg==', N'db19ccb5-bdef-4be8-9fe8-5d6f59c0dd0b', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'86ac8efa-4852-4a0e-8219-bd0ea90cf1db', N'admin@vidly.com', 0, N'AA04OBqX9V73luTjB97cCPPme9xFnC3Os/oxkGbp5pYEsxmrUk4/dWszQBg79pn6IA==', N'20658fc5-182f-4e15-aa35-b7a61d440876', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2438f91a-4985-4e2c-b60b-14bbbcb64029', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'86ac8efa-4852-4a0e-8219-bd0ea90cf1db', N'2438f91a-4985-4e2c-b60b-14bbbcb64029')

");
        }
        
        public override void Down()
        {
        }
    }
}
