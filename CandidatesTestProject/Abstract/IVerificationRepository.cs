using CandidatesTestProject.Models;

namespace CandidatesTestProject.Abstract;

public interface IVerificationRepository
{
    Task<Verification> CreateAsync(Verification verification, CancellationToken cancellationToken = default);
    Task AddEventsAsync(Guid verificationId, List<VerificationEvent> events, CancellationToken cancellationToken = default);
}

