var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddHttpClient("Algebrakit");

// ============================================================
// CONFIGURATION - Update these values before running the demo
// ============================================================
// The API key is read from configuration, which includes the
// ALGEBRAKIT_API_KEY environment variable (and appsettings/user-secrets).
var config = new PlayExercise.AppConfig
{
    ApiKey     = builder.Configuration["ALGEBRAKIT_API_KEY"]
                 ?? throw new InvalidOperationException(
                     "Set the ALGEBRAKIT_API_KEY environment variable before running the demo."),
    ApiUrl     = "https://api.algebrakit.com",
    WidgetUrl  = "https://widgets.algebrakit.com",
    ExerciseId = "fa42e943-8213-41a6-8a91-8c22a929ffe9",
};

builder.Services.AddSingleton(config);

var app = builder.Build();

app.MapRazorPages();

// Proxy: forwards widget requests to the Algebrakit API with the API key attached.
app.Map("/proxy/algebrakit/{**path}", async (HttpContext ctx, string path, IHttpClientFactory factory) =>
{
    var client = factory.CreateClient("Algebrakit");
    var targetUrl = $"{config.ApiUrl}/{path}";

    var request = new HttpRequestMessage(new HttpMethod(ctx.Request.Method), targetUrl);
    request.Headers.Add("x-api-key", config.ApiKey);

    if (ctx.Request.Method != "GET" && ctx.Request.Method != "HEAD")
    {
        request.Content = new StreamContent(ctx.Request.Body);
        request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(
            ctx.Request.ContentType ?? "application/json");
    }

    var response = await client.SendAsync(request);
    ctx.Response.StatusCode = (int)response.StatusCode;
    ctx.Response.ContentType = response.Content.Headers.ContentType?.ToString() ?? "application/json";
    await response.Content.CopyToAsync(ctx.Response.Body);
});

app.Run();

namespace PlayExercise
{
    public class AppConfig
    {
        public required string ApiKey { get; init; }
        public required string ApiUrl { get; init; }
        public required string WidgetUrl { get; init; }
        public required string ExerciseId { get; init; }
    }
}
