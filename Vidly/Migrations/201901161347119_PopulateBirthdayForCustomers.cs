namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBirthdayForCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthday = '05/05/1970' WHERE Name = 'Rachel'");
            Sql("UPDATE Customers SET Birthday = '03/22/1970' WHERE Name = 'Monica'");
            Sql("UPDATE Customers SET Birthday = '02/16/1967' WHERE Name = 'Phoebe'");
            Sql("UPDATE Customers SET Birthday = '10/18/1968' WHERE Name = 'Ross'");
            Sql("UPDATE Customers SET Birthday = '06/15/1968' WHERE Name = 'Joey'");
            Sql("UPDATE Customers SET Birthday = '04/08/1968' WHERE Name = 'Chandler'");
        }
        
        public override void Down()
        {
        }
    }
}
