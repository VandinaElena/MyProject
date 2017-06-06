using AirlineModels.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineModels
{
    public class FlightViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Date of Flight")]
        public DateTime? DateOfFlight { get; set; }
        [Display(Name = "Number")]
        public int FlightNumber { get; set; }
        [Display(Name = "Passenger's Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Passenger's First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Status of Flight")]
        public FlightStatus Flightstatus { get; set; }


    }
}
