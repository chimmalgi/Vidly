namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES (Name) VALUES ('Action')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Romance')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Comedy')");
            Sql("INSERT INTO GENRES (Name) VALUES ('Family')");
            Sql("INSERT INTO GENRES (Name) VALUES ('SciFi')");
        }
        
        public override void Down()
        {
        }
    }
}
