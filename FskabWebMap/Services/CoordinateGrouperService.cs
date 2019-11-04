using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FskabWebMap.Models;

namespace FskabWebMap.Services
{
    public class CoordinateGrouperService : ICoordinateGrouperService
    {
        public IEnumerable<CoordinateGroup> Group(IEnumerable<Coordinate> coordinates, int zoom)
        {
            var groups = coordinates.Select(coordinate => new CoordinateGroup(new[] {coordinate}, coordinate));
            return groups;
        }
    }
}
