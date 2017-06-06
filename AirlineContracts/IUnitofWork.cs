using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineModels;
using AirlineModels.Entities;

namespace AirlineContracts
{
    public interface IUnitofWork
    {
        IRepository<FlightInfo> FlightInfo { get; }
        IRepository<FlightPrice> FlightPricelist { get; }
        IRepository<Passenger> PassageList { get; }
        IRepository<DeparturesInfo> DeparturesInfo { get; }
       
        void Dispose();
        void SaveChanges();

    }
}
