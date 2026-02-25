using System.Text.Json.Serialization;

namespace AlgebrakitSDK.Models.AkExercise;

/// <summary>
/// Base class for all interaction types. Discriminated on the "type" property.
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(AK_InteractionChoice), "CHOICE")]
[JsonDerivedType(typeof(AK_InteractionFITB), "FILL_IN_THE_BLANKS")]
[JsonDerivedType(typeof(AK_InteractionMultistep), "MULTISTEP")]
[JsonDerivedType(typeof(AK_InteractionTable), "MATH_TABLE")]
public abstract class AK_Interaction
{
    [JsonPropertyName("refId")]
    public string? RefId { get; set; }

    [JsonPropertyName("instruction")]
    public string? Instruction { get; set; }

    [JsonPropertyName("scored")]
    public bool? Scored { get; set; }

    [JsonPropertyName("hints")]
    public List<string>? Hints { get; set; }

    [JsonPropertyName("enableCalculator")]
    public bool? EnableCalculator { get; set; }
}

/// <summary>
/// Multiple choice interaction.
/// </summary>
public class AK_InteractionChoice : AK_Interaction
{
    [JsonPropertyName("spec")]
    public AK_SelectionPart Spec { get; set; } = new();
}

/// <summary>
/// Fill-in-the-blanks interaction.
/// </summary>
public class AK_InteractionFITB : AK_Interaction
{
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;

    [JsonPropertyName("blanks")]
    public Dictionary<string, AK_Blank> Blanks { get; set; } = new();

    [JsonPropertyName("interchangables")]
    public List<List<string>>? Interchangables { get; set; }
}

/// <summary>
/// Algebraic multi-step interaction.
/// </summary>
public class AK_InteractionMultistep : AK_Interaction
{
    [JsonPropertyName("givenParts")]
    public Dictionary<string, AK_MultistepPart>? GivenParts { get; set; }

    [JsonPropertyName("intermediateParts")]
    public Dictionary<string, AK_MultistepPart>? IntermediateParts { get; set; }

    [JsonPropertyName("solutionPart")]
    public AK_MultistepPart SolutionPart { get; set; } = new();
}

/// <summary>
/// Math table interaction.
/// </summary>
public class AK_InteractionTable : AK_Interaction
{
    [JsonPropertyName("cells")]
    public List<AK_Cell> Cells { get; set; } = new();
}
