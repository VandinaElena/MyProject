using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


using System.Data.Entity.ModelConfiguration.Conventions;
using AirlineModels;
using AirlineModels.Entities;

namespace AirlineDAL
{
    public class AirportContext :DbContext
    {
        public AirportContext():base("name = AirportDB") { }

        public DbSet<FlightInfo> FlightInfoes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<FlightPrice> FlightPrices { get; set; }
        public DbSet<DeparturesInfo> DeparturesInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        
            modelBuilder.Entity<Passenger>()
                .HasMany(e => e.FlightInfos)
                .WithMany(e => e.Passengers)
                .Map(t =>
                {
                    t.MapLeftKey("PassengerId");
                    t.MapRightKey("FlightInfoId");
                    t.ToTable("PassengerFlightInfo");
                });

                       

        }

       
    }
}