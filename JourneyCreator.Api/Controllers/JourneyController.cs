using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyCreator.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JourneyCreator.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JourneyController : ControllerBase
    {

        private readonly ILogger<JourneyController> _logger;

        public JourneyController(ILogger<JourneyController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Create")]
        public ActionResult Create(Journey journey)
        {
            // Call new service - Create
            // return journeyId or list of errors
            return Ok("hi");
        }

        [HttpGet]
        public IEnumerable<Journey> Get()
        {
            // Call new service
            // return list of latest journeys
            return new List<Journey>();
        }

        [HttpGet("GetLatestByProduct/{product}")]
        public Journey Get(string product)
        {
            // Call new service
            // return list of latest journeys
            return new Journey
            {
                Publisher = product
            };
        }

        [HttpGet("GetSpecificByProduct/{product}/{journeyId}")]
        public Journey Get(string product, int journeyId)
        {
            // Call new service
            // return list of latest journeys
            return new Journey
            {
                Publisher = product,
                Id = journeyId
            };
        }
    }
}
