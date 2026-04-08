using System.Text.Json.Serialization;

namespace AlgebrakitSDK.Models.AkExercise;

/// <summary>
/// The AK_Exercise specification format. A human-friendly way to define
/// mathematical exercises for the Algebrakit API.
/// </summary>
public class AK_Exercise
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = "AK_Exercise";

    [JsonPropertyName("version")]
    public int Version { get; set; } = 1;

    [JsonPropertyName("studentProfile")]
    public string StudentProfile { get; set; } = string.Empty;

    [JsonPropertyName("script")]
    public string? Script { get; set; }

    [JsonPropertyName("symbols")]
    public List<AK_Symbol>? Symbols { get; set; }

    [JsonPropertyName("elements")]
    public List<AK_Element> Elements { get; set; } = new();

    [JsonPropertyName("questionMode")]
    public AK_QuestionMode QuestionMode { get; set; } = AK_QuestionMode.ONE_BY_ONE;
}

/// <summary>
/// A mathematical symbol used in the exercise.
/// </summary>
public class AK_Symbol
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public AK_SymbolType Type { get; set; }

    [JsonPropertyName("synonym")]
    public string? Synonym { get; set; }

    [JsonPropertyName("addToFormulaEditor")]
    public bool? AddToFormulaEditor { get; set; }

    [JsonPropertyName("notations")]
    public List<string>? Notations { get; set; }
}
