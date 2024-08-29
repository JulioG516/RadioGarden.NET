using System.Text.Json.Serialization;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace RadioGarden.NET.Models
{
    public class Place
    {
        [JsonPropertyName("size")] public int Size { get; set; }

        [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;

        [JsonPropertyName("geo")] public Geo Geo { get; set; } = new Geo();

        [JsonPropertyName("url")] public string Url { get; set; }  = string.Empty;

        [JsonPropertyName("boost")] public bool Boost { get; set; }

        [JsonPropertyName("title")] public string Title { get; set; }  = string.Empty;

        [JsonPropertyName("country")] public string Country { get; set; } = string.Empty;
    }
}