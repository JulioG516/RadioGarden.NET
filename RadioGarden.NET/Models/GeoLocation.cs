using System.Text.Json.Serialization;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace RadioGarden.NET.Models
{
    public class GeoLocation
    {
        [JsonPropertyName("eu")] public bool Eu { get; set; }
        [JsonPropertyName("country_code")] public string CountryCode { get; set; } = string.Empty;
        [JsonPropertyName("region_code")] public string RegionCode { get; set; }= string.Empty;
        [JsonPropertyName("latitude")] public double Latitude { get; set; }
        [JsonPropertyName("longitude")] public double Longitude { get; set; }
        [JsonPropertyName("city")] public string City { get; set; }= string.Empty;
    }
}