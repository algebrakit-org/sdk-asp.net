using System.Text.Json.Serialization;
using AlgebrakitSDK.Enums;

namespace AlgebrakitSDK.Models.Shared;

/// <summary>
/// Represents a session in the CreateSessionResponse.
/// </summary>
public class Session
{
    [JsonPropertyName("sessionId")]
    public string SessionId { get; set; } = string.Empty;

    [JsonPropertyName("html")]
    public string Html { get; set; } = string.Empty;

    [JsonPropertyName("marksTotal")]
    public int MarksTotal { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("interactions")]
    public Dictionary<string, InteractionDescription> Interactions { get; set; } = new();
}