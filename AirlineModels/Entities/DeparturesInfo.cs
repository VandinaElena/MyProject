using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineModels.Entities
{
   public class DeparturesInfo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Date And Time")]
        public DateTime? Datetime { get; set; }
        [Display(Name = "Number of Flight")]
        public int FlightNumber { get; set; }
        [Display(Name = "Port of Destination")]
        public string Destination { get; set; }
        public string Terminal { get; set; }
        [Display(Name = "Status")]
        public FlightStatus Flightstatus { get; set; }
        public string Gate { get; set; }

        public virtual ICollection<Passenger> Passengers { get; set; }
        public virtual ICollection<FlightPrice> FlightPrices { get; set; }
    }
}
