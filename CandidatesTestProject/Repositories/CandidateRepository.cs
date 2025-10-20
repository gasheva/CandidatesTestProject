using CandidatesTestProject.Abstract;
using CandidatesTestProject.Contracts;
using CandidatesTestProject.Database;
using CandidatesTestProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CandidatesTestProject.Repositories;

public class CandidateRepository : ICandidateRepository
{
    private readonly ApplicationDbContext _context;

    public CandidateRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Candidate> CreateAsync(Candidate candidate, CancellationToken cancellationToken = default)
    {
        await _context.Candidates.AddAsync(candidate, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return candidate;
    }

    public async Task<Candidate?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Candidates
            .Include(c => c.CandidateData)
                .ThenInclude(cd => cd.SocialNetworks)
            .Include(c => c.CreatedBy)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public async Task<Candidate> UpdateAsync(Candidate candidate, CancellationToken cancellationToken = default)
    {
        var entries = _context.ChangeTracker.Entries<SocialNetwork>()
            .Where(e => e.State == EntityState.Modified && e.Entity.CandidateDataId == candidate.CandidateDataId)
            .ToList();
        
        foreach (var entry in entries)
        {
            var existsInDb = await _context.SocialNetworks
                .AsNoTracking()
                .AnyAsync(sn => sn.Id == entry.Entity.Id, cancellationToken);
        
            if (!existsInDb)
            {
                entry.State = EntityState.Added;
            }
        }

        await _context.SaveChangesAsync(cancellationToken);
        return candidate;
    }

    public async Task DeleteAsync(Candidate candidate, CancellationToken cancellationToken = default)
    {
        _context.Candidates.Remove(candidate);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<PagedList<Candidate>> GetPagedAsync(
        int pageNumber, 
        int pageSize, 
        CandidateFilterDto filter,
        Guid? userId = null,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Candidates
            .Include(c => c.CandidateData)
                .ThenInclude(cd => cd.SocialNetworks)
            .AsNoTracking();

        if (filter.OnlyMine && userId.HasValue)
        {
            query = query.Where(c => c.CreatedByUserId == userId.Value);
        }

        if (!string.IsNullOrWhiteSpace(filter.Search))
        {
            var searchLower = filter.Search.ToLower();
            query = query.Where(c => 
                c.CandidateData.FirstName.ToLower().Contains(searchLower) ||
                c.CandidateData.LastName.ToLower().Contains(searchLower) ||
                (c.CandidateData.MiddleName != null && c.CandidateData.MiddleName.ToLower().Contains(searchLower)) ||
                c.CandidateData.Email.ToLower().Contains(searchLower) ||
                c.CandidateData.SocialNetworks.Any(sn => sn.Username.ToLower().Contains(searchLower))
            );
        }

        if (filter.WorkSchedules != null && filter.WorkSchedules.Any())
        {
            query = query.Where(c => filter.WorkSchedules.Contains(c.WorkSchedule));
        }

        if (filter.SortByLastUpdatedDescending.HasValue && filter.SortByLastUpdatedDescending.Value)
        {
            query = query.OrderByDescending(c => c.LastUpdatedAt);
        }
        else
        {
            query = query.OrderBy(c => c.LastUpdatedAt);
        }

        var totalCount = await query.CountAsync(cancellationToken);
        
        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

        return new PagedList<Candidate>(items, pageNumber, pageSize, totalCount, totalPages);
    }

    public async Task<List<Candidate>> SearchByNameAsync(string firstName, string lastName, CancellationToken cancellationToken = default)
    {
        var firstNameLower = firstName.ToLower();
        var lastNameLower = lastName.ToLower();

        return await _context.Candidates
            .Include(c => c.CandidateData)
                .ThenInclude(cd => cd.SocialNetworks)
            .Where(c => 
                c.CandidateData.FirstName.ToLower().Contains(firstNameLower) &&
                c.CandidateData.LastName.ToLower().Contains(lastNameLower))
            .ToListAsync(cancellationToken);
    }
}

