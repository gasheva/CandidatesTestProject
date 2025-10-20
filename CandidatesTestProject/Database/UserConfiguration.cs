using CandidatesTestProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CandidatesTestProject.Database;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.FullName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(u => u.Login)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(u => u.Login)
            .IsUnique();

        builder.Property(u => u.PasswordHash)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.Role)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.CreatedAt)
            .IsRequired();

        builder.Property(u => u.RefreshToken)
            .HasMaxLength(500);

        builder.HasMany(u => u.CreatedCandidates)
            .WithOne(c => c.CreatedBy)
            .HasForeignKey(c => c.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.PerformedVerifications)
            .WithOne(v => v.PerformedBy)
            .HasForeignKey(v => v.PerformedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

