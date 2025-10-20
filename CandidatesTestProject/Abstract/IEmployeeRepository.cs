using CandidatesTestProject.Models;

namespace CandidatesTestProject.Abstract;

public interface IEmployeeRepository
{
    Task<Employee> CreateAsync(Employee employee, CancellationToken cancellationToken = default);
    Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Employee>> SearchByNameAsync(string firstName, string lastName, CancellationToken cancellationToken = default);
}

