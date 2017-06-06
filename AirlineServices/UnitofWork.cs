using AirlineContracts;
using AirlineDAL;
using AirlineModels;
using System;
using System.Data.Entity;
using AirlineModels.Entities;

namespace AirlineServices
{
  public class UnitofWork: IUnitofWork, IDisposable
    {
        private readonly DbContext context;
        private bool disposed;
        private IRepository<FlightInfo> FlightsInfoRepo ;
        private IRepository<DeparturesInfo> DeparturesRepo;
        private IRepository<FlightPrice> FlightPricelistRepo;
        private IRepository<Passenger> PassengersRepo;

        public UnitofWork()
        {
            context = new AirportContext();
        }

        public IRepository<FlightInfo> FlightInfo => (FlightsInfoRepo ?? (FlightsInfoRepo = new GenericRepository<FlightInfo>(context)));
        public IRepository<FlightPrice> FlightPricelist => (FlightPricelistRepo ?? (FlightPricelistRepo = new GenericRepository<FlightPrice>(context)));
        public IRepository<Passenger> PassageList => (PassengersRepo ?? (PassengersRepo = new GenericRepository<Passenger>(context)));

        public IRepository<DeparturesInfo> DeparturesInfo => (DeparturesRepo ?? (DeparturesRepo = new GenericRepository<DeparturesInfo>(context)));
       

        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }


    }
}
