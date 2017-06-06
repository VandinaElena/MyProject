namespace AirlineDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDepartures : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeparturesInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Datetime = c.DateTime(),
                        FlightNumber = c.Int(nullable: false),
                        Destination = c.String(),
                        Terminal = c.String(),
                        Flightstatus = c.Int(nullable: false),
                        Gate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.FlightPrices", "DeparturesInfo_Id", c => c.Int());
            AddColumn("dbo.Passengers", "Departure_Id", c => c.Int());
            CreateIndex("dbo.FlightPrices", "DeparturesInfo_Id");
            CreateIndex("dbo.Passengers", "Departure_Id");
            AddForeignKey("dbo.FlightPrices", "DeparturesInfo_Id", "dbo.DeparturesInfoes", "Id");
            AddForeignKey("dbo.Passengers", "Departure_Id", "dbo.DeparturesInfoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passengers", "Departure_Id", "dbo.DeparturesInfoes");
            DropForeignKey("dbo.FlightPrices", "DeparturesInfo_Id", "dbo.DeparturesInfoes");
            DropIndex("dbo.Passengers", new[] { "Departure_Id" });
            DropIndex("dbo.FlightPrices", new[] { "DeparturesInfo_Id" });
            DropColumn("dbo.Passengers", "Departure_Id");
            DropColumn("dbo.FlightPrices", "DeparturesInfo_Id");
            DropTable("dbo.DeparturesInfoes");
        }
    }
}
