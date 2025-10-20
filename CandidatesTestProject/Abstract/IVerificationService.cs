using CandidatesTestProject.Contracts;

namespace CandidatesTestProject.Abstract;

public interface IVerificationService
{
    Task<VerificationResultVm> PerformVerificationAsync(
        VerificationRequestDto dto, 
        Guid userId, 
        CancellationToken cancellationToken = default);
}

