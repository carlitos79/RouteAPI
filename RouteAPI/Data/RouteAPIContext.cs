using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RouteAPI.Models
{
    public class RouteAPIContext : DbContext
    {
        public RouteAPIContext (DbContextOptions<RouteAPIContext> options)
            : base(options)
        {
        }

        public DbSet<RouteAPI.Models.Checkpoint> Checkpoint { get; set; }
    }
}
