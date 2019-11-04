using System.Collections.Generic;
using System.Linq;
using FskabWebMap.Models;
using FskabWebMap.Services;
using Microsoft.AspNetCore.Mvc;

namespace FskabWebMap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoordinateController : ControllerBase
    {
        private readonly ICoordinateService coordinateService;

        public CoordinateController(ICoordinateService coordinateService)
        {
            this.coordinateService = coordinateService;
        }

        [HttpPost]
        [Route("coordinates")]
        public IActionResult Coordinates([FromBody]CoordinateFormBody model)
        {
            var groups = coordinateService.Get().Select(c => new CoordinateGroup(new[] { c }, c));

            return Ok(groups);
        }
    }

}