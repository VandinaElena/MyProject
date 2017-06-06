using AirlineModels.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AirlineModels
{
    //Arrivals
    
    public class FlightInfo
    {
        [Key]
        public int Id { get; set; }
        [Display (Name = "Date And Time")]
        public DateTime? Datetime { get; set; }
        [Display(Name = "Number of Flight")]
        public int FlightNumber { get; set; }
        [Display(Name = "From")]
        public string PortOfArrival { get; set; }
        public string Terminal { get; set; }
        [Display(Name = "Status of Flight")]
        public FlightStatus Flightstatus { get; set; }
        public string Gate { get; set; }

        public virtual ICollection<Passenger> Passengers { get; set; }
        public virtual ICollection<FlightPrice> FlightPrices { get; set; }

       

    }
   
}