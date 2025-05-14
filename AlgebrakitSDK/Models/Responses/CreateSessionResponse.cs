using System.Text.Json.Serialization;

namespace AlgebrakitSDK.Models.Responses;

using AlgebrakitSDK.Models.Shared;

/// <summary>
/// Represents a single item in the CreateSessionResponse array.
/// </summary>
public class CreateSessionResponseItem
{
    /// <summary>
    /// Indicates if the request was successful.
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// Error message if the request failed.
    /// </summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>
    /// List of created sessions.
    /// </summary>
    [JsonPropertyName("sessions")]
    public List<Session> Sessions { get; set; } = new();
}

/// <summary>
/// Represents the response for session creation, which is an array of CreateSessionResponseItem.
/// </summary>
public class CreateSessionResponse : List<CreateSessionResponseItem>
{
}