using Microsoft.EntityFrameworkCore;
using Parcelxpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcelxpress.Data
{
    public class LoadContext : DbContext 
    {
        public LoadContext(DbContextOptions<LoadContext> options) : base(options)
        {
        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Route> Routes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>().ToTable("Driver");
            modelBuilder.Entity<Car>().ToTable("Car");
            modelBuilder.Entity<Area>().ToTable("Area");
            modelBuilder.Entity<Route>().ToTable("Route");
        }
    }
}
