using CandidatesTestProject.Abstract;
using CandidatesTestProject.Database;
using CandidatesTestProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CandidatesTestProject.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Employee> CreateAsync(Employee employee, CancellationToken cancellationToken = default)
    {
        await _context.Employees.AddAsync(employee, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return employee;
    }

    public async Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Employees
            .Include(e => e.CandidateData)
                .ThenInclude(cd => cd.SocialNetworks)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<List<Employee>> SearchByNameAsync(string firstName, string lastName, CancellationToken cancellationToken = default)
    {
        var firstNameLower = firstName.ToLower();
        var lastNameLower = lastName.ToLower();

        return await _context.Employees
            .Include(e => e.CandidateData)
                .ThenInclude(cd => cd.SocialNetworks)
            .Where(e => 
                e.CandidateData.FirstName.ToLower().Contains(firstNameLower) &&
                e.CandidateData.LastName.ToLower().Contains(lastNameLower))
            .ToListAsync(cancellationToken);
    }
}

