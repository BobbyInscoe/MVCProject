namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerNames : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Name = 'Rachel Green' WHERE Name = 'Rachel'");
            Sql("UPDATE Customers SET Name = 'Monica Geller' WHERE Name = 'Monica'");
            Sql("UPDATE Customers SET Name = 'Phoebe Buffay' WHERE Name = 'Phoebe'");
            Sql("UPDATE Customers SET Name = 'Ross Geller' WHERE Name = 'Ross'");
            Sql("UPDATE Customers SET Name = 'Joey Tribbiani' WHERE Name = 'Joey'");
            Sql("UPDATE Customers SET Name = 'Chandler Bing' WHERE Name = 'Chandler'");
        }
        
        public override void Down()
        {
        }
    }
}
