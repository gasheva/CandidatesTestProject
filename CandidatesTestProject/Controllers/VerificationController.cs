using System.Security.Claims;
using CandidatesTestProject.Abstract;
using CandidatesTestProject.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CandidatesTestProject.Controllers;

/// <summary>
/// Verification controller for checking duplicates
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class VerificationController : ControllerBase
{
    private readonly IVerificationService _verificationService;

    public VerificationController(IVerificationService verificationService)
    {
        _verificationService = verificationService;
    }

    /// <summary>
    /// Check for existing candidates and employees by name
    /// </summary>
    /// <param name="dto">Search criteria (first and last name)</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Verification results with found candidates and employees</returns>
    /// <remarks>
    /// This endpoint performs parallel search across candidates and employees databases
    /// and sends the results to the configured Telegram group.
    /// </remarks>
    [HttpPost("check")]
    [ProducesResponseType(typeof(VerificationResultVm), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<VerificationResultVm>> CheckDuplicates(
        [FromBody] VerificationRequestDto dto,
        CancellationToken cancellationToken)
    {
        var userId = GetUserId();
        var result = await _verificationService.PerformVerificationAsync(dto, userId, cancellationToken);
        return Ok(result);
    }

    private Guid GetUserId()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Guid.Parse(userIdClaim!);
    }
}

