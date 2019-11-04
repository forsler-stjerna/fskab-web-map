using System.Collections.Generic;

namespace FskabWebMap.Models
{
    public class CoordinateGroup
    {
        public CoordinateGroup(List<Coordinate> coordinates, Coordinate coordinate)
        {
            Coordinates = coordinates;
            Coordinate = coordinate;
        }

        public List<Coordinate> Coordinates { get; }
        public Coordinate Coordinate { get; }

    }
}