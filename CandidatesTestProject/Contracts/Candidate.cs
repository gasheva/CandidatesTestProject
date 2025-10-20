using CandidatesTestProject.Models;

namespace CandidatesTestProject.Contracts;

public record CandidateVm(
    Guid Id,
    string FirstName,
    string LastName,
    string? MiddleName,
    string Email,
    string Phone,
    string Country,
    DateOnly DateOfBirth,
    List<SocialNetworkVm> SocialNetworks,
    DateTime LastUpdatedAt,
    WorkSchedule WorkSchedule,
    Guid CreatedByUserId
);

public record CandidateListVm(
    Guid Id,
    string FirstName,
    string LastName,
    string? MiddleName,
    string Email,
    DateTime LastUpdatedAt,
    WorkSchedule WorkSchedule
);

public record CreateCandidateDto(
    string FirstName,
    string LastName,
    string? MiddleName,
    string Email,
    string Phone,
    string Country,
    DateOnly DateOfBirth,
    List<CreateSocialNetworkDto> SocialNetworks,
    WorkSchedule WorkSchedule
);

public record UpdateCandidateDto(
    string FirstName,
    string LastName,
    string? MiddleName,
    string Email,
    string Phone,
    string Country,
    DateOnly DateOfBirth,
    List<CreateSocialNetworkDto> SocialNetworks,
    WorkSchedule WorkSchedule
);

public record CandidateFilterDto(
    string? Search,
    bool? SortByLastUpdatedDescending,
    List<WorkSchedule>? WorkSchedules,
    bool OnlyMine
);

public record ListOfCandidates(List<CandidateListVm> Candidates);

public record PagedList<T>(
    List<T> Items,
    int PageNumber,
    int PageSize,
    int TotalCount,
    int TotalPages
);

