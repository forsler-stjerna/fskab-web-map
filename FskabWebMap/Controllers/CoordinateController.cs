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
        private readonly ICoordinateGrouperService coordinateGrouperService;

        public CoordinateController(
            ICoordinateService coordinateService,
            ICoordinateGrouperService coordinateGrouperService
            )
        {
            this.coordinateService = coordinateService;
            this.coordinateGrouperService = coordinateGrouperService;
        }

        [HttpPost]
        [Route("coordinates")]
        public IActionResult Coordinates([FromBody]CoordinateFormBody model)
        {
            var coords = coordinateService.Get();
            var groups = coordinateGrouperService.Group(coords, model.Zoom);
            return Ok(groups);
        }
    }

}