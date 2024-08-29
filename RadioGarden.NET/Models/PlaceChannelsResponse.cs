using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace RadioGarden.NET.Models
{
    public class PlaceChannelsResponse
    {
        [JsonPropertyName("apiVersion")] public int ApiVersion { get; set; }
        [JsonPropertyName("version")] public string Version { get; set; } = string.Empty;

        [JsonPropertyName("data")]
        public PlaceChannelsResponseData Data { get; set; } = new PlaceChannelsResponseData();
    }

    public class PlaceChannelsResponseData
    {
        [JsonPropertyName("map")] public string Map { get; set; } = string.Empty;
        [JsonPropertyName("url")] public string Url { get; set; }= string.Empty;
        [JsonPropertyName("type")] public string Type { get; set; }= string.Empty;
        [JsonPropertyName("count")] public int Count { get; set; }
        [JsonPropertyName("title")] public string Title { get; set; }= string.Empty;
        [JsonPropertyName("subtitle")] public string Subtitle { get; set; }= string.Empty;
        [JsonPropertyName("utfcOffset")] public int UtfcOffset { get; set; }
        [JsonPropertyName("content")] public List<Content> Content { get; set; } = new List<Content>();
    }

    public class Content
    {
        [JsonPropertyName("itemsType")] public string ItemsType { get; set; }= string.Empty;
        [JsonPropertyName("type")] public string Type { get; set; }= string.Empty;
        [JsonPropertyName("items")] public List<Item> Items { get; set; } = new List<Item>();
    }

    public class Item
    {
        [JsonPropertyName("page")] public ChannelPage Page { get; set; } = new ChannelPage();
    }

    public class ChannelPage
    {
        public string Id
        {
            get
            {
                if (string.IsNullOrEmpty(Url) || !Url.Contains("/"))
                {
                    return string.Empty;
                }

                return Url.Substring(Url.LastIndexOf("/", StringComparison.Ordinal) + 1);
            }
        }

        [JsonPropertyName("type")] public string Type { get; set; }= string.Empty;
        [JsonPropertyName("title")] public string Title { get; set; }= string.Empty;
        [JsonPropertyName("url")] public string Url { get; set; }= string.Empty;
        [JsonPropertyName("stream")] public string Stream { get; set; }= string.Empty;
    }
}