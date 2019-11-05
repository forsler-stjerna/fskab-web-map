using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FskabWebMap.Models;

namespace FskabWebMap.Services
{
    public class DistanceCalculatorService: IDistanceCalculatorService
    {
        public double CalculateDistance(Coordinate coordinateA, Coordinate coordinateB) {
            var d1 = coordinateA.Latitude * (Math.PI / 180.0);
            var num1 = coordinateA.Longitude * (Math.PI / 180.0);
            var d2 = coordinateB.Latitude * (Math.PI / 180.0);
            var num2 = coordinateB.Longitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }

        public Coordinate CalculateMidpoint(IEnumerable<Coordinate> coordinates) {
            var summedCoordinate = coordinates.Aggregate((current, next) => new Coordinate(current.Latitude + next.Latitude, current.Longitude + next.Longitude));
            return new Coordinate(summedCoordinate.Latitude / coordinates.Count(), summedCoordinate.Longitude / coordinates.Count());
        }
    }
}
