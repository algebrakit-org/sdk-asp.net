using System.Text.Json.Serialization;

namespace AlgebrakitSDK.Models.Requests;

/// <summary>
/// Represents a request to lock or unlock sessions.
/// </summary>
public class SessionLockRequest
{
    /// <summary>
    /// Action to perform on the sessions (LOCK, UNLOCK, FINALIZE).
    /// </summary>
    [JsonPropertyName("action")]
    public string Action { get; set; } = string.Empty;

    /// <summary>
    /// List of session IDs to lock or unlock.
    /// </summary>
    [JsonPropertyName("sessionIds")]
    public List<string> SessionIds { get; set; } = new();
}