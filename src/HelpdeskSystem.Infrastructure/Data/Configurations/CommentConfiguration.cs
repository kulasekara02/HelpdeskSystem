using HelpdeskSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpdeskSystem.Infrastructure.Data.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("COMMENTS");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("COMMENTID")
            .HasColumnType("CHAR(36)")
            .IsRequired();

        builder.Property(c => c.TicketId)
            .HasColumnName("TICKETID")
            .HasColumnType("CHAR(36)")
            .IsRequired();

        builder.Property(c => c.Text)
            .HasColumnName("TEXT")
            .HasColumnType("CLOB")
            .IsRequired();

        builder.Property(c => c.CreatedAt)
            .HasColumnName("CREATEDAT")
            .HasColumnType("TIMESTAMP")
            .IsRequired();

        builder.Property(c => c.CreatedByUserId)
            .HasColumnName("CREATEDBYUSERID")
            .HasColumnType("VARCHAR2(450)")
            .IsRequired();

        // Relationships
        builder.HasOne(c => c.Ticket)
            .WithMany(t => t.Comments)
            .HasForeignKey(c => c.TicketId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(c => c.CreatedByUser)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        builder.HasIndex(c => c.TicketId).HasDatabaseName("IX_COMMENTS_TICKETID");
        builder.HasIndex(c => c.CreatedAt).HasDatabaseName("IX_COMMENTS_CREATEDAT");
    }
}
