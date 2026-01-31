using HelpdeskSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpdeskSystem.Infrastructure.Data.Configurations;

public class StatusHistoryConfiguration : IEntityTypeConfiguration<StatusHistory>
{
    public void Configure(EntityTypeBuilder<StatusHistory> builder)
    {
        builder.ToTable("STATUSHISTORY");

        builder.HasKey(h => h.Id);

        builder.Property(h => h.Id)
            .HasColumnName("HISTORYID")
            .HasColumnType("CHAR(36)")
            .IsRequired();

        builder.Property(h => h.TicketId)
            .HasColumnName("TICKETID")
            .HasColumnType("CHAR(36)")
            .IsRequired();

        builder.Property(h => h.OldStatus)
            .HasColumnName("OLDSTATUS")
            .HasColumnType("VARCHAR2(20)")
            .HasConversion<string?>();

        builder.Property(h => h.NewStatus)
            .HasColumnName("NEWSTATUS")
            .HasColumnType("VARCHAR2(20)")
            .HasConversion<string>()
            .IsRequired();

        builder.Property(h => h.ChangedAt)
            .HasColumnName("CHANGEDAT")
            .HasColumnType("TIMESTAMP")
            .IsRequired();

        builder.Property(h => h.ChangedByUserId)
            .HasColumnName("CHANGEDBYUSERID")
            .HasColumnType("VARCHAR2(450)")
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
        builder.HasIndex(h => h.TicketId).HasDatabaseName("IX_STATUSHISTORY_TICKETID");
        builder.HasIndex(h => h.ChangedAt).HasDatabaseName("IX_STATUSHISTORY_CHANGEDAT");
    }
}
