using System.Text.Json.Serialization;

namespace AlgebrakitSDK.Models.AkExercise;

/// <summary>
/// An element containing blocks of content and/or interactions.
/// </summary>
public class AK_Element
{
    [JsonPropertyName("blocks")]
    public List<AK_ElementBlock> Blocks { get; set; } = new();
}

/// <summary>
/// Base class for element blocks. Discriminated on the "type" property.
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(AK_ContentBlock), "CONTENT")]
[JsonDerivedType(typeof(AK_InteractionBlock), "INTERACTION")]
public abstract class AK_ElementBlock
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }
}

/// <summary>
/// A block containing HTML content with optional LaTeX notation.
/// </summary>
public class AK_ContentBlock : AK_ElementBlock
{
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;
}

/// <summary>
/// A block containing an interaction (question).
/// </summary>
public class AK_InteractionBlock : AK_ElementBlock
{
    [JsonPropertyName("interaction")]
    public AK_Interaction Interaction { get; set; } = null!;
}
