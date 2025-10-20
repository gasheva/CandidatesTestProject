using CandidatesTestProject.Contracts;

namespace CandidatesTestProject.Abstract;

public interface ITelegramService
{
    Task SendVerificationResultsAsync(VerificationResultVm result, CancellationToken cancellationToken = default);
}

