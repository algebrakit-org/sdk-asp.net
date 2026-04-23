var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddHttpClient("AlgebraKit");

// ============================================================
// CONFIGURATION - Update these values before running the demo
// ============================================================
var config = new PlayExercise.AppConfig
{
    ApiKey     = "your-api-key-here", // Replace with your actual API key
    ApiUrl     = "https://api.algebrakit.com",
    WidgetUrl  = "https://widgets.algebrakit.com",
    ExerciseId = "fa42e943-8213-41a6-8a91-8c22a929ffe9",
};

builder.Services.AddSingleton(config);

var app = builder.Build();

app.MapRazorPages();

// Proxy: forwards widget requests to the AlgebraKit API with the API key attached.
app.Map("/proxy/algebrakit/{**path}", async (HttpContext ctx, string path, IHttpClientFactory factory) =>
{
    var client = factory.CreateClient("AlgebraKit");
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
