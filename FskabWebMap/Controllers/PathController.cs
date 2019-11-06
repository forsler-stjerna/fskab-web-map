using System.Collections.Generic;
using FskabWebMap.Models;
using FskabWebMap.Services;
using Microsoft.AspNetCore.Mvc;

namespace FskabWebMap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PathController : ControllerBase
    {
        private readonly IPathCalculatorService pathCalculatorService;

        public PathController(IPathCalculatorService pathCalculatorService) => this.pathCalculatorService = pathCalculatorService;

        [HttpPost]
        [Route("shortestpath")]
        public IActionResult ShortestPath([FromBody]ShortestPathFormBody body)
        {
            IEnumerable<Coordinate> path = pathCalculatorService.Get(body.Coordinates);

            return Ok(new { coordinates = path });
        }
    }
}