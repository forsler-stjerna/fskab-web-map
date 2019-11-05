using System.Collections.Generic;
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
        public void Setup()
        {
            coordinates = new[] {
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
                new Coordinate(55.000507, 13.000000, "O"),
                new Coordinate(55.611207, 12.989999, "P"),
                new Coordinate(55.620507, 13.009980, "Q"),
                new Coordinate(55.612507, 13.008381, "R"),
                new Coordinate(55.621607, 13.010180, "S"),
                new Coordinate(55.631000, 13.019876, "T"),
                new Coordinate(55.610333, 13.008930, "U"),
            };
        }

        [Test]
        [Combinatorial]
        public void GroupCoordinatesReturnsAllCoordinates([Values(0, 1, 2, 3, 4, 5, 6, 30, 100)] int zoom)
        {
            var coordinateGrouperService = new CoordinateGrouperService();
            IEnumerable<CoordinateGroup> groups = coordinateGrouperService.Group(coordinates, zoom);
            var count = groups.Select(g => g.Coordinates.Count).Sum();

            Assert.AreEqual(coordinates.Length, count);
        }

        [Test]
        public void GroupCoordinatesZoom0()
        {
            var coordinateGrouperService = new CoordinateGrouperService();
            IEnumerable<CoordinateGroup> expectedGroups = coordinates.Select(coordinate => new CoordinateGroup(new[] { coordinate }, coordinate));
            IEnumerable<CoordinateGroup> actualGroups = coordinateGrouperService.Group(coordinates, 0);

            CollectionAssert.AreEquivalent(expectedGroups, actualGroups);
        }

        [Test]
        public void GroupCoordinatesZoom1()
        {
            var calculateDistanceService = new DistanceCalculatorService();
            var coordinateGrouperService = new CoordinateGrouperService();
            var groups = new List<List<Coordinate>>() {
                new List<Coordinate> {
                    new Coordinate(55.610507, 13.009180, "A"),
                    new Coordinate(55.610333, 13.008930, "U"),
                    new Coordinate(55.610507, 13.010180, "B"),
                    new Coordinate(55.611507, 13.009380, "H"),
                },
                    new List<Coordinate>() {
                    new Coordinate(55.620507, 13.009120, "I"),
                    new Coordinate(55.620507, 13.009980, "Q"),
                    new Coordinate(55.621607, 13.010180, "S"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.612507, 13.001180, "C"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.711507, 13.003180, "D"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.615507, 13.009180, "E"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.612307, 13.029480, "F"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.593507, 13.009180, "G"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.582307, 13.111480, "J"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.594518, 13.001280, "K"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.611507, 13.108381, "L"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.490507, 12.999120, "M"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.481107, 13.119480, "N"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.000507, 13.000000, "O"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.611207, 12.989999, "P"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.612507, 13.008381, "R"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.631000, 13.019876, "T"),
                }
            };

            var expectedGroups = groups.Select(g => new CoordinateGroup(g, calculateDistanceService.CalculateMidpoint(g)));
            IEnumerable<CoordinateGroup> actualGroups = coordinateGrouperService.Group(coordinates, 1);
            CollectionAssert.AreEquivalent(expectedGroups, actualGroups);
        }
        
        [Test]
        public void GroupCoordinatesZoom4()
        {
            var calculateDistanceService = new DistanceCalculatorService();
            var coordinateGrouperService = new CoordinateGrouperService();
            var groups = new List<List<Coordinate>>() {
                new List<Coordinate> {
                    new Coordinate(55.610507, 13.009180, "A"),
                    new Coordinate(55.610333, 13.008930, "U"),
                    new Coordinate(55.610507, 13.010180, "B"),
                    new Coordinate(55.611507, 13.009380, "H"),
                    new Coordinate(55.612507, 13.008381, "R"),
                    new Coordinate(55.615507, 13.009180, "E"),
                    new Coordinate(55.612507, 13.001180, "C"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.620507, 13.009120, "I"),
                    new Coordinate(55.620507, 13.009980, "Q"),
                    new Coordinate(55.621607, 13.010180, "S"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.711507, 13.003180, "D"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.612307, 13.029480, "F"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.593507, 13.009180, "G"),
                    new Coordinate(55.594518, 13.001280, "K"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.582307, 13.111480, "J"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.611507, 13.108381, "L"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.490507, 12.999120, "M"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.481107, 13.119480, "N"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.000507, 13.000000, "O"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.611207, 12.989999, "P"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.631000, 13.019876, "T"),
                }
            };

            var expectedGroups = groups.Select(g => new CoordinateGroup(g, calculateDistanceService.CalculateMidpoint(g)));
            IEnumerable<CoordinateGroup> actualGroups = coordinateGrouperService.Group(coordinates, 4);
            CollectionAssert.AreEquivalent(expectedGroups, actualGroups);
        }

        [Test]
        public void GroupCoordinatesZoom10()
        {
            var calculateDistanceService = new DistanceCalculatorService();
            var coordinateGrouperService = new CoordinateGrouperService();
            var groups = new List<List<Coordinate>>() {
                new List<Coordinate> {
                    new Coordinate(55.610507, 13.009180, "A"),
                    new Coordinate(55.610333, 13.008930, "U"),
                    new Coordinate(55.610507, 13.010180, "B"),
                    new Coordinate(55.611507, 13.009380, "H"),
                    new Coordinate(55.612507, 13.008381, "R"),
                    new Coordinate(55.615507, 13.009180, "E"),
                    new Coordinate(55.612507, 13.001180, "C"),
                    new Coordinate(55.611207, 12.989999, "P"),
                    new Coordinate(55.612307, 13.029480, "F"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.620507, 13.009120, "I"),
                    new Coordinate(55.620507, 13.009980, "Q"),
                    new Coordinate(55.621607, 13.010180, "S"),
                    new Coordinate(55.631000, 13.019876, "T"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.711507, 13.003180, "D"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.593507, 13.009180, "G"),
                    new Coordinate(55.594518, 13.001280, "K"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.582307, 13.111480, "J"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.611507, 13.108381, "L"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.490507, 12.999120, "M"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.481107, 13.119480, "N"),
                },
                new List<Coordinate>() {
                    new Coordinate(55.000507, 13.000000, "O"),
                }
            };

            var expectedGroups = groups.Select(g => new CoordinateGroup(g, calculateDistanceService.CalculateMidpoint(g)));
            IEnumerable<CoordinateGroup> actualGroups = coordinateGrouperService.Group(coordinates, 10);
            CollectionAssert.AreEquivalent(expectedGroups, actualGroups);
        }

    }
}