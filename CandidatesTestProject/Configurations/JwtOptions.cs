using System.ComponentModel.DataAnnotations;

namespace CandidatesTestProject.Configurations;

public class JwtOptions
{
    [Required]
    public string SecretKey { get; init; } = null!;
    
    [Required]
    public string Issuer { get; init; } = null!;
    
    [Required]
    public string Audience { get; init; } = null!;
    
    [Required]
    [Range(1, 1440)]
    public int AccessTokenLifetimeMinutes { get; init; } = 60;
    
    [Required]
    [Range(1, 43200)]
    public int RefreshTokenLifetimeMinutes { get; init; } = 10080; // 7 days
}

