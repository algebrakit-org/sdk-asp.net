using System.Text.Json.Serialization;

namespace AlgebrakitSDK.Models.Requests;

/// <summary>
/// Represents a request to retrieve session information.
/// </summary>
public class SessionInfoRequest
{
    /// <summary>
    /// Unique identifier for the session to retrieve information for.
    /// </summary>
    [JsonPropertyName("sessionId")]
    public string SessionId { get; set; } = string.Empty;
}