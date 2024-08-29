#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace RadioGarden.NET.Models
{
    public class Geo
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public override string ToString()
        {
            return $"Longitude: {Longitude}\nLatitude: {Latitude}";
        }
    }
}