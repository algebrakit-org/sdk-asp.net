using System.Collections.Generic;

namespace AlgebrakitSDK.Models.Responses;

/// <summary>
/// Represents the response containing session information.
/// </summary>
public class SessionInfoResponse
{
    /// <summary>
    /// List of elements in the session, such as questions or instructions.
    /// </summary>
    public List<ElementInfo> Elements { get; set; } = new();

    /// <summary>
    /// Descriptions of skill tags associated with the session.
    /// </summary>
    public Dictionary<string, TagDescription> TagDescriptions { get; set; } = new();
}

/// <summary>
/// Represents an element in the session, such as a question or instruction.
/// </summary>
public class ElementInfo
{
    /// <summary>
    /// Unique identifier for the element.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Type of the element (e.g., INSTRUCTION or QUESTION).
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Items within the element, such as text or interactions.
    /// </summary>
    public List<ElementItemInfo> Items { get; set; } = new();
}

/// <summary>
/// Represents a description of a skill tag.
/// </summary>
public class TagDescription
{
    /// <summary>
    /// Multilanguage description of the skill.
    /// </summary>
    public Dictionary<string, string> Descr { get; set; } = new();

    /// <summary>
    /// Type of step associated with the skill (e.g., STRATEGY, ALGEBRA).
    /// </summary>
    public string StepType { get; set; } = string.Empty;

    /// <summary>
    /// List of errors associated with the skill.
    /// </summary>
    public List<ErrorDescription> Errors { get; set; } = new();
}

/// <summary>
/// Represents an error associated with a skill.
/// </summary>
public class ErrorDescription
{
    /// <summary>
    /// Unique identifier for the error.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Types of the error (e.g., misconception, mistake).
    /// </summary>
    public List<string> Type { get; set; } = new();

    /// <summary>
    /// Multilanguage description of the error.
    /// </summary>
    public Dictionary<string, string> Descr { get; set; } = new();
}

/// <summary>
/// Represents an item within an element, such as text or an interaction.
/// </summary>
public class ElementItemInfo
{
    /// <summary>
    /// Type of the item (e.g., TEXT, INTERACTION).
    /// </summary>
    public string ItemType { get; set; } = string.Empty;

    /// <summary>
    /// Content of the item.
    /// </summary>
    public string Content { get; set; } = string.Empty;
}