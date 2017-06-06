using AirlineContracts;
using AirlineModels;
using AirlineModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineServices
{
    public class FindFlightByStatusService
    {
        private readonly IUnitofWork unitOfWork;
        public FindFlightByStatusService()
        {
            unitOfWork = new UnitofWork();
        }

        public IEnumerable<FlightInfo> FindFlightByStatus(FlightStatus status)
        {
           
            return unitOfWork.FlightInfo.Search(e => e.Flightstatus == status).ToList();

        }
    }
}
