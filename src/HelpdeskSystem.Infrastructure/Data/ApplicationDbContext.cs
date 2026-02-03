using HelpdeskSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HelpdeskSystem.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Ticket> Tickets => Set<Ticket>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<StatusHistory> StatusHistories => Set<StatusHistory>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Apply configurations
        builder.ApplyConfiguration(new Configurations.TicketConfiguration());
        builder.ApplyConfiguration(new Configurations.CommentConfiguration());
        builder.ApplyConfiguration(new Configurations.StatusHistoryConfiguration());

        // Configure ApplicationUser
        builder.Entity<ApplicationUser>(entity =>
        {
            entity.Property(e => e.FullName).HasMaxLength(200);
        });
    }
}
