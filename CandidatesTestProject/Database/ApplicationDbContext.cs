using CandidatesTestProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CandidatesTestProject.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<CandidateData> CandidateData { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<SocialNetwork> SocialNetworks { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Verification> Verifications { get; set; }
    public DbSet<VerificationEvent> VerificationEvents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}

