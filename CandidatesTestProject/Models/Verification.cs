namespace CandidatesTestProject.Models;

public class Verification
{
    public Guid Id { get; set; }
    public Guid PerformedByUserId { get; set; }
    public DateTime Date { get; set; }
    public string SearchFirstName { get; set; } = string.Empty;
    public string SearchLastName { get; set; } = string.Empty;

    public User PerformedBy { get; set; } = null!;
    public ICollection<VerificationEvent> Events { get; set; } = new List<VerificationEvent>();
}

