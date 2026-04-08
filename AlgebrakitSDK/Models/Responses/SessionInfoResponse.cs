using System.Collections.Generic;
using System.Text.Json.Serialization;
using AlgebrakitSDK.Models.Shared;
using AlgebrakitSDK.Enums;

namespace AlgebrakitSDK.Models.Responses;

/// <summary>
/// Represents the response containing session information.
/// </summary>
public class SessionInfoResponse
{
    /// <summary>
    /// Indicates whether the request was successful.
    /// </summary>
    [JsonPropertyName("success")]
    public bool? Success { get; set; }

    /// <summary>
    /// Timestamp when the session was created.
    /// </summary>
    [JsonPropertyName("creationTimestamp")]
    public long? CreationTimestamp { get; set; }

    /// <summary>
    /// List of elements in the session, such as questions or instructions.
    /// </summary>
    [JsonPropertyName("elements")]
    public List<ElementInfo> Elements { get; set; } = new();

    /// <summary>
    /// Descriptions of skill tags associated with the session.
    /// </summary>
    [JsonPropertyName("tagDescriptions")]
    public Dictionary<string, TagDescription> TagDescriptions { get; set; } = new();

    /// <summary>
    /// Overall scoring for the session.
    /// </summary>
    [JsonPropertyName("scoring")]
    public InteractionScoring? Scoring { get; set; }
}

/// <summary>
/// Represents an element in the session, such as a question or instruction.
/// </summary>
public class ElementInfo
{
    /// <summary>
    /// Unique identifier for the element.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Type of the element (e.g., INSTRUCTION or QUESTION).
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Items within the element, such as text or interactions.
    /// </summary>
    [JsonPropertyName("items")]
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
    [JsonPropertyName("descr")]
    public Dictionary<string, string> Descr { get; set; } = new();

    /// <summary>
    /// Type of step associated with the skill (e.g., STRATEGY, ALGEBRA).
    /// </summary>
    [JsonPropertyName("stepType")]
    public string StepType { get; set; } = string.Empty;

    /// <summary>
    /// List of errors associated with the skill.
    /// </summary>
    [JsonPropertyName("errors")]
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
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Types of the error (e.g., misconception, mistake).
    /// </summary>
    [JsonPropertyName("type")]
    public List<string> Type { get; set; } = new();

    /// <summary>
    /// Multilanguage description of the error.
    /// </summary>
    [JsonPropertyName("descr")]
    public Dictionary<string, string> Descr { get; set; } = new();
}

/// <summary>
/// Represents an item within an element, such as text or an interaction.
/// </summary>
public class ElementItemInfo
{
    /// <summary>
    /// Unique identifier for the item.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Type of the item (e.g., TEXT, INTERACTION).
    /// </summary>
    [JsonPropertyName("itemType")]
    public string ItemType { get; set; } = string.Empty;

    /// <summary>
    /// Type of interaction if this is an interaction item.
    /// </summary>
    [JsonPropertyName("interactionType")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public InteractionType? InteractionType { get; set; }

    /// <summary>
    /// Content of the item.
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    /// <summary>
    /// Solution for the item.
    /// </summary>
    [JsonPropertyName("solution")]
    public string? Solution { get; set; }

    /// <summary>
    /// Derivation steps for the solution.
    /// </summary>
    [JsonPropertyName("derivation")]
    public List<DerivationPart>? Derivation { get; set; }

    /// <summary>
    /// Result information for the interaction.
    /// </summary>
    [JsonPropertyName("result")]
    public InteractionResultInfo? Result { get; set; }
}

/// <summary>
/// Represents a part of a derivation.
/// </summary>
public class DerivationPart
{
    /// <summary>
    /// Hint text for this derivation step.
    /// </summary>
    [JsonPropertyName("hint")]
    public string? Hint { get; set; }

    /// <summary>
    /// Mathematical expression for this step.
    /// </summary>
    [JsonPropertyName("expression")]
    public string? Expression { get; set; }

    /// <summary>
    /// Result of this derivation step.
    /// </summary>
    [JsonPropertyName("result")]
    public string? Result { get; set; }

    /// <summary>
    /// Description of this derivation step.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Skills used in this derivation step.
    /// </summary>
    [JsonPropertyName("skills")]
    public List<string>? Skills { get; set; }

