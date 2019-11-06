using System.Collections.Generic;
using FskabWebMap.Models;

namespace FskabWebMap.Services
{
    public interface IPathCalculatorService
    {
        IEnumerable<Coordinate> Get(IEnumerable<Coordinate> coordinates);
    }
}
