using Microsoft.EntityFrameworkCore;

namespace Rideme.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Ride> Rides { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Feedback entity
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Passenger)
                .WithMany(p => p.Feedbacks)
                .HasForeignKey(f => f.PassengerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Driver)
                .WithMany(d => d.Feedbacks)
                .HasForeignKey(f => f.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Ride)
                .WithMany(r => r.Feedbacks)
                .HasForeignKey(f => f.RideId)
                .OnDelete(DeleteBehavior.Restrict);

            // Passenger entity
            modelBuilder.Entity<Passenger>()
                .HasMany(p => p.Rides)
                .WithOne(r => r.Passenger)
                .HasForeignKey(r => r.PassengerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Passenger>()
                .HasMany(p => p.Feedbacks)
                .WithOne(f => f.Passenger)
                .HasForeignKey(f => f.PassengerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Driver entity
            modelBuilder.Entity<Driver>()
                .HasMany(d => d.Rides)
                .WithOne(r => r.Driver)
                .HasForeignKey(r => r.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Driver>()
                .HasMany(d => d.Feedbacks)
                .WithOne(f => f.Driver)
                .HasForeignKey(f => f.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

            // Ride entity
            modelBuilder.Entity<Ride>()
                .HasOne(r => r.Passenger)
                .WithMany(p => p.Rides)
                .HasForeignKey(r => r.PassengerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ride>()
                .HasOne(r => r.Driver)
                .WithMany(d => d.Rides)
                .HasForeignKey(r => r.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ride>()
                .HasMany(r => r.Feedbacks)
                .WithOne(f => f.Ride)
                .HasForeignKey(f => f.RideId)
                .OnDelete(DeleteBehavior.Restrict);

            // User entity
            modelBuilder.Entity<User>()
                .HasOne(u => u.Passenger)
                .WithOne(p => p.User)
                .HasForeignKey<Passenger>(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Driver)
                .WithOne(d => d.User)
                .HasForeignKey<Driver>(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);



            base.OnModelCreating(modelBuilder);
        }
    }
}
