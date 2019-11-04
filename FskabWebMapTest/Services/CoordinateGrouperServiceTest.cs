using System.Linq;
using FskabWebMap.Models;
using FskabWebMap.Services;
using NUnit.Framework;

namespace FskabWebMapTest.Services
{
    public class CoordinateGrouperServiceTest
    {
        private Coordinate[] coordinates;

        [SetUp]
        public void Setup() {
            coordinates = new [] {
                new Coordinate(55.610507, 13.009180),
                new Coordinate(55.610507, 13.010180),
                new Coordinate(55.612507, 13.001180),
                new Coordinate(55.711507, 13.003180),
                new Coordinate(55.615507, 13.009180),
                new Coordinate(55.612307, 13.029480),
                new Coordinate(55.593507, 13.009180),
                new Coordinate(55.611507, 13.009380),
                new Coordinate(55.620507, 13.009120),
            };
        }

        [Test]
        [Combinatorial]
        public void GroupCoordinatesReturnsAllCoordinates([Values(1,2,3,4,5)] int zoom)
        {
            var coordinateGrouperService = new CoordinateGrouperService();
            var groups = coordinateGrouperService.Group(coordinates, zoom);
            var count = groups.Select(g => g.Coordinates.Count).Sum();

            Assert.AreEqual(coordinates.Length, count);
        }

        [Test]
        public void GroupCoordinatesZoom0()
        {
            var coordinateGrouperService = new CoordinateGrouperService();
            var expectedGroups = coordinates.Select(coordinate => new CoordinateGroup(new[] {coordinate}, coordinate));
            var actualGroups = coordinateGrouperService.Group(coordinates, 0);

            CollectionAssert.AreEquivalent(expectedGroups, actualGroups);
        }

        [Test]
        public void GroupCoordinatesZoom1()
        {
            Assert.Fail();
        }

        [Test]
        public void GroupCoordinatesZoom2()
        {
            Assert.Fail();
        }

        [Test]
        public void GroupCoordinatesZoom3()
        {
            Assert.Fail();
        }
    }
}