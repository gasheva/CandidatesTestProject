namespace CandidatesTestProject.Models;

public enum EntityType
{
    Candidate = 0,
    Employee = 1
}

public class VerificationEvent
{
    public Guid Id { get; set; }
    public Guid VerificationId { get; set; }
    public EntityType EntityType { get; set; }
    public Guid FoundEntityId { get; set; }

    public Verification Verification { get; set; } = null!;
}

