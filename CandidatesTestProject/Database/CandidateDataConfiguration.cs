using CandidatesTestProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CandidatesTestProject.Database;

public class CandidateDataConfiguration : IEntityTypeConfiguration<CandidateData>
{
    public void Configure(EntityTypeBuilder<CandidateData> builder)
    {
        builder.HasKey(cd => cd.Id);

        builder.Property(cd => cd.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(cd => cd.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(cd => cd.MiddleName)
            .HasMaxLength(100);

        builder.Property(cd => cd.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasIndex(cd => cd.Email);

        builder.Property(cd => cd.Phone)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(cd => cd.Country)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(cd => cd.DateOfBirth)
            .IsRequired();

        builder.HasMany(cd => cd.SocialNetworks)
            .WithOne(sn => sn.CandidateData)
            .HasForeignKey(sn => sn.CandidateDataId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cd => cd.Candidate)
            .WithOne(c => c.CandidateData)
            .HasForeignKey<Candidate>(c => c.CandidateDataId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cd => cd.Employee)
            .WithOne(e => e.CandidateData)
            .HasForeignKey<Employee>(e => e.CandidateDataId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

