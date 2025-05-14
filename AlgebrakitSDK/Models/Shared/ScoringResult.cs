using System.Text.Json.Serialization;

namespace AlgebrakitSDK.Models.Shared;

/// <summary>
/// Represents the scoring result of a question or interaction.
/// </summary>
public class ScoringResult
{
    [JsonPropertyName("finished")]
    public bool Finished { get; set; }

    [JsonPropertyName("marksTotal")]
    public double MarksTotal { get; set; }

    [JsonPropertyName("marksEarned")]
    public double MarksEarned { get; set; }
}