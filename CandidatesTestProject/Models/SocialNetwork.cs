namespace CandidatesTestProject.Models;

public class SocialNetwork
{
    public Guid Id { get; set; }
    public Guid CandidateDataId { get; set; }
    public string Username { get; set; } = string.Empty;
    public SocialNetworkType Type { get; set; }
    public DateTime AddedAt { get; set; }

    public CandidateData CandidateData { get; set; } = null!;
}

