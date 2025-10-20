using CandidatesTestProject.Models;

namespace CandidatesTestProject.Contracts;

public record VerificationRequestDto(
    string FirstName,
    string LastName
);

public record VerificationEventVm(
    EntityType EntityType,
    Guid FoundEntityId,
    string FullName,
    string Email
);

public record VerificationResultVm(
    DateTime Date,
    string PerformedBy,
    string SearchedFor,
    List<VerificationEventVm> FoundCandidates,
    List<VerificationEventVm> FoundEmployees
);

