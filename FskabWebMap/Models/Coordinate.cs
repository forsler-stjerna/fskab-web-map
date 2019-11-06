using System;

namespace FskabWebMap.Models
{
    public struct Coordinate
    {
        public Coordinate(
            double latitude,
            double longitude,
            string name = ""
            )
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }

        public string Name { get; }
        public double Latitude { get; }
        public double Longitude { get; }

        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => HashCode.Combine(Name, Math.Round(Latitude, 3), Math.Round(Longitude, 3));
        public override string ToString() => Name;
    }
}