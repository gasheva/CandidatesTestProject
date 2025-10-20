using CandidatesTestProject.Contracts;

namespace CandidatesTestProject.Abstract;

public interface IEmployeeService
{
    Task<EmployeeVm?> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken = default);
}

