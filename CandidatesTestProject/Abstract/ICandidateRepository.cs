using CandidatesTestProject.Contracts;
using CandidatesTestProject.Models;

namespace CandidatesTestProject.Abstract;

public interface ICandidateRepository
{
    Task<Candidate> CreateAsync(Candidate candidate, CancellationToken cancellationToken = default);
    Task<Candidate?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Candidate> UpdateAsync(Candidate candidate, CancellationToken cancellationToken = default);
    Task DeleteAsync(Candidate candidate, CancellationToken cancellationToken = default);
    Task<PagedList<Candidate>> GetPagedAsync(
        int pageNumber, 
        int pageSize, 
        CandidateFilterDto filter,
        Guid? userId = null,
        CancellationToken cancellationToken = default);
    Task<List<Candidate>> SearchByNameAsync(string firstName, string lastName, CancellationToken cancellationToken = default);
}

