using AutoMapper;
using CandidatesTestProject.Abstract;
using CandidatesTestProject.Contracts;

namespace CandidatesTestProject.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<EmployeeVm?> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var employee = await _employeeRepository.GetByIdAsync(id, cancellationToken);
        return employee != null ? _mapper.Map<EmployeeVm>(employee) : null;
    }
}