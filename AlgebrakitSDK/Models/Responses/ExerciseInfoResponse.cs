using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlgebrakitSDK.Models.Responses;

/// <summary>
/// Response for exercise published info.
/// </summary>
public class ExerciseInfoResponse
{
    [JsonPropertyName("commitHistory")]
    public List<ExerciseInfoCommitData> CommitHistory { get; set; } = new();

    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("publishedVersions")]
    public List<ExerciseInfoPublishedVersion> PublishedVersions { get; set; } = new();

    [JsonPropertyName("courseName")]
    public string CourseName { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;
}

public class ExerciseInfoCommitData
{
    [JsonPropertyName("versionNumber")]
    public string VersionNumber { get; set; } = string.Empty;

    [JsonPropertyName("commitDate")]
    public string CommitDate { get; set; } = string.Empty;

    [JsonPropertyName("commitMessage")]
    public string CommitMessage { get; set; } = string.Empty;

    [JsonPropertyName("authorUsername")]
    public string AuthorUsername { get; set; } = string.Empty;
}

public class ExerciseInfoPublishedVersion
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("majorVersion")]
    public string MajorVersion { get; set; } = string.Empty;

    [JsonPropertyName("minorVersion")]
    public int MinorVersion { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, string> Metadata { get; set; } = new();

    [JsonPropertyName("numberOfLevels")]
    public int? NumberOfLevels { get; set; }

    [JsonPropertyName("interactions")]
    public List<ExerciseInfoInteraction> Interactions { get; set; } = new();

    [JsonPropertyName("resources")]
    public List<ExerciseInfoResource> Resources { get; set; } = new();
}

public class ExerciseInfoInteraction
{
    [JsonPropertyName("block")]
    public string Block { get; set; } = string.Empty;

    [JsonPropertyName("refId")]
    public string RefId { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("refName")]
    public string RefName { get; set; } = string.Empty;
}

public class ExerciseInfoResource
{
    [JsonPropertyName("refId")]
    public string RefId { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("refName")]
    public string RefName { get; set; } = string.Empty;
}
