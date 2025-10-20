using System.Text;
using CandidatesTestProject.Abstract;
using CandidatesTestProject.Configurations;
using CandidatesTestProject.Contracts;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace CandidatesTestProject.Services;

public class TelegramService : ITelegramService
{
    private readonly TelegramBotClient _botClient;
    private readonly TelegramOptions _telegramOptions;
    private readonly ILogger<TelegramService> _logger;

    public TelegramService(
        TelegramBotClient botClient,
        IOptions<TelegramOptions> telegramOptions,
        ILogger<TelegramService> logger
    )
    {
        _botClient = botClient;
        _telegramOptions = telegramOptions.Value;
        _logger = logger;
    }

    public async Task SendVerificationResultsAsync(
        VerificationResultVm result,
        CancellationToken cancellationToken = default
    )
    {
        var message = FormatVerificationMessage(result);

        try
        {
            await _botClient.SendMessage(
                chatId: _telegramOptions.ChatId,
                text: message,
                parseMode: ParseMode.Html,
                cancellationToken: cancellationToken
            );

            _logger.LogInformation(
                "Verification results sent to Telegram for search: {SearchedFor}",
                result.SearchedFor
            );
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to send message to Telegram");
            throw;
        }
    }

    private string FormatVerificationMessage(VerificationResultVm result)
    {
        var sb = new StringBuilder();

        sb.AppendLine("<b>Verification Results</b>");
        sb.AppendLine();
        sb.AppendLine($"<b>Date:</b> {result.Date:yyyy-MM-dd HH:mm:ss} UTC");
        sb.AppendLine($"<b>Performed by:</b> {result.PerformedBy}");
        sb.AppendLine($"<b>Searched for:</b> {result.SearchedFor}");
        sb.AppendLine();

        if (result.FoundCandidates.Any())
        {
            sb.AppendLine($"<b>Found Candidates ({result.FoundCandidates.Count}):</b>");
            foreach (var candidate in result.FoundCandidates)
            {
                sb.AppendLine($"  - {candidate.FullName}");
                sb.AppendLine($"    Email: {candidate.Email}");
                sb.AppendLine($"    ID: <code>{candidate.FoundEntityId}</code>");
            }

            sb.AppendLine();
        }
        else
        {
            sb.AppendLine("<b>Found Candidates:</b> None");
            sb.AppendLine();
        }

        if (result.FoundEmployees.Any())
        {
            sb.AppendLine($"<b>Found Employees ({result.FoundEmployees.Count}):</b>");
            foreach (var employee in result.FoundEmployees)
            {
                sb.AppendLine($"  - {employee.FullName}");
                sb.AppendLine($"    Email: {employee.Email}");
                sb.AppendLine($"    ID: <code>{employee.FoundEntityId}</code>");
            }
        }
        else
        {
            sb.AppendLine("<b>Found Employees:</b> None");
        }

        return sb.ToString();
    }
}