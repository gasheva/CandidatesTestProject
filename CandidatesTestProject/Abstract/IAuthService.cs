using CandidatesTestProject.Contracts;

namespace CandidatesTestProject.Abstract;

public interface IAuthService
{
    Task<TokenResponse> LoginAsync(LoginDto loginDto, CancellationToken cancellationToken = default);
    Task<TokenResponse> RefreshTokenAsync(RefreshTokenDto refreshTokenDto, CancellationToken cancellationToken = default);
}

