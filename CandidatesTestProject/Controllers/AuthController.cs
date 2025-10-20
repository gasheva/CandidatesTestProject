using CandidatesTestProject.Abstract;
using CandidatesTestProject.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CandidatesTestProject.Controllers;

/// <summary>
/// Authentication and authorization controller
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Login and obtain access and refresh tokens
    /// </summary>
    /// <param name="loginDto">Login credentials</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Access and refresh tokens</returns>
    [HttpPost("login")]
    [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<TokenResponse>> Login(
        [FromBody] LoginDto loginDto,
        CancellationToken cancellationToken)
    {
        var result = await _authService.LoginAsync(loginDto, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Refresh access token using refresh token
    /// </summary>
    /// <param name="refreshTokenDto">Refresh token</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>New access and refresh tokens</returns>
    [HttpPost("refresh")]
    [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<TokenResponse>> RefreshToken(
        [FromBody] RefreshTokenDto refreshTokenDto,
        CancellationToken cancellationToken)
    {
        var result = await _authService.RefreshTokenAsync(refreshTokenDto, cancellationToken);
        return Ok(result);
    }
}

