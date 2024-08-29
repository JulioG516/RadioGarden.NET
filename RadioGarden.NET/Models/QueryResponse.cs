using System.Collections.Generic;
using System.Text.Json.Serialization;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member


namespace RadioGarden.NET.Models
{
    public class QueryResponse
    {
        [JsonPropertyName("took")] public int Took { get; set; }

        [JsonPropertyName("hits")] public Hits Hits { get; set; } = new Hits();

        [JsonPropertyName("query")] public string Query { get; set; } = string.Empty;

        [JsonPropertyName("version")] public string Version { get; set; } = string.Empty;

        [JsonPropertyName("apiVersion")] public int ApiVersion { get; set; }
    }

    public class HitSource
    {
        [JsonPropertyName("code")] public string Code { get; set; } = string.Empty;

        [JsonPropertyName("stream")] public string Stream { get; set; } = string.Empty;

        [JsonPropertyName("subtitle")] public string Subtitle { get; set; } = string.Empty;

        [JsonPropertyName("type")] public string Type { get; set; } = string.Empty;

        [JsonPropertyName("title")] public string Title { get; set; } = string.Empty;

        [JsonPropertyName("secure")] public bool Secure { get; set; }

        [JsonPropertyName("url")] public string Url { get; set; } = string.Empty;
    }

    public class Hit
    {
        [JsonPropertyName("_id")] public string Id { get; set; } = string.Empty;

        [JsonPropertyName("_score")] public double Score { get; set; }

        [JsonPropertyName("_source")] public HitSource Source { get; set; } = new HitSource();
    }

    public class Hits
    {
        [JsonPropertyName("hits")] public List<Hit> HitList { get; set; } = new List<Hit>();
    }
}