namespace CandidatesTestProject.Models;

public class Employee
{
    public Guid Id { get; set; }
    public Guid CandidateDataId { get; set; }
    public DateTime HireDate { get; set; }

    public CandidateData CandidateData { get; set; } = null!;
}

