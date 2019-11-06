using System.Collections.Generic;
using FskabWebMap.Models;

namespace FskabWebMap.Services
{
    public class CoordinateService : ICoordinateService
    {
        public IEnumerable<Coordinate> Get()
        {
            return new List<Coordinate> {
                new Coordinate(55.610507, 13.009180, "A"),
                new Coordinate(55.610507, 13.010180, "B"),
                new Coordinate(55.612507, 13.001180, "C"),
                new Coordinate(55.711507, 13.003180, "D"),
                new Coordinate(55.615507, 13.009180, "E"),
                new Coordinate(55.612307, 13.029480, "F"),
                new Coordinate(55.593507, 13.009180, "G"),
                new Coordinate(55.611507, 13.009380, "H"),
                new Coordinate(55.620507, 13.009120, "I"),
                new Coordinate(55.582307, 13.111480, "J"),
                new Coordinate(55.594518, 13.001280, "K"),
                new Coordinate(55.611507, 13.108381, "L"),
                new Coordinate(55.490507, 12.999120, "M"),
                new Coordinate(55.481107, 13.119480, "N"),
                new Coordinate(55.000507, 13.100000, "O"),
                new Coordinate(55.611207, 12.989999, "P"),
                new Coordinate(55.620507, 13.009980, "Q"),
                new Coordinate(55.612507, 13.008381, "R"),
                new Coordinate(55.621607, 13.010180, "S"),
                new Coordinate(55.631000, 13.019876, "T"),
                new Coordinate(55.610333, 13.008930, "U"),

            };
        }
    }
}
