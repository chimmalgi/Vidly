namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, Genre_Id) VALUES ('Shrek', 4)");
            Sql("INSERT INTO Movies (Name, Genre_Id) VALUES ('Die Hard', 1)");
            Sql("INSERT INTO Movies (Name, Genre_Id) VALUES ('Jingle All The Way', 4)");
            Sql("INSERT INTO Movies (Name, Genre_Id) VALUES ('When Harry Met Sally', 3)");
            Sql("INSERT INTO Movies (Name, Genre_Id) VALUES ('Matrix', 5)");
        }
        
        public override void Down()
        {
        }
    }
}
