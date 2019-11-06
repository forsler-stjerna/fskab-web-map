using System.Collections.Generic;
using FskabWebMap.Models;
using FskabWebMap.Services;
using NUnit.Framework;

namespace FskabWebMapTest.Services
{
    [TestFixture]
    public class PathCalculatorServiceTest
    {
        [Test]
        public void GetPathHandlesTwoPoints()
        {
            var firstCoordinate = new Coordinate(55.610507, 13.009180, "A");
            var secondCoordinate = new Coordinate(55.610507, 13.010180, "B");

            IEnumerable<Coordinate> path = new PathCalculatorService().Get(new[] { firstCoordinate, secondCoordinate });

            Coordinate[] expected = new[] { firstCoordinate, secondCoordinate };

            CollectionAssert.AreEqual(expected, path);
        }

        [Test]
        public void GetPathHandlesThreePoints()
        {
            var aCoordinate = new Coordinate(55.610507, 13.009180, "A");
            var bCoordinate = new Coordinate(55.610507, 13.010180, "B");
            var cCoordinate = new Coordinate(55.610507, 13.01000, "C");

            IEnumerable<Coordinate> path = new PathCalculatorService().Get(new[] { aCoordinate, bCoordinate, cCoordinate });

            Coordinate[] expected = new[] { aCoordinate, cCoordinate, bCoordinate };

            CollectionAssert.AreEqual(expected, path);
        }
    }
}
