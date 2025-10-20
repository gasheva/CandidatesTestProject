using System.ComponentModel.DataAnnotations;

namespace CandidatesTestProject.Configurations.Database;

public class ApplicationDbConnectionSettings
{
    [Required]
    public string Host { get; init; } = "localhost";
    
    [Required]
    public int Port { get; init; } = 5432;
    
    [Required]
    public string Database { get; init; } = "candidatesdb";
    
    [Required]
    public string Username { get; init; } = "postgres";
    
    [Required]
    public string Password { get; init; } = string.Empty;

    public string GetConnectionString()
    {
        return $"Host={Host};Port={Port};Database={Database};Username={Username};Password={Password}";
    }
}

