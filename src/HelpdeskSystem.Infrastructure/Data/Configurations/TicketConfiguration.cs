using HelpdeskSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpdeskSystem.Infrastructure.Data.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Tickets");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .IsRequired();

        builder.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(t => t.Description)
            .IsRequired();

        builder.Property(t => t.Priority)
            .HasMaxLength(20)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(t => t.Status)
            .HasMaxLength(20)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(t => t.CreatedAt)
            .IsRequired();

        builder.Property(t => t.UpdatedAt);

        builder.Property(t => t.CreatedByUserId)
            .HasMaxLength(450)
            .IsRequired();

        builder.Property(t => t.AssignedAgentId)
            .HasMaxLength(450);

        // Relationships
        builder.HasOne(t => t.CreatedByUser)
            .WithMany(u => u.CreatedTickets)
            .HasForeignKey(t => t.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.AssignedAgent)
            .WithMany(u => u.AssignedTickets)
            .HasForeignKey(t => t.AssignedAgentId)
            .OnDelete(DeleteBehavior.SetNull);

        // Indexes
        builder.HasIndex(t => t.Status);
        builder.HasIndex(t => t.Priority);
        builder.HasIndex(t => t.CreatedAt);
        builder.HasIndex(t => t.AssignedAgentId);
        builder.HasIndex(t => t.CreatedByUserId);
    }
}
