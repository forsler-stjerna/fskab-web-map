using System.Collections.Generic;
using FskabWebMap.Models;

namespace FskabWebMap.Services
{
    public interface IDistanceCalculatorService
    {
        double CalculateDistance(Coordinate coordinateA, Coordinate coordinateB);
        Coordinate CalculateMidpoint(IEnumerable<Coordinate> coordinates);
    }
}