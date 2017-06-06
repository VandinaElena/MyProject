using AirlineModels;
using AirlineModels.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;



namespace AirlineModels
{

    public class Passenger
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public Sex sex { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        public string Nationality { get; set; }
        [Display(Name = "Number of Passport")]
        public string PassportNumber { get; set; }
        [Display(Name = "Number of Flight")]
       
        public virtual ICollection<FlightInfo> FlightInfos { get; set; }
        public virtual DeparturesInfo Departure { get; set; }
    }
      }
