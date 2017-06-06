using AirlineModels.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AirlineModels
{
    
    public class FlightPrice
    {
        [Key]
        public int Id { get; set; }
       
        [Display(Name = "($)Price")]
        public decimal? Price { get; set; }
        [Display(Name = "Class of Flight")]
        public ClassOfFlight Class { get; set; }
        public virtual FlightInfo FlightInfo { get; set; }
        public virtual DeparturesInfo DeparturesInfo { get; set; }
        
    }
}