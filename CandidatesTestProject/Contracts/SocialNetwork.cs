using CandidatesTestProject.Models;

namespace CandidatesTestProject.Contracts;

public record SocialNetworkVm(
    Guid Id,
    string Username,
    SocialNetworkType Type,
    DateTime AddedAt
);

public record CreateSocialNetworkDto(
    string Username,
    SocialNetworkType Type
);

