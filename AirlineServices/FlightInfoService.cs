using AirlineContracts;
using AirlineModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineServices
{
    public class FlightInfoService
    {
        private readonly IUnitofWork unitOfWork;
        public FlightInfoService()
        {
            unitOfWork = new UnitofWork();
        }
        // id=passengers's lastname
        public IEnumerable<FlightViewModel> FindFlight(string id)
        {
           
            return unitOfWork.FlightInfo.Search(e => e.Passengers.Any(c => c.LastName.ToLower() == id.ToLower())).SelectMany(e => e.Passengers, (c, e) => new
            {
                c.Id,
                c.Datetime,
                c.Flightstatus,
                c.FlightNumber,
                e.LastName,
                e.FirstName
            })
            .Where(e => e.LastName.ToLower() == id.ToLower())
            .Select(e => new FlightViewModel
            {
                Id = e.Id,
                DateOfFlight = e.Datetime,
                FlightNumber = e.FlightNumber,
                Flightstatus = e.Flightstatus,
                LastName = e.LastName,
                FirstName=e.FirstName
            });

           
        }
    }
}
