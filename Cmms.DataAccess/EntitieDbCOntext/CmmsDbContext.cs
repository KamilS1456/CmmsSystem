using Cmms.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cmms.DataAccess.EntitieDbCOntext
{
    public class CmmsDbContext : IdentityDbContext
    {

        public CmmsDbContext()
        {
        }

        public CmmsDbContext(DbContextOptions<CmmsDbContext> options) : base(options)
        {
        }

        public DbSet<UserProfile> UserProfileS { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentSet> EquipmentSets { get; set; }
        public DbSet<EquipmentSetToEquipment> EquipmentSetToEquipments { get; set; }

        public DbSet<Occurrence> Occurrences { get; set; }
        public DbSet<OccurrenceType> OccurrenceTypes { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }
        
        public DbSet<Quest> Quests { get; set; }
        public DbSet<QuestType> QuestTypes { get; set; }
        public DbSet<QuestToEquipment> QuestToEquipments { get; set; }
        public DbSet<QuestToUser> QuestToUsers { get; set; }

        



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserProfile>()
                .OwnsOne(up => up.UserProfileBasicInfo);

            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Address>()
               .Property(a => a.Street)
               .IsRequired()
               .HasMaxLength(25);


            modelBuilder.Entity<Quest>()
             .Property(a => a.Name)
             .IsRequired();


            modelBuilder.Entity<EquipmentSet>()
            .Property(a => a.Name)
            .IsRequired();





        }
    }
}
