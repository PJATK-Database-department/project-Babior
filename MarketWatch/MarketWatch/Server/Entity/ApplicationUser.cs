using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketWatch.Server.Entities;
using Microsoft.AspNetCore.Identity;

namespace MarketWatch.Server.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Company> Companies { get; set; } = new List<Company>();
    }
}
