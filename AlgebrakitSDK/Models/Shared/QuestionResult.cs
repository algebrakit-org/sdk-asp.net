using System.Text.Json.Serialization;

namespace AlgebrakitSDK.Models.Shared;

/// <summary>
/// Represents the result of a question in a session.
/// </summary>
public class QuestionResult
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("scoring")]
    public ScoringResult Scoring { get; set; } = new();
}