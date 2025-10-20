using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using CandidatesTestProject.Abstract;
using CandidatesTestProject.Configurations;
using CandidatesTestProject.Contracts;
using CandidatesTestProject.Exceptions;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CandidatesTestProject.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly JwtOptions _jwtOptions;
    private readonly ILogger<AuthService> _logger;

    public AuthService(
        IUserRepository userRepository,
        IOptions<JwtOptions> jwtOptions,
        ILogger<AuthService> logger
    )
    {
        _userRepository = userRepository;
        _jwtOptions = jwtOptions.Value;
        _logger = logger;
    }

    public async Task<TokenResponse> LoginAsync(LoginDto loginDto, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.FindByLoginAsync(loginDto.Login, cancellationToken);

        if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
        {
            _logger.LogWarning("Failed login attempt for user: {Login}", loginDto.Login);
            throw new UnauthorizedException("Invalid login or password.");
        }

        var accessToken = GenerateAccessToken(user);
        var refreshToken = GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(_jwtOptions.RefreshTokenLifetimeMinutes);

        await _userRepository.UpdateAsync(user, cancellationToken);

        _logger.LogInformation("User {Login} logged in successfully", user.Login);

        return new TokenResponse(accessToken, refreshToken);
    }

    public async Task<TokenResponse> RefreshTokenAsync(
        RefreshTokenDto refreshTokenDto,
        CancellationToken cancellationToken = default
    )
    {
        var user = await _userRepository.FindByRefreshTokenAsync(refreshTokenDto.RefreshToken, cancellationToken);

        if (user == null || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            _logger.LogWarning("Invalid or expired refresh token");
            throw new UnauthorizedException("Invalid or expired refresh token.");
        }

        var accessToken = GenerateAccessToken(user);
        var newRefreshToken = GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(_jwtOptions.RefreshTokenLifetimeMinutes);

        await _userRepository.UpdateAsync(user, cancellationToken);

        _logger.LogInformation("Tokens refreshed successfully for user: {Login}", user.Login);

        return new TokenResponse(accessToken, newRefreshToken);
    }

    private string GenerateAccessToken(Models.User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Login),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(
                JwtRegisteredClaimNames.Jti,
                Guid.NewGuid()
                    .ToString()
            )
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtOptions.AccessTokenLifetimeMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
}