using System.Text.Json.Serialization;
using AlgebrakitSDK.Models.AkExercise;

namespace AlgebrakitSDK.Models.Requests;

/// <summary>
/// Request to validate an exercise.
/// </summary>
public class ExerciseValidateRequest
{
    [JsonPropertyName("exerciseId")]
    public string? ExerciseId { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }

    [JsonPropertyName("exerciseSpec")]
    public AK_Exercise? ExerciseSpec { get; set; }
}
