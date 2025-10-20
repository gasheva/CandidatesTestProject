namespace CandidatesTestProject.Contracts;

public record EmployeeVm(
    Guid Id,
    string FirstName,
    string LastName,
    string? MiddleName,
    string Email,
    string Phone,
    string Country,
    DateOnly DateOfBirth,
    List<SocialNetworkVm> SocialNetworks,
    DateTime HireDate
);

public record PromoteToEmployeeDto(DateTime HireDate);

