using System.Text.Json.Serialization;

namespace AlgebrakitSDK.Models.Requests;

/// <summary>
/// Represents a request to retrieve session scores.
/// </summary>
public class SessionScoreRequest
{
    /// <summary>
    /// Unique identifier for the session to score.
    /// </summary>
    [JsonPropertyName("sessionId")]
    public string SessionId { get; set; } = string.Empty;

    /// <summary>
    /// Indicates if the session should be locked to prevent future changes.
    /// </summary>
    [JsonPropertyName("lockSession")]
    public bool LockSession { get; set; } = false;
}