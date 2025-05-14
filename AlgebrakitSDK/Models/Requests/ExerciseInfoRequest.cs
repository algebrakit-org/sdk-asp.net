using System.Text.Json.Serialization;

namespace AlgebrakitSDK.Models.Requests;

/// <summary>
/// Request to retrieve information about an exercise.
/// </summary>
public class ExerciseInfoRequest
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;
}