    /// <summary>
    /// Nested derivation steps.
    /// </summary>
    [JsonPropertyName("derivation")]
    public List<DerivationPart>? Derivation { get; set; }
}

/// <summary>
/// Represents the result information for an interaction.
/// </summary>
public class InteractionResultInfo
{
    /// <summary>
    /// Status of the interaction.
    /// </summary>
    [JsonPropertyName("status")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ExerciseStatus Status { get; set; }

    /// <summary>
    /// Progress percentage (0-1).
    /// </summary>
    [JsonPropertyName("progress")]
    public double Progress { get; set; }

    /// <summary>
    /// Scoring details for the interaction.
    /// </summary>
    [JsonPropertyName("scoring")]
    public InteractionScoring Scoring { get; set; } = new();

    /// <summary>
    /// Tags associated with the interaction result.
    /// </summary>
    [JsonPropertyName("tags")]
    public List<FeedbackTag> Tags { get; set; } = new();

    /// <summary>
    /// Events that occurred during the interaction.
    /// </summary>
    [JsonPropertyName("events")]
    public List<EventResultInfo> Events { get; set; } = new();
}

/// <summary>
/// Represents a feedback tag.
/// </summary>
public class FeedbackTag
{
    /// <summary>
    /// Identifier for the tag.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// List of error identifiers associated with this tag.
    /// </summary>
    [JsonPropertyName("errors")]
    public List<string>? Errors { get; set; }

    /// <summary>
    /// Weight of the tag.
    /// </summary>
    [JsonPropertyName("weight")]
    public int? Weight { get; set; }

    /// <summary>
    /// Source of the feedback tag.
    /// </summary>
    [JsonPropertyName("source")]
    public string? Source { get; set; }
}

/// <summary>
/// Represents information about an event result.
/// </summary>
public class EventResultInfo
{
    /// <summary>
    /// Timestamp of the event.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public long Timestamp { get; set; }

    /// <summary>
    /// Type of event (EVALUATE, HINT, GIVEUP, SUBMIT).
    /// </summary>
    [JsonPropertyName("event")]
    public string Event { get; set; } = string.Empty;

    /// <summary>
    /// Exercise status at the time of the event.
    /// </summary>
    [JsonPropertyName("exerciseStatus")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ExerciseStatus? ExerciseStatus { get; set; }

    /// <summary>
    /// Progress at the time of the event.
    /// </summary>
    [JsonPropertyName("progress")]
    public double? Progress { get; set; }

    /// <summary>
    /// Input status at the time of the event.
    /// </summary>
    [JsonPropertyName("inputStatus")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ExerciseStatus? InputStatus { get; set; }

    /// <summary>
    /// Tags associated with the event.
    /// </summary>
    [JsonPropertyName("tags")]
    public List<FeedbackTag>? Tags { get; set; }

    /// <summary>
    /// Annotations for the event (AL-3197 changes).
    /// </summary>
    [JsonPropertyName("annotations")]
    public List<InfoAnnotation>? Annotations { get; set; }

    /// <summary>
    /// Skills still to be completed at the time of the event.
    /// </summary>
    [JsonPropertyName("skillsTodo")]
    public List<string>? SkillsTodo { get; set; }
}

/// <summary>
/// Represents an annotation in the session info (AL-3197 changes).
/// </summary>
public class InfoAnnotation
{
    /// <summary>
    /// Type of annotation (HINT, ERROR_FEEDBACK, INPUT).
    /// Note: INPUT_EXPRESSION and SELECTED_OPTIONS are only used in /session/score endpoint.
    /// </summary>
    [JsonPropertyName("type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public AnnotationType Type { get; set; }

    /// <summary>
    /// Content in HTML format. This combines the former 'main', 'sub', and 'text' fields.
    /// For INPUT type annotations, contains the complete question view with student inputs encoded as:
    /// - &lt;math-field&gt; tags for mathematical input fields
    /// - &lt;choice-field label="X"&gt; tags for multiple choice options
    /// - \boxed{\color{blue} ...} for inline math expression inputs
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    /// <summary>
    /// Mathematical expression in LaTeX format.
    /// For inline math inputs, uses \boxed{\color{blue} ...} to highlight input fields.
    /// Replaces the former 'expr' field.
    /// </summary>
    [JsonPropertyName("expression")]
    public string? Expression { get; set; }

    /// <summary>
    /// Index of the gap in a Fill in the Blanks question, starting from 1.
    /// </summary>
    [JsonPropertyName("gapIndex")]
    public int? GapIndex { get; set; }

    /// <summary>
    /// Row index in a Math Table question, starting from 1.
    /// </summary>
    [JsonPropertyName("row")]
    public int? Row { get; set; }

    /// <summary>
    /// Column index in a Math Table question, starting from 1.
    /// </summary>
    [JsonPropertyName("col")]
    public int? Col { get; set; }
}

/// <summary>
/// Annotation types used in session info responses.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AnnotationType
{
    /// <summary>
    /// Hint provided to help the student.
    /// </summary>
    HINT,

    /// <summary>
    /// Feedback about an error in the student's input.
    /// </summary>
    ERROR_FEEDBACK,

    /// <summary>
    /// Expression entered by the student (used in /session/score only).
    /// </summary>
    INPUT_EXPRESSION,

    /// <summary>
    /// Options selected by the student (used in /session/score only).
    /// </summary>
    SELECTED_OPTIONS,

    /// <summary>
    /// Complete view of the question with student inputs at the time of the event (used in /session/info only).
    /// </summary>
    INPUT
}