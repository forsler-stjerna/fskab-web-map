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
        public Coordinate Coordinate { get; }

    }
}