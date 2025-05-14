using System.Text.Json.Serialization;

namespace AlgebrakitSDK.Models.Shared
{
    /// <summary>
    /// Represents the details of an interaction within an exercise.
    /// </summary>
    public class InteractionDescription
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("marks")]
        public double Marks { get; set; }

        [JsonPropertyName("scorable")]
        public bool Scorable { get; set; }
    }
}
