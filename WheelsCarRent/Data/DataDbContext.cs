using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WheelsCarRent.Models;

namespace WheelsCarRent.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        { }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<OurClient> OurClients { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
    }
}