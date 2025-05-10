using Microsoft.EntityFrameworkCore;
using EasyTravel.Models;
using Microsoft.AspNetCore.Identity; // User modelini dahil etmelisiniz

namespace EasyTravel.Data
{
    public class TravelContext : DbContext
    {
        public TravelContext(DbContextOptions<TravelContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<Travel> Travels { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<TravelRoute> TravelRoutes { get; set; }
        public DbSet<FlightInfo> FlightInfos { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Tour> Tours { get; set; }


    }
}
