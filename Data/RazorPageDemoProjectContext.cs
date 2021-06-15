using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPageDemoProject.Models;

namespace RazorPageDemoProject.Data
{
    public class RazorPageDemoProjectContext : DbContext
    {
        public RazorPageDemoProjectContext (DbContextOptions<RazorPageDemoProjectContext> options) : base(options)
        {

        }

        public DbSet<Club> Club { get; set; }

        public DbSet<Users> UserCredentials { get; set; }

        public DbSet<City> City { get; set; }

        public DbSet<State> State { get; set; }

        
    }
}
