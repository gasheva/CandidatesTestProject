using CandidatesTestProject.Abstract;
using CandidatesTestProject.Database;
using CandidatesTestProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CandidatesTestProject.Repositories;

public class VerificationRepository : IVerificationRepository
{
    private readonly ApplicationDbContext _context;

    public VerificationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Verification> CreateAsync(Verification verification, CancellationToken cancellationToken = default)
    {
        await _context.Verifications.AddAsync(verification, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return verification;
    }

    public async Task AddEventsAsync(Guid verificationId, List<VerificationEvent> events, CancellationToken cancellationToken = default)
    {
        foreach (var ev in events)
        {
            ev.VerificationId = verificationId;
        }
        
        await _context.VerificationEvents.AddRangeAsync(events, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}

