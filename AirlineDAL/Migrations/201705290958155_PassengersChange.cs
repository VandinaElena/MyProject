namespace AirlineDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PassengersChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Passengers", "Nationality", c => c.String());
            AddColumn("dbo.Passengers", "PassportNumber", c => c.String());
            AddColumn("dbo.Passengers", "FlightNumber_Id", c => c.Int());
            DropColumn("dbo.Passengers", "sex");
            AddColumn("dbo.Passengers", "sex", c => c.Int(nullable: false));
            CreateIndex("dbo.Passengers", "FlightNumber_Id");
            AddForeignKey("dbo.Passengers", "FlightNumber_Id", "dbo.FlightInfoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passengers", "FlightNumber_Id", "dbo.FlightInfoes");
            DropIndex("dbo.Passengers", new[] { "FlightNumber_Id" });
            AlterColumn("dbo.Passengers", "sex", c => c.String());
            DropColumn("dbo.Passengers", "FlightNumber_Id");
            DropColumn("dbo.Passengers", "PassportNumber");
            DropColumn("dbo.Passengers", "Nationality");
        }
    }
}
