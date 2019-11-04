using System.Collections.Generic;
using FskabWebMap.Models;

namespace FskabWebMap.Services
{
    public interface ICoordinateService
    {
        IEnumerable<Coordinate> Get();
    }
}