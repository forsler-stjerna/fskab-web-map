using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FskabWebMap.Models;

namespace FskabWebMap.Services
{
    public interface ICoordinateGrouperService
    {
        IEnumerable<CoordinateGroup> Group(IEnumerable<Coordinate> coordinates, int zoom);
    }
}
