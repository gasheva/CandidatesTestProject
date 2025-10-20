using CandidatesTestProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CandidatesTestProject.Database;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.CandidateDataId)
            .IsRequired();

        builder.HasIndex(e => e.CandidateDataId)
            .IsUnique();

        builder.Property(e => e.HireDate)
            .IsRequired();

        builder.HasIndex(e => e.HireDate);
    }
}

