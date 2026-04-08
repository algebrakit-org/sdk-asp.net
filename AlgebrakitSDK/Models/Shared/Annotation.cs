using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlgebrakitSDK.Models.Shared;

/// <summary>
/// Represents an annotation in session score responses (maintains backward compatibility).
/// Used for /session/score endpoint.
/// </summary>
public class Annotation
{
    /// <summary>
    /// Type of annotation.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Expression content (array of rich content).
    /// </summary>
    [JsonPropertyName("expr")]
    public List<RichContent>? Expr { get; set; }

    /// <summary>
    /// Main content (array of rich content).
    /// </summary>
    [JsonPropertyName("main")]
    public List<RichContent>? Main { get; set; }

    /// <summary>
    /// Sub content (array of rich content).
    /// </summary>
    [JsonPropertyName("sub")]
    public List<RichContent>? Sub { get; set; }
}

/// <summary>
/// Represents rich content with MIME type information.
/// </summary>
public class RichContent
{
    /// <summary>
    /// The content string.
    /// </summary>
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// MIME type of the content.
    /// </summary>
    [JsonPropertyName("mimeType")]
    public string MimeType { get; set; } = string.Empty;

    /// <summary>
    /// Additional Algebrakit-specific information.
    /// </summary>
    [JsonPropertyName("akit")]
    public string? Akit { get; set; }
}