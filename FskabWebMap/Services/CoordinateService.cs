﻿using System;
using System.Collections.Generic;
using FskabWebMap.Models;

namespace FskabWebMap.Services
{
    public class CoordinateService : ICoordinateService
    {
        public IEnumerable<Coordinate> Get()
        {
            return new List<Coordinate> {
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
    }
}