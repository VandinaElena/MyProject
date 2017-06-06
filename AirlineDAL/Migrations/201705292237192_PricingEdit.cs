namespace AirlineDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PricingEdit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FlightPrices", "FlightInfoId", "dbo.FlightInfoes");
            DropIndex("dbo.FlightPrices", new[] { "FlightInfoId" });
            RenameColumn(table: "dbo.FlightPrices", name: "FlightInfoId", newName: "FlightInfo_Id");
            AlterColumn("dbo.FlightPrices", "FlightInfo_Id", c => c.Int());
            CreateIndex("dbo.FlightPrices", "FlightInfo_Id");
            AddForeignKey("dbo.FlightPrices", "FlightInfo_Id", "dbo.FlightInfoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FlightPrices", "FlightInfo_Id", "dbo.FlightInfoes");
            DropIndex("dbo.FlightPrices", new[] { "FlightInfo_Id" });
            AlterColumn("dbo.FlightPrices", "FlightInfo_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.FlightPrices", name: "FlightInfo_Id", newName: "FlightInfoId");
            CreateIndex("dbo.FlightPrices", "FlightInfoId");
            AddForeignKey("dbo.FlightPrices", "FlightInfoId", "dbo.FlightInfoes", "Id", cascadeDelete: true);
        }
    }
}
