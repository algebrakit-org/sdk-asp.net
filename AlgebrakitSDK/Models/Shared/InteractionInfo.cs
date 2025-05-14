using System.Text.Json.Serialization;
using AlgebrakitSDK.Enums;

namespace AlgebrakitSDK.Models.Shared;

/// <summary>
/// Represents detailed information about an interaction.
/// </summary>
public class InteractionInfo
{
    /// <summary>
    /// Unique identifier for the interaction.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Type of the interaction.
    /// </summary>
    [JsonPropertyName("interactionType")]
    public InteractionType InteractionType { get; set; }

    /// <summary>
    /// Content of the interaction.
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    /// <summary>
    /// Solution for the interaction.
    /// </summary>
    [JsonPropertyName("solution")]
    public string Solution { get; set; } = string.Empty;

    /// <summary>
    /// Scoring details for the interaction.
    /// </summary>
    [JsonPropertyName("scoring")]
    public InteractionScoring Scoring { get; set; } = new();
}
