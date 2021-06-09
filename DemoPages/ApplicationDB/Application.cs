using DemoPages.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationDB
{
    public class Application : DbContext
    {
        /// <summary>
        /// Creating the database for the User
        /// </summary>
        /// <param name="options"></param>
        public Application(DbContextOptions<Application> options) : base(options)
        {
        }

        public DbSet<UserInfo> Users { get; set; }


    }
}
