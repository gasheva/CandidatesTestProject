using AutoMapper;
using CandidatesTestProject.Abstract;
using CandidatesTestProject.Contracts;
using CandidatesTestProject.Database;
using CandidatesTestProject.Models;
using CandidatesTestProject.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CandidatesTestProject.Services;

public class VerificationService : IVerificationService
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
    private readonly IVerificationRepository _verificationRepository;
    private readonly IUserRepository _userRepository;
    private readonly ITelegramService _telegramService;
    private readonly IMapper _mapper;
    private readonly ILogger<VerificationService> _logger;

    public VerificationService(
        IVerificationRepository verificationRepository,
        IDbContextFactory<ApplicationDbContext> contextFactory,
        IUserRepository userRepository,
        ITelegramService telegramService,
        IMapper mapper,
        ILogger<VerificationService> logger
    )
    {
        _contextFactory = contextFactory;
        _verificationRepository = verificationRepository;
        _userRepository = userRepository;
        _telegramService = telegramService;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<VerificationResultVm> PerformVerificationAsync(
        VerificationRequestDto dto,
        Guid userId,
        CancellationToken cancellationToken = default
    )
    {
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
        if (user == null)
        {
            throw new Exceptions.NotFoundException(nameof(User), userId);
        }

        var verification = _mapper.Map<Verification>(dto);
        verification.PerformedByUserId = userId;

        await _verificationRepository.CreateAsync(verification, cancellationToken);

        var candidatesTask = Task.Run(async () =>
            {
                await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
                var repo = new CandidateRepository(context);
                return await repo.SearchByNameAsync(dto.FirstName, dto.LastName, cancellationToken);
            }
        );

        var employeesTask = Task.Run(async () =>
            {
                await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
                var repo = new EmployeeRepository(context);
                return await repo.SearchByNameAsync(dto.FirstName, dto.LastName, cancellationToken);
            }
        );

        var foundCandidates = await candidatesTask;
        var foundEmployees = await employeesTask;

        _logger.LogInformation(
            "Verification {VerificationId}: Found {CandidateCount} candidates and {EmployeeCount} employees for {FirstName} {LastName}",
            verification.Id,
            foundCandidates.Count,
            foundEmployees.Count,
            dto.FirstName,
            dto.LastName
        );

        var events = new List<VerificationEvent>();

        events.AddRange(
            foundCandidates.Select(c => new VerificationEvent
                {
                    Id = Guid.NewGuid(),
                    EntityType = EntityType.Candidate,
                    FoundEntityId = c.Id
                }
            )
        );

        events.AddRange(
            foundEmployees.Select(e => new VerificationEvent
                {
                    Id = Guid.NewGuid(),
                    EntityType = EntityType.Employee,
                    FoundEntityId = e.Id
                }
            )
        );

        if (events.Any())
        {
            await _verificationRepository.AddEventsAsync(verification.Id, events, cancellationToken);
        }

        var result = new VerificationResultVm(
            Date: verification.Date,
            PerformedBy: user.FullName,
            SearchedFor: $"{dto.FirstName} {dto.LastName}",
            FoundCandidates: _mapper.Map<List<VerificationEventVm>>(foundCandidates),
            FoundEmployees: _mapper.Map<List<VerificationEventVm>>(foundEmployees)
        );

        try
        {
            await _telegramService.SendVerificationResultsAsync(result, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "Failed to send verification results to Telegram for verification {VerificationId}",
                verification.Id
            );
        }

        return result;
    }
}