using HelpdeskSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpdeskSystem.Infrastructure.Data.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .IsRequired();

        builder.Property(c => c.TicketId)
            .IsRequired();

        builder.Property(c => c.Text)
            .IsRequired();

        builder.Property(c => c.CreatedAt)
            .IsRequired();

        builder.Property(c => c.CreatedByUserId)
            .HasMaxLength(450)
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
        builder.HasIndex(c => c.TicketId);
        builder.HasIndex(c => c.CreatedAt);
    }
}
