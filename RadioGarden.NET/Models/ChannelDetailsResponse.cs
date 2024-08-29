using System.Text.Json.Serialization;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace RadioGarden.NET.Models
{
    public class ChannelDetailsResponse
    {
        [JsonPropertyName("apiVersion")] public int ApiVersion { get; set; }
        [JsonPropertyName("version")] public string Version { get; set; } = string.Empty;
        [JsonPropertyName("data")] public ChannelDetailData Data { get; set; } = new ChannelDetailData();
    }

    public class ChannelDetailData
    {
        [JsonPropertyName("type")] public string Type { get; set; } = string.Empty;
        [JsonPropertyName("title")] public string Title { get; set; } = string.Empty;
        [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
        [JsonPropertyName("url")] public string Url { get; set; } = string.Empty;
        [JsonPropertyName("stream")] public string Stream { get; set; } = string.Empty;
        [JsonPropertyName("website")] public string Website { get; set; } = string.Empty;
        [JsonPropertyName("secure")] public bool Secure { get; set; }
        [JsonPropertyName("place")] public ChannelPlace Place { get; set; } = new ChannelPlace();
        [JsonPropertyName("country")] public ChannelCountry Country { get; set; } = new ChannelCountry();
    }

    public class ChannelPlace
    {
        [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
        [JsonPropertyName("title")] public string Title { get; set; } = string.Empty;
    }

    public class ChannelCountry
    {
        [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
        [JsonPropertyName("title")] public string Title { get; set; } = string.Empty;
    }
}