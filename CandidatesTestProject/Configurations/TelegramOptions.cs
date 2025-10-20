using System.ComponentModel.DataAnnotations;

namespace CandidatesTestProject.Configurations;

public class TelegramOptions
{
    [Required]
    public string BotToken { get; init; } = null!;
    
    [Required]
    public string ChatId { get; init; } = null!;
}

