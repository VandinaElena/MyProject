namespace AirlineDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTableNames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.FlightInfos", newName: "FlightInfoes");
           
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.FlightPrices", newName: "FlightPrice");
            RenameTable(name: "dbo.Passengers", newName: "Passenger");
            RenameTable(name: "dbo.FlightInfoes", newName: "FlightInfo");
        }
    }
}
