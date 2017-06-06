using AirlineContracts;
using AirlineModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineServices
{
   public class PassengersWithFlightsService
    {
        private readonly IUnitofWork unitOfWork;
        public PassengersWithFlightsService()
        {
            unitOfWork = new UnitofWork();
        }
       
        public IEnumerable<PassengersViewModel> FindPassengersWithFlights()
        {
           
            return unitOfWork.PassageList.Include(
                e=> e.Id,
                e => e.DateOfBirth,
                e => e.FirstName,
                e => e.LastName,
                e => e.Nationality,
                e => e.PassportNumber,
                e => e.sex,
                e => e.FlightInfos.Select(c => c.FlightNumber))
                .Select(c => new PassengersViewModel
                {
                    Id=c.Id,
                    DateOfBirth = c.DateOfBirth,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Nationality = c.Nationality,
                    PassportNumber = c.PassportNumber,
                    sex = c.sex,
                    FlightNum = c.FlightInfos.Select(d => d.FlightNumber).FirstOrDefault(),
                });
        }
    
    }
}
