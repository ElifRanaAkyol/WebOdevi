using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebOdevi.Models;

namespace WebOdevi.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<TrainerService> TrainerServices { get; set; }
        public DbSet<TrainerSpecialization> TrainerSpecializations { get; set; }

        public DbSet<FitnessCenter> FitnessCenters { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            

            // TrainerService — Junction Table
            builder.Entity<TrainerService>()
                .HasKey(x => new { x.TrainerId, x.ServiceId });

            builder.Entity<TrainerService>()
                .HasOne(x => x.Trainer)
                .WithMany(t => t.TrainerServices)
                .HasForeignKey(x => x.TrainerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TrainerService>()
                .HasOne(x => x.Service)
                .WithMany(s => s.TrainerServices)
                .HasForeignKey(x => x.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            // TrainerSpecialization — Junction Table
            builder.Entity<TrainerSpecialization>()
                .HasKey(x => new { x.TrainerId, x.SpecializationId });

            builder.Entity<TrainerSpecialization>()
                .HasOne(x => x.Trainer)
                .WithMany(t => t.TrainerSpecializations)
                .HasForeignKey(x => x.TrainerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TrainerSpecialization>()
                .HasOne(x => x.Specialization)
                .WithMany(s => s.TrainerSpecializations)
                .HasForeignKey(x => x.SpecializationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Availability — Normal PK olmalı (Id)
            builder.Entity<Availability>()
                .HasOne(a => a.Trainer)
                .WithMany(t => t.TrainerAvailability)
                .HasForeignKey(a => a.TrainerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Appointment — Normal PK (Id)
            builder.Entity<Appointment>()
                .HasOne(a => a.User)
                .WithMany(u => u.Appointments)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Appointment>()
                .HasOne(a => a.Trainer)
                .WithMany(t => t.Appointments)
                .HasForeignKey(a => a.TrainerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Appointment>()
                .HasOne(a => a.Service)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            // Trainer
            builder.Entity<Trainer>()
                .HasOne(t => t.FitnessCenter)
                .WithMany(f => f.Trainers)
                .HasForeignKey(t => t.FitnessCenterId)
                .OnDelete(DeleteBehavior.Restrict);

            
        }
    }
}
