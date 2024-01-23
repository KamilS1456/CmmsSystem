using Cmms.Entities;
using Cmms.Entities.Settings;
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
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SettingValueBool> SettingValueBools { get; set; }
        public DbSet<SettingValueInt> SettingValueInts { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<QuestToEquipment> QuestToEquipments { get; set; }
        public DbSet<QuestToUser> QuestToUsers { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Occurrence> Occurrences { get; set; }
        public DbSet<OccurrenceType> OccurrenceTypes { get; set; }



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

            modelBuilder.Entity<Setting>()
             .Property(a => a.Name)
             .IsRequired();

            modelBuilder.Entity<User>()
             .Property(a => a.Email)
             .IsRequired();

            modelBuilder.Entity<Role>()
              .Property(a => a.Name)
              .IsRequired();

            modelBuilder.Entity<Quest>()
             .Property(a => a.Name)
             .IsRequired();

            //modelBuilder.Entity<QuestToEquipment>();

            modelBuilder.Entity<QuestToUser>();
            
            //modelBuilder.Entity<SettingToRole>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
