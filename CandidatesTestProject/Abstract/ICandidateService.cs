using CandidatesTestProject.Contracts;

namespace CandidatesTestProject.Abstract;

public interface ICandidateService
{
    Task<CandidateVm> CreateCandidateAsync(Guid userId, CreateCandidateDto dto, CancellationToken cancellationToken = default);
    Task<CandidateVm> UpdateCandidateAsync(Guid id, UpdateCandidateDto dto, CancellationToken cancellationToken = default);
    Task<PagedList<CandidateListVm>> GetCandidatesPagedAsync(
        int pageNumber, 
        int pageSize, 
        CandidateFilterDto filter,
        Guid? userId = null,
        CancellationToken cancellationToken = default);
    Task<EmployeeVm> PromoteToEmployeeAsync(Guid candidateId, PromoteToEmployeeDto dto, CancellationToken cancellationToken = default);
}

