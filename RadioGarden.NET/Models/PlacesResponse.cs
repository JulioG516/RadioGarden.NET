using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace RadioGarden.NET.Models
{
    /// <summary>
    /// Represents the response containing places with registered radio stations.
    /// </summary>
    public class PlacesResponse
    {
        [JsonPropertyName("apiVersion")] public int ApiVersion { get; set; }
        [JsonPropertyName("version")] public string Version { get; set; } = string.Empty;

        [JsonPropertyName("data")]
        public PlacesResponseData PlacesResponseData { get; set; } = new PlacesResponseData();
    }

    /// <summary>
    /// Represents the data containing the list of places.
    /// </summary>
    public class PlacesResponseData
    {
        [JsonPropertyName("list")] public List<Place> List { get; set; } = new List<Place>();
        [JsonPropertyName("version")] public string Version { get; set; } = String.Empty;
    }
}