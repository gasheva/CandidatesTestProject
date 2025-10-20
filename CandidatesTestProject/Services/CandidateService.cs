using AutoMapper;
using CandidatesTestProject.Abstract;
using CandidatesTestProject.Contracts;
using CandidatesTestProject.Database;
using CandidatesTestProject.Exceptions;
using CandidatesTestProject.Models;

namespace CandidatesTestProject.Services;

public class CandidateService : ICandidateService
{
    private readonly ICandidateRepository _candidateRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CandidateService> _logger;
    private readonly ApplicationDbContext _context;

    public CandidateService(
        ICandidateRepository candidateRepository,
        IEmployeeRepository employeeRepository,
        ApplicationDbContext context,
        IMapper mapper,
        ILogger<CandidateService> logger
    )
    {
        _candidateRepository = candidateRepository;
        _employeeRepository = employeeRepository;
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<CandidateVm> CreateCandidateAsync(
        Guid userId,
        CreateCandidateDto dto,
        CancellationToken cancellationToken = default
    )
    {
        var candidate = _mapper.Map<Candidate>(dto);
        candidate.CreatedByUserId = userId;

        var createdCandidate = await _candidateRepository.CreateAsync(candidate, cancellationToken);

        _logger.LogInformation("Candidate created: {CandidateId} by user {UserId}", createdCandidate.Id, userId);

        return _mapper.Map<CandidateVm>(createdCandidate);
    }

    public async Task<CandidateVm> UpdateCandidateAsync(
        Guid id,
        UpdateCandidateDto dto,
        CancellationToken cancellationToken = default
    )
    {
        var candidate = await _candidateRepository.GetByIdAsync(id, cancellationToken);

        if (candidate == null)
        {
            throw new NotFoundException(nameof(Candidate), id);
        }

        _mapper.Map(dto, candidate);
        _mapper.Map(dto, candidate.CandidateData);

        var updatedCandidate = await _candidateRepository.UpdateAsync(candidate, cancellationToken);

        _logger.LogInformation("Candidate updated: {CandidateId}", candidate.Id);

        return _mapper.Map<CandidateVm>(updatedCandidate);
    }

    public async Task<PagedList<CandidateListVm>> GetCandidatesPagedAsync(
        int pageNumber,
        int pageSize,
        CandidateFilterDto filter,
        Guid? userId = null,
        CancellationToken cancellationToken = default
    )
    {
        var pagedCandidates = await _candidateRepository.GetPagedAsync(
            pageNumber,
            pageSize,
            filter,
            filter.OnlyMine ? userId : null,
            cancellationToken
        );

        var candidateListVms = _mapper.Map<List<CandidateListVm>>(pagedCandidates.Items);

        return new PagedList<CandidateListVm>(
            candidateListVms,
            pagedCandidates.PageNumber,
            pagedCandidates.PageSize,
            pagedCandidates.TotalCount,
            pagedCandidates.TotalPages
        );
    }

    public async Task<EmployeeVm> PromoteToEmployeeAsync(
        Guid candidateId,
        PromoteToEmployeeDto dto,
        CancellationToken cancellationToken = default
    )
    {
        var candidate = await _candidateRepository.GetByIdAsync(candidateId, cancellationToken);

        if (candidate == null)
        {
            throw new NotFoundException(nameof(Candidate), candidateId);
        }

        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);


        try
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                CandidateDataId = candidate.CandidateDataId,
                HireDate = dto.HireDate
            };

            var createdEmployee = await _employeeRepository.CreateAsync(employee, cancellationToken);
            await _candidateRepository.DeleteAsync(candidate, cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            _logger.LogInformation(
                "Candidate {CandidateId} promoted to employee {EmployeeId}",
                candidateId,
                employee.Id
            );

            return _mapper.Map<EmployeeVm>(createdEmployee);
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}