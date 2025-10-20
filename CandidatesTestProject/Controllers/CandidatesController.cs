using System.Security.Claims;
using CandidatesTestProject.Abstract;
using CandidatesTestProject.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CandidatesTestProject.Controllers;

/// <summary>
/// Candidates management controller
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class CandidatesController : ControllerBase
{
    private readonly ICandidateService _candidateService;

    public CandidatesController(ICandidateService candidateService)
    {
        _candidateService = candidateService;
    }

    /// <summary>
    /// Get paginated list of candidates with filters
    /// </summary>
    /// <param name="pageNumber">Page number (default: 1)</param>
    /// <param name="pageSize">Page size (default: 10)</param>
    /// <param name="search">Search by name, email, or social network username</param>
    /// <param name="sortByLastUpdatedDescending">Sort by last updated date descending</param>
    /// <param name="workSchedules">Filter by work schedules (comma-separated: 0=Office, 1=Hybrid, 2=Remote)</param>
    /// <param name="onlyMine">Show only candidates created by current user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Paginated list of candidates</returns>
    [HttpGet]
    [ProducesResponseType(typeof(PagedList<CandidateListVm>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PagedList<CandidateListVm>>> GetCandidates(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? search = null,
        [FromQuery] bool? sortByLastUpdatedDescending = null,
        [FromQuery] string? workSchedules = null,
        [FromQuery] bool onlyMine = false,
        CancellationToken cancellationToken = default)
    {
        var userId = GetUserId();
        
        var workScheduleList = string.IsNullOrWhiteSpace(workSchedules)
            ? null
            : workSchedules.Split(',')
                .Select(s => (Models.WorkSchedule)int.Parse(s.Trim()))
                .ToList();

        var filter = new CandidateFilterDto(
            search,
            sortByLastUpdatedDescending,
            workScheduleList,
            onlyMine
        );

        var result = await _candidateService.GetCandidatesPagedAsync(
            pageNumber, 
            pageSize, 
            filter,
            userId,
            cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Create a new candidate
    /// </summary>
    /// <param name="dto">Candidate data</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Created candidate</returns>
    [HttpPost]
    [ProducesResponseType(typeof(CandidateVm), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CandidateVm>> CreateCandidate(
        [FromBody] CreateCandidateDto dto,
        CancellationToken cancellationToken)
    {
        var userId = GetUserId();
        var result = await _candidateService.CreateCandidateAsync(userId, dto, cancellationToken);
        return CreatedAtAction(nameof(GetCandidates), new { id = result.Id }, result);
    }

    /// <summary>
    /// Update an existing candidate
    /// </summary>
    /// <param name="id">Candidate ID</param>
    /// <param name="dto">Updated candidate data</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Updated candidate</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(CandidateVm), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CandidateVm>> UpdateCandidate(
        Guid id,
        [FromBody] UpdateCandidateDto dto,
        CancellationToken cancellationToken)
    {
        var result = await _candidateService.UpdateCandidateAsync(id, dto, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Promote candidate to employee
    /// </summary>
    /// <param name="id">Candidate ID</param>
    /// <param name="dto">Employee hire data</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Created employee</returns>
    [HttpPost("{id}/promote")]
    [ProducesResponseType(typeof(EmployeeVm), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmployeeVm>> PromoteToEmployee(
        Guid id,
        [FromBody] PromoteToEmployeeDto dto,
        CancellationToken cancellationToken)
    {
        var result = await _candidateService.PromoteToEmployeeAsync(id, dto, cancellationToken);
        return Ok(result);
    }

    private Guid GetUserId()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Guid.Parse(userIdClaim!);
    }
}

