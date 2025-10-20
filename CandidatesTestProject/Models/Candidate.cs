namespace CandidatesTestProject.Models;

public class Candidate
{
    public Guid Id { get; set; }
    public Guid CandidateDataId { get; set; }
    public DateTime LastUpdatedAt { get; set; }
    public WorkSchedule WorkSchedule { get; set; }
    public Guid CreatedByUserId { get; set; }

    public CandidateData CandidateData { get; set; } = null!;
    public User CreatedBy { get; set; } = null!;
}

