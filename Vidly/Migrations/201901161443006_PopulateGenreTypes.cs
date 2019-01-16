namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GenreTypes(Id, Name) VALUES (1, 'Comedy')");
            Sql("INSERT INTO GenreTypes(Id, Name) VALUES (2, 'Horror')");
            Sql("INSERT INTO GenreTypes(Id, Name) VALUES (3, 'Romance')");
            Sql("INSERT INTO GenreTypes(Id, Name) VALUES (4, 'Action')");
            Sql("INSERT INTO GenreTypes(Id, Name) VALUES (5, 'Adventure')");
            Sql("INSERT INTO GenreTypes(Id, Name) VALUES (6, 'Drama')");
            Sql("INSERT INTO GenreTypes(Id, Name) VALUES (7, 'Thriller')");
            Sql("INSERT INTO GenreTypes(Id, Name) VALUES (8, 'Mystery')");
            Sql("INSERT INTO GenreTypes(Id, Name) VALUES (9, 'Animation')");
            Sql("INSERT INTO GenreTypes(Id, Name) VALUES (10, 'Fantasy')");
            Sql("INSERT INTO GenreTypes(Id, Name) VALUES (11, 'Science Fiction')");
            Sql("INSERT INTO GenreTypes(Id, Name) VALUES (12, 'Crime')");
            Sql("INSERT INTO GenreTypes(Id, Name) VALUES (13, 'Comedy-Romance')");
            Sql("INSERT INTO GenreTypes(Id, Name) VALUES (14, 'Action-Comedy')");
            Sql("INSERT INTO GenreTypes(Id, Name) VALUES (15, 'Superhero')");
        }
        
        public override void Down()
        {
        }
    }
}
