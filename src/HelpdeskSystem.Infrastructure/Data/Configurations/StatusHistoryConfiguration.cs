using HelpdeskSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpdeskSystem.Infrastructure.Data.Configurations;

public class StatusHistoryConfiguration : IEntityTypeConfiguration<StatusHistory>
{
    public void Configure(EntityTypeBuilder<StatusHistory> builder)
    {
        builder.ToTable("StatusHistory");

        builder.HasKey(h => h.Id);

        builder.Property(h => h.Id)
            .IsRequired();

        builder.Property(h => h.TicketId)
            .IsRequired();

        builder.Property(h => h.OldStatus)
            .HasMaxLength(20)
            .HasConversion<string?>();

        builder.Property(h => h.NewStatus)
            .HasMaxLength(20)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(h => h.ChangedAt)
            .IsRequired();

        builder.Property(h => h.ChangedByUserId)
            .HasMaxLength(450)
            .IsRequired();

        // Relationships
        builder.HasOne(h => h.Ticket)
            .WithMany(t => t.StatusHistories)
            .HasForeignKey(h => h.TicketId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(h => h.ChangedByUser)
            .WithMany(u => u.StatusChanges)
            .HasForeignKey(h => h.ChangedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        builder.HasIndex(h => h.TicketId);
        builder.HasIndex(h => h.ChangedAt);
    }
}
