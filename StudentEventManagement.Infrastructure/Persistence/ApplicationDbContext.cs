using Microsoft.EntityFrameworkCore;
using StudentEventManagement.Domain.Entities;

namespace StudentEventManagement.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Registration> Registrations { get; set; } // ✅ ADD THIS

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Registration>()
                .HasKey(r => new { r.EventId, r.ParticipantId }); // Composite Key

                modelBuilder.Entity<Registration>()
                .HasOne(r => r.Event)
                .WithMany(e => e.Registrations)
                .HasForeignKey(r => r.EventId)
                .OnDelete(DeleteBehavior.Restrict); // ✅ Restrict

            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Participant)
                .WithMany(p => p.Registrations)
                .HasForeignKey(r => r.ParticipantId)
                .OnDelete(DeleteBehavior.Restrict); // ✅ Restrict
        }





    }
}
