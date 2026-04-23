using Microsoft.AspNetCore.Mvc.RazorPages;
using AlgebrakitSDK.Services;
using AlgebrakitSDK.Models.Requests;
using AlgebrakitSDK.Models.Shared;

namespace PlayExercise.Pages;

public class IndexModel : PageModel
{
    private readonly AppConfig _config;

    public IndexModel(AppConfig config)
    {
        _config = config;
    }

    public string WidgetScriptUrl => _config.WidgetUrl;
    public string? ExerciseHtml { get; private set; }
    public string? Error { get; private set; }

    public async Task OnGetAsync()
    {
        try
        {
            using var httpClient = new HttpClient { BaseAddress = new Uri(_config.ApiUrl) };
            var sessionService = new SessionService(httpClient, _config.ApiKey);

            var response = await sessionService.CreateSessionAsync(
                new CreateSessionRequest
                {
                    Exercises = new List<Exercise>
                    {
                        new ExerciseById { ExerciseId = _config.ExerciseId, Version = "latest" }
                    }
                }
            );

            if (response != null && response.Any() && response[0].Success && response[0].Sessions.Any())
            {
                ExerciseHtml = response[0].Sessions[0].Html;
            }
            else
            {
                Error = response?[0]?.Msg ?? "Unknown error creating session";
            }
        }
        catch (Exception ex)
        {
            Error = ex.Message;
        }
    }
}
