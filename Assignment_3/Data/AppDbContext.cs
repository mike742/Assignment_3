using Assignment_3.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Assignment_3.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> ops) : base(ops) { }

        public DbSet<MenuItem> MenuItems { set; get; }
        public DbSet<Reservation> Reservations { set; get; }
        public DbSet<ReservationMenuItems> ReservationMenuItems { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { Id = 1, Price = 14.99, Name = "Spaghetti" }
                );
            modelBuilder.Entity<Reservation>().HasData(
                new Reservation { Id = 1, Name = "Bob Loblaw", Date = new DateTime(2020, 1, 1)}
                );
            modelBuilder.Entity<ReservationMenuItems>().HasData(
                new ReservationMenuItems { Id = 1, ReservationId = 1, MenuItemId = 1}
                );
        }
    }
}
