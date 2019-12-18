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
        private readonly IJourneyRepository _journeyRepository;

        private readonly ILogger<JourneyController> _logger;

        public JourneyController(
            ILogger<JourneyController> logger,
            ICreationService creationService,
            IValidationService validationService,
            IJourneyRepository journeyRepository)
        {
            _logger = logger;
            _creationService = creationService;
            _validationService = validationService;
            _journeyRepository = journeyRepository;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(Journey journey)
        {
            if (!_validationService.Validate(journey)) return BadRequest();

            //var success = await _creationService.SaveNewJourneyAsync(journey);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Journey>>> GetAsync()
        {
            // Call new service
            var journeys = await _journeyRepository.GetAsync();

            // return list of latest journeys
            return Ok(journeys);
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
