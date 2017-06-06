namespace AirlineDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNavProp : DbMigration
    {
        public override void Up()
        {
           
            CreateTable(
                "dbo.PassengerFlightInfo",
                c => new
                    {
                        PassengerId = c.Int(nullable: false),
                        FlightInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PassengerId, t.FlightInfoId })
                .Index(t => t.PassengerId)
                .Index(t => t.FlightInfoId);
             AddForeignKey("dbo.PassengerFlightInfo", "PassengerId", "dbo.Passengers", "Id");
             AddForeignKey("dbo.PassengerFlightInfo", "FlightInfoId", "dbo.FlightInfos", "Id");
        
            
        }
        
        public override void Down()
        {
            
           DropIndex("dbo.PassengerFlightInfo", new[] { "FlightInfoId" });
            DropIndex("dbo.PassengerFlightInfo", new[] { "PassengerId" });
            DropTable("dbo.PassengerFlightInfo");
           
        }
    }
}
