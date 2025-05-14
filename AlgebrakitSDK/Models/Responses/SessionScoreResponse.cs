namespace AlgebrakitSDK.Models.Responses;

using AlgebrakitSDK.Models.Shared;
using System.Text.Json.Serialization;

/// <summary>
/// Represents a response containing session scores.
/// </summary>
public class SessionScoreResponse
{
    /// <summary>
    /// List of questions and their results.
    /// </summary>
    [JsonPropertyName("questions")]
    public List<QuestionResult> Questions { get; set; } = new();

    /// <summary>
    /// Scoring details for the session.
    /// </summary>
    [JsonPropertyName("scoring")]
    public InteractionScoring Scoring { get; set; } = new();

    /// <summary>
    /// Descriptions of tags for this session.
    /// </summary>
    [JsonPropertyName("tagDescriptions")]
    public TagDescriptions TagDescriptions { get; set; } = new();
}