using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyCreator.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JourneyCreator.Core.Interfaces;

namespace JourneyCreator.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JourneyController : ControllerBase
    {
        private readonly ICreationService _creationService;
        private readonly IValidationService _validationService;

        private readonly ILogger<JourneyController> _logger;

        public JourneyController(
            ILogger<JourneyController> logger,
            ICreationService creationService,
            IValidationService validationService)
        {
            _logger = logger;
            _creationService = creationService;
            _validationService = validationService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(Journey journey)
        {
            if (!_validationService.Validate(journey)) return BadRequest();

            //var success = await _creationService.SaveNewJourneyAsync(journey);

            return Ok();
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
