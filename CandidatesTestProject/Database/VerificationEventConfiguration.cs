using CandidatesTestProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CandidatesTestProject.Database;

public class VerificationEventConfiguration : IEntityTypeConfiguration<VerificationEvent>
{
    public void Configure(EntityTypeBuilder<VerificationEvent> builder)
    {
        builder.HasKey(ve => ve.Id);

        builder.Property(ve => ve.VerificationId)
            .IsRequired();

        builder.Property(ve => ve.EntityType)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(ve => ve.FoundEntityId)
            .IsRequired();

        builder.HasIndex(ve => new { ve.VerificationId, ve.EntityType, ve.FoundEntityId });
    }
}

