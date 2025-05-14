using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlgebrakitSDK.Models.Requests;

/// <summary>
/// Request to retrieve existing sessions by their IDs.
/// </summary>
public class SessionRetrieveRequest
{
    /// <summary>
    /// IDs of existing sessions to retrieve.
    /// </summary>
    [JsonPropertyName("sessionIds")]
    public List<string> SessionIds { get; set; } = new();
}
