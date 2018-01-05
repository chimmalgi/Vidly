namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBirthdateInCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE CUSTOMERS SET BirthDate = '1/2/1990' WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
