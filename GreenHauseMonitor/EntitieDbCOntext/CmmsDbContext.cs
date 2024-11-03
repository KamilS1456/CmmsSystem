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
       

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentToEquipment> EquipmentToEquipments { get; set; }
        public DbSet<EquipmentSet> EquipmentSets { get; set; }
        public DbSet<EquipmentSetToEquipment> EquipmentSetToEquipments { get; set; }

        public DbSet<Occurrence> Occurrences { get; set; }
        public DbSet<OccurrenceType> OccurrenceTypes { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Setting> Settings { get; set; }
        public DbSet<SettingValueBool> SettingValueBools { get; set; }
        public DbSet<SettingValueInt> SettingValueInts { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<User> Users { get; set; }
 
        
        public DbSet<Quest> Quests { get; set; }
        public DbSet<QuestType> QuestTypes { get; set; }
        public DbSet<QuestToEquipment> QuestToEquipments { get; set; }
        public DbSet<QuestToUser> QuestToUsers { get; set; }

        



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


            modelBuilder.Entity<Equipment>()
                .HasMany(e => e.PrimalEquipmentList)
                .WithMany(e => e.InnerEquipmentList)
                .UsingEntity<EquipmentToEquipment>(
                    right => right
                        .HasOne(joinEntity => joinEntity.PrimalEquipment)
                        .WithMany().OnDelete(DeleteBehavior.NoAction),
                    left => left
                        .HasOne(joinEntity => joinEntity.InnerEquipment)
                        .WithMany().OnDelete(DeleteBehavior.NoAction));//cos sie popsuło i nie puszcza bez id

            modelBuilder.Entity<EquipmentSet>()
            .Property(a => a.Name)
            .IsRequired();



        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
