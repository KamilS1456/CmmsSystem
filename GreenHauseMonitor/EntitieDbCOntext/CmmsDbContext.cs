using Cmms.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cmms.EntitieDbCOntext
{
    public class CmmsDbContext : DbContext
    {
        private string _connectionString = "Server=DESKTOP-NBTB0HL; Database = CmmsSQL; Trusted_Connection = true";
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Dish>()
                .Property(d => d.Name)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Address>()
               .Property(a => a.Street)
               .IsRequired()
               .HasMaxLength(25);

            modelBuilder.Entity<User>()
             .Property(a => a.Email)
             .IsRequired();

            modelBuilder.Entity<Role>()
              .Property(a => a.Name)
              .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
