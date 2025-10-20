using CandidatesTestProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CandidatesTestProject.Database;

public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
{
    public void Configure(EntityTypeBuilder<Candidate> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.CandidateDataId)
            .IsRequired();

        builder.HasIndex(c => c.CandidateDataId)
            .IsUnique();

        builder.Property(c => c.LastUpdatedAt)
            .IsRequired();

        builder.HasIndex(c => c.LastUpdatedAt);

        builder.Property(c => c.WorkSchedule)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(c => c.CreatedByUserId)
            .IsRequired();

        builder.HasIndex(c => c.CreatedByUserId);
    }
}

