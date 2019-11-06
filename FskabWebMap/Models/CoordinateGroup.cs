using System;
using System.Collections.Generic;
using System.Linq;

namespace FskabWebMap.Models
{
    public class CoordinateGroup
    {
        public CoordinateGroup(IEnumerable<Coordinate> coordinates, Coordinate coordinate)
        {
            Coordinates = coordinates.ToList();
            Coordinate = coordinate;
        }

        public List<Coordinate> Coordinates { get; }
        public Coordinate Coordinate { get; set; }

        public override bool Equals(object obj) => GetHashCode() == obj.GetHashCode();
        public override int GetHashCode() => HashCode.Combine(string.Join("", Coordinates.OrderBy(c => c.Name).Select(c => c.Name)), Coordinate.GetHashCode());
        public override string ToString() => string.Join(", ", Coordinates);

    }
}