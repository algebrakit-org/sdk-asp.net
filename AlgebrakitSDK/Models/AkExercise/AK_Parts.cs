using System.Text.Json.Serialization;

namespace AlgebrakitSDK.Models.AkExercise;

/// <summary>
/// An expression part defining a task, optional accuracy, and optional unit.
/// </summary>
public class AK_ExpressionPart
{
    [JsonPropertyName("task")]
    public AK_Task Task { get; set; } = null!;

    [JsonPropertyName("accuracy")]
    public AK_AccuracyPreSpec? Accuracy { get; set; }

    [JsonPropertyName("unit")]
    public string? Unit { get; set; }
}

/// <summary>
/// A multistep part extending an expression part with symbol, description and alternative tasks.
/// </summary>
public class AK_MultistepPart : AK_ExpressionPart
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("alternativeTasks")]
    public List<AK_Task>? AlternativeTasks { get; set; }
}

/// <summary>
/// A selection part for multiple choice interactions.
/// </summary>
public class AK_SelectionPart
{
    [JsonPropertyName("options")]
    public List<AK_SelectionOption> Options { get; set; } = new();

    [JsonPropertyName("shuffle")]
    public bool Shuffle { get; set; }

    [JsonPropertyName("multipleSelect")]
    public bool MultipleSelect { get; set; }
}

public class AK_SelectionOption
{
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;

    [JsonPropertyName("correct")]
    public bool Correct { get; set; }
}

/// <summary>
/// A blank field in a fill-in-the-blanks interaction.
/// </summary>
public class AK_Blank
{
    [JsonPropertyName("size")]
    public AK_FieldSize Size { get; set; }

    [JsonPropertyName("type")]
    public AK_BlankType Type { get; set; }

    /// <summary>
    /// The input specification. Either an AK_ExpressionPart (for EXPRESSION blanks)
    /// or an AK_SelectionPart (for SELECTION blanks).
    /// </summary>
    [JsonPropertyName("input")]
    public object Input { get; set; } = null!;
}

/// <summary>
/// A cell in a math table interaction.
/// </summary>
public class AK_Cell
{
    [JsonPropertyName("type")]
    public AK_CellType Type { get; set; }

    [JsonPropertyName("row")]
    public int Row { get; set; }

    [JsonPropertyName("col")]
    public int Col { get; set; }

    [JsonPropertyName("isHeader")]
    public bool IsHeader { get; set; }

    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }

    [JsonPropertyName("spec")]
    public AK_ExpressionPart? Spec { get; set; }
}

/// <summary>
/// Accuracy specification for expression evaluation.
/// </summary>
public class AK_AccuracyPreSpec
{
    [JsonPropertyName("type")]
    public AK_AccuracyType Type { get; set; }

    [JsonPropertyName("nr")]
    public int Nr { get; set; }
}
