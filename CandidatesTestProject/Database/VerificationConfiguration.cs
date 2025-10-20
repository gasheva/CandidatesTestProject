using CandidatesTestProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CandidatesTestProject.Database;

public class VerificationConfiguration : IEntityTypeConfiguration<Verification>
{
    public void Configure(EntityTypeBuilder<Verification> builder)
    {
        builder.HasKey(v => v.Id);

        builder.Property(v => v.PerformedByUserId)
            .IsRequired();

        builder.Property(v => v.Date)
            .IsRequired();

        builder.HasIndex(v => v.Date);

        builder.Property(v => v.SearchFirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(v => v.SearchLastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(v => v.Events)
            .WithOne(ve => ve.Verification)
            .HasForeignKey(ve => ve.VerificationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

