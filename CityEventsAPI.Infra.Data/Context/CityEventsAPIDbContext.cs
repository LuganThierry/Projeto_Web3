using CityEventsAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEventsAPI.Infra.Data.Context
{
    public class CityEventsAPIDbContext : DbContext
    {
        public CityEventsAPIDbContext(DbContextOptions<CityEventsAPIDbContext> options) : base(options)
        {
        }

        //

        public DbSet<Event> Events { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }

        //

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CityEventsAPIDbContext).Assembly);
        }
    }
}
