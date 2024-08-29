using System;
using System.Text.Json;

namespace RadioGarden.NET.Models.Converters
{
    /// <summary>
    /// Custom serializer due to Geo Response comes in as an Array.
    /// </summary>
    public class GeoConverter : System.Text.Json.Serialization.JsonConverter<Geo>
    {
        /// <inheritdoc />
        public override Geo Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            reader.Read();
            double longitude = reader.GetDouble();
            reader.Read();
            double latitude = reader.GetDouble();
            reader.Read();
            return new Geo { Latitude = latitude, Longitude = longitude };
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, Geo value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            writer.WriteNumberValue(value.Longitude);
            writer.WriteNumberValue(value.Longitude);
            writer.WriteEndArray();
        }
    }
}