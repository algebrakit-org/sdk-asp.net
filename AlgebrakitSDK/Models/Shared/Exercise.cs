using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlgebrakitSDK.Models.Shared;

/// <summary>
/// Represents an exercise in the CreateSessionRequest.
/// </summary>
[JsonConverter(typeof(ExerciseJsonConverter))]
public abstract class Exercise
{
    // Base class for polymorphic serialization
}

/// <summary>
/// Represents an exercise specified by exerciseId.
/// </summary>
public class ExerciseById : Exercise
{
    [JsonPropertyName("exerciseId")]
    public string ExerciseId { get; set; } = string.Empty;

    [JsonPropertyName("version")]
    public string Version { get; set; } = "latest";
}

/// <summary>
/// Represents an exercise specified by exerciseSpec.
/// </summary>
public class ExerciseBySpec : Exercise
{
    [JsonPropertyName("exerciseSpec")]
    public object ExerciseSpec { get; set; } = new();
}

/// <summary>
/// Represents an exercise specified by sessionId.
/// </summary>
public class ExerciseBySession : Exercise
{
    [JsonPropertyName("sessionId")]
    public string SessionId { get; set; } = string.Empty;
}

/// <summary>
/// Custom JSON converter for Exercise polymorphism.
/// </summary>
public class ExerciseJsonConverter : JsonConverter<Exercise>
{
    public override Exercise Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDoc = JsonDocument.ParseValue(ref reader);
        var root = jsonDoc.RootElement;

        if (root.TryGetProperty("exerciseId", out _))
        {
            return JsonSerializer.Deserialize<ExerciseById>(root.GetRawText(), options) ?? throw new JsonException("Failed to deserialize ExerciseById.");
        }
        else if (root.TryGetProperty("exerciseSpec", out _))
        {
            return JsonSerializer.Deserialize<ExerciseBySpec>(root.GetRawText(), options) ?? throw new JsonException("Failed to deserialize ExerciseBySpec.");
        }
        else if (root.TryGetProperty("sessionId", out _))
        {
            return JsonSerializer.Deserialize<ExerciseBySession>(root.GetRawText(), options) ?? throw new JsonException("Failed to deserialize ExerciseBySession.");
        }

        throw new JsonException("Invalid Exercise type.");
    }

    public override void Write(Utf8JsonWriter writer, Exercise value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)value, value.GetType(), options);
    }
}