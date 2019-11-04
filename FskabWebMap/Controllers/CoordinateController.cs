using System.Collections.Generic;
using System.Linq;
using FskabWebMap.Models;
using Microsoft.AspNetCore.Mvc;

namespace FskabWebMap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoordinateController : ControllerBase
    {
        [HttpGet]
        public IActionResult Coordinates(CoordinateFormBody model)
        {
            var list = new List<Coordinate> {
                new Coordinate()
            };
            var group = new CoordinateGroup(list, list.First());


            return Ok(group);
        }
    }

}