using Microsoft.EntityFrameworkCore;
using Mid_Project.Models;

namespace Mid_Project.Data
{
    public class SystemDbContext:DbContext
    {
        public SystemDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Admin> admin { set; get; }
        public DbSet<Buss> buss { set; get; }
        public DbSet<Trip> trip { set; get; }
        public DbSet<Passenger> passenger { set; get; }





    }
}
