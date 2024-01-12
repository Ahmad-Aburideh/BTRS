using Microsoft.EntityFrameworkCore;
using BTRS.Models;

namespace BTRS.Models
{
    public class MyDbContext :DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<passenger> passengers { get; set; }
        public DbSet<administrator> admins { get; set; }

        //public DbSet<administrator> trips { get; set; }

        //public DbSet<BTRS.Models.trip>? trip { get; set; }

        public DbSet<trip>? trip { get; set; }

        public DbSet<BookingTrips>? bookingtrips { get; set; }

        //public DbSet<administrator> trips { get; set; }

        //public DbSet<BTRS.Models.trip>? trip { get; set; }

        public DbSet<bus>? bus { get; set; }
    }
}
