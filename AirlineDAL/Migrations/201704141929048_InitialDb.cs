namespace AirlineDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FlightInfos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Datetime = c.DateTime(),
                        FlightNumber = c.Int(nullable: false),
                        PortOfArrival = c.String(),
                        Terminal = c.String(),
                        Flightstatus = c.Int(nullable: false),
                        Gate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FlightPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FlightInfoId = c.Int(nullable: false),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Class = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FlightInfos", t => t.FlightInfoId, cascadeDelete: true)
                .Index(t => t.FlightInfoId);
            
            CreateTable(
                "dbo.Passengers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(),
                        Sex = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FlightPrices", "FlightInfoId", "dbo.FlightInfos");
            DropIndex("dbo.FlightPrices", new[] { "FlightInfoId" });
            DropTable("dbo.Passengers");
            DropTable("dbo.FlightPrices");
            DropTable("dbo.FlightInfos");
        }
    }
}
