using System.Text.Json.Serialization;

namespace AlgebrakitSDK.Models.Shared;

/// <summary>
/// Represents the scoring details for an interaction.
/// </summary>
public class InteractionScoring
{
    /// <summary>
    /// Indicates whether the interaction is finished.
    /// </summary>
    [JsonPropertyName("finished")]
    public bool Finished { get; set; }

    /// <summary>
    /// Total marks available for the interaction.
    /// </summary>
    [JsonPropertyName("marksTotal")]
    public double MarksTotal { get; set; }

    /// <summary>
    /// Marks earned in the interaction.
    /// </summary>
    [JsonPropertyName("marksEarned")]
    public double MarksEarned { get; set; }

    /// <summary>
    /// Penalties applied during the interaction.
    /// </summary>
    [JsonPropertyName("penalties")]
    public Penalties? Penalties { get; set; }
}

/// <summary>
/// Represents penalties applied during an interaction.
/// </summary>
public class Penalties
{
    /// <summary>
    /// Total marks deducted as a penalty.
    /// </summary>
    [JsonPropertyName("marksPenalty")]
    public double MarksPenalty { get; set; }

    /// <summary>
    /// Number of hints requested.
    /// </summary>
    [JsonPropertyName("hintsRequested")]
    public int HintsRequested { get; set; }

    /// <summary>
    /// Number of mathematical errors made.
    /// </summary>
    [JsonPropertyName("mathErrors")]
    public int MathErrors { get; set; }

    /// <summary>
    /// Number of notation errors made.
    /// </summary>
    [JsonPropertyName("notationErrors")]
    public int NotationErrors { get; set; }
}