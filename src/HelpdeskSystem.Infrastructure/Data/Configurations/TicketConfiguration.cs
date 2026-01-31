using HelpdeskSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpdeskSystem.Infrastructure.Data.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("TICKETS");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .HasColumnName("TICKETID")
            .HasColumnType("CHAR(36)")
            .IsRequired();

        builder.Property(t => t.Title)
            .HasColumnName("TITLE")
            .HasColumnType("VARCHAR2(200)")
            .IsRequired();

        builder.Property(t => t.Description)
            .HasColumnName("DESCRIPTION")
            .HasColumnType("CLOB")
            .IsRequired();

        builder.Property(t => t.Priority)
            .HasColumnName("PRIORITY")
            .HasColumnType("VARCHAR2(20)")
            .HasConversion<string>()
            .IsRequired();

        builder.Property(t => t.Status)
            .HasColumnName("STATUS")
            .HasColumnType("VARCHAR2(20)")
            .HasConversion<string>()
            .IsRequired();

        builder.Property(t => t.CreatedAt)
            .HasColumnName("CREATEDAT")
            .HasColumnType("TIMESTAMP")
            .IsRequired();

        builder.Property(t => t.UpdatedAt)
            .HasColumnName("UPDATEDAT")
            .HasColumnType("TIMESTAMP");

        builder.Property(t => t.CreatedByUserId)
            .HasColumnName("CREATEDBYUSERID")
            .HasColumnType("VARCHAR2(450)")
            .IsRequired();

        builder.Property(t => t.AssignedAgentId)
            .HasColumnName("ASSIGNEDAGENTID")
            .HasColumnType("VARCHAR2(450)");

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
        builder.HasIndex(t => t.Status).HasDatabaseName("IX_TICKETS_STATUS");
        builder.HasIndex(t => t.Priority).HasDatabaseName("IX_TICKETS_PRIORITY");
        builder.HasIndex(t => t.CreatedAt).HasDatabaseName("IX_TICKETS_CREATEDAT");
        builder.HasIndex(t => t.AssignedAgentId).HasDatabaseName("IX_TICKETS_ASSIGNEDAGENTID");
        builder.HasIndex(t => t.CreatedByUserId).HasDatabaseName("IX_TICKETS_CREATEDBYUSERID");
    }
}
