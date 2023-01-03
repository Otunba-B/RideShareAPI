using Microsoft.EntityFrameworkCore;
using RideShareAPI.Models;

namespace RideShareAPI.Data
{
    public class RideShareAPIDbContext : DbContext
    {
        public RideShareAPIDbContext(DbContextOptions options) : base(options)
        {

        } 

        public DbSet<User> User { get; set; }
    }
}
