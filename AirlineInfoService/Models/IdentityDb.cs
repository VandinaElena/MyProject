using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineInfoService.Models
{
    public class IdentityDb : IdentityDbContext<ApplicationUser>
    {
        public IdentityDb() : base("IdentityDb") { }

        public static IdentityDb Create()
        {
            return new IdentityDb();
        }
        
        
    }
}