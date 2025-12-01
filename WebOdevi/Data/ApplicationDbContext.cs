using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebOdevi.Models;

namespace WebOdevi.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Availability> Availability { get; set; }
        public DbSet<Specialization> Specialization { get; set; }
        public DbSet<Trainer> Trainer { get; set; }
        public DbSet<TrainerService> TrainerService { get; set; }
        public DbSet<TrainerSpecialization> TrainerSpecialization { get; set; }
        public DbSet<TrainerSpecialization> FitnessCenter { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // TrainerService — Junction Table
            builder.Entity<TrainerService>()
                .HasKey(x => new { x.trainerId, x.serviceId });

            builder.Entity<TrainerService>()
                .HasOne(x => x.trainer)
                .WithMany(t => t.trainerServices)
                .HasForeignKey(x => x.trainerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TrainerService>()
                .HasOne(x => x.service)
                .WithMany(s => s.trainerServices)
                .HasForeignKey(x => x.serviceId)
                .OnDelete(DeleteBehavior.Restrict);

            // TrainerSpecialization — Junction Table
            builder.Entity<TrainerSpecialization>()
                .HasKey(x => new { x.trainerId, x.specializationId });

            builder.Entity<TrainerSpecialization>()
                .HasOne(x => x.trainer)
                .WithMany(t => t.trainerSpecializations)
                .HasForeignKey(x => x.trainerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TrainerSpecialization>()
                .HasOne(x => x.specialization)
                .WithMany(s => s.trainerSpecializations)
                .HasForeignKey(x => x.specializationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Availability — Normal PK olmalı (Id)
            builder.Entity<Availability>()
                .HasOne(a => a.trainer)
                .WithMany(t => t.trainerAvailability)
                .HasForeignKey(a => a.trainerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Appointment — Normal PK (Id)
            builder.Entity<Appointment>()
                .HasOne(a => a.user)
                .WithMany(u => u.appointments)
                .HasForeignKey(a => a.userId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Appointment>()
                .HasOne(a => a.trainer)
                .WithMany(t => t.appointments)
                .HasForeignKey(a => a.trainerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Appointment>()
                .HasOne(a => a.service)
                .WithMany(s => s.appointments)
                .HasForeignKey(a => a.serviceId)
                .OnDelete(DeleteBehavior.Restrict);

            // Trainer
            builder.Entity<Trainer>()
                .HasOne(t => t.fitnessCenter)
                .WithMany(f => f.trainers)
                .HasForeignKey(t => t.fitnessCenterId)
                .OnDelete(DeleteBehavior.Restrict);

            // Service
            builder.Entity<Service>()
                .HasOne(s => s.fitnessCenter)
                .WithMany(f => f.services)
                .HasForeignKey(s => s.fitnessCenterId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
