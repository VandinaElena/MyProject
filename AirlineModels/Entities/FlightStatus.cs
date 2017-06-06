using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineModels.Entities
{
    public enum FlightStatus
    {
        [Display(Name = "chekc in")]
        check_in,
        [Display(Name = "gate is closed")]
        gate_closed,
        arrived,
        [Display(Name = "departed at")]
        departed_at,
        unknown,
        canceled,
        [Display(Name = "expected at")]
        expected_at,
        delayed,
        [Display(Name = "in flight")]
        in_flight,
        scheduled
    }
}
