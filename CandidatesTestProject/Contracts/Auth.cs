namespace CandidatesTestProject.Contracts;

public record LoginDto(string Login, string Password);

public record TokenResponse(string AccessToken, string RefreshToken);

public record RefreshTokenDto(string RefreshToken);

