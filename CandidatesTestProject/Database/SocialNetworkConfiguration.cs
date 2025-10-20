using CandidatesTestProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CandidatesTestProject.Database;

public class SocialNetworkConfiguration : IEntityTypeConfiguration<SocialNetwork>
{
    public void Configure(EntityTypeBuilder<SocialNetwork> builder)
    {
        builder.HasKey(sn => sn.Id);

        builder.Property(sn => sn.CandidateDataId)
            .IsRequired();

        builder.Property(sn => sn.Username)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasIndex(sn => sn.Username);

        builder.Property(sn => sn.Type)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(sn => sn.AddedAt)
            .IsRequired();

        builder.HasIndex(sn => new { sn.CandidateDataId, sn.Type, sn.Username });
    }
}

