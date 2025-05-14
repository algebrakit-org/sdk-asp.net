using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlgebrakitSDK.Models.Shared
{
    /// <summary>
    /// Represents a map from a Skill Tag to the skill specification.
    /// </summary>
    public class TagDescriptions : Dictionary<string, TagDescription>
    {
    }

    /// <summary>
    /// Represents the skill specification for a tag.
    /// </summary>
    public class TagDescription
    {
        [JsonPropertyName("descr")]
        public MultilanguageDescription Descr { get; set; } = new();

        [JsonPropertyName("stepType")]
        public string StepType { get; set; } = string.Empty;

        [JsonPropertyName("errors")]
        public List<TagError> Errors { get; set; } = new();
    }

    public class MultilanguageDescription : Dictionary<string, string> { }

    public class TagError
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public List<string> Type { get; set; } = new();

        [JsonPropertyName("descr")]
        public MultilanguageDescription Descr { get; set; } = new();
    }
}
