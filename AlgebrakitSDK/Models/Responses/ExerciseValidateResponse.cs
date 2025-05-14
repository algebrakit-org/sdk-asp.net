using System.Collections.Generic;
using System.Text.Json.Serialization;
using AlgebrakitSDK.Models.Shared;

namespace AlgebrakitSDK.Models.Responses;

/// <summary>
/// Response for exercise validation.
/// </summary>
public class ExerciseValidateResponse
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("valid")]
    public bool Valid { get; set; }

    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    [JsonPropertyName("marks")]
    public double? Marks { get; set; }

    [JsonPropertyName("random")]
    public bool? Random { get; set; }

    [JsonPropertyName("interactions")]
    public Dictionary<string, InteractionDescription>? Interactions { get; set; }
}
