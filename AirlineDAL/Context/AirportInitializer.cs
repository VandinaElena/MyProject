using AirlineModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AirlineDAL
{
    public class AirportInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AirportContext>
    {
        protected override void Seed (AirportContext context)
        {
            //var passengers = new List<PassageList>()
            //{
            //    new PassageList() {PassengerFirstName = "Ivan", PassengerLastName ="Ivanov", DateOfBirth =new DateTime(), PassangerSex = "M", PassageListId = 1 },
            //    new PassageList() {PassengerFirstName = "Ivan", PassengerLastName ="Ivanov", DateOfBirth =new DateTime(), PassangerSex = "M", PassageListId = 2 },
            //    new PassageList() {PassengerFirstName = "Ivan", PassengerLastName ="Ivanov", DateOfBirth =new DateTime(), PassangerSex = "M", PassageListId = 3 }
            //};

            //passengers.ForEach(p => context.PassageList.Add(p));
            //context.SaveChanges();

            //var flights = new List<FlightPricelist>()
            //{
            //       new FlightPricelist() { FlightPricelistId  = 1, Price = 32.54m,  Class = ClassOfFlight.business},
            //       new FlightPricelist() { FlightPricelistId  = 2, Price = 32.54m,  Class = ClassOfFlight.business},
            //       new FlightPricelist() { FlightPricelistId  = 3, Price = 32.54m,  Class = ClassOfFlight.economy},
            //};
            //flights.ForEach(f => context.FlightPricelist.Add(f));
            //context.SaveChanges();

            //var arrivals = new List<ArrivalsInfo>()
            //{
            //    new ArrivalsInfo() {ArrivalsId = 0, FlightNumber =142, Gate="B", Flightstatus= FlightStatus.arrived, Datetime= new DateTime(), PortOfArrival = "Borispol", Terminal="D" },
            //    new ArrivalsInfo() {ArrivalsId = 5, FlightNumber =142, Gate="B", Flightstatus= FlightStatus.arrived, Datetime= new DateTime(), PortOfArrival = "Borispol", Terminal="D" },
            //    new ArrivalsInfo() {ArrivalsId = 6, FlightNumber =142, Gate="B", Flightstatus= FlightStatus.arrived, Datetime= new DateTime(), PortOfArrival = "Borispol", Terminal="D" }

            //};
            //arrivals.ForEach(a => context.ArrivalsInfo.Add(a));
            //context.SaveChanges();


        }
    }
}