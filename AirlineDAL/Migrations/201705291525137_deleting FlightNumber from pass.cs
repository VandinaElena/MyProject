namespace AirlineDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletingFlightNumberfrompass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Passengers", "FlightNumber_Id", "dbo.FlightInfoes");
            DropIndex("dbo.Passengers", new[] { "FlightNumber_Id" });
            DropColumn("dbo.Passengers", "FlightNumber_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Passengers", "FlightNumber_Id", c => c.Int());
            CreateIndex("dbo.Passengers", "FlightNumber_Id");
            AddForeignKey("dbo.Passengers", "FlightNumber_Id", "dbo.FlightInfoes", "Id");
        }
    }
}
