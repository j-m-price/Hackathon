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
        private readonly IRetrievalService _retrievalService;
        private readonly ILogger<JourneyController> _logger;

        public JourneyController(
            ILogger<JourneyController> logger,
            ICreationService creationService,
            IValidationService validationService,
            IRetrievalService retrievalService)
        {
            _logger = logger;
            _creationService = creationService;
            _validationService = validationService;
            _retrievalService = retrievalService;
        }

        [HttpPost]
        public async Task<ActionResult<Journey>> CreateAsync(Journey journey)
        {
            // if (!_validationService.Validate(journey)) return BadRequest();
            journey.Id = Guid.NewGuid().ToString(); 

           var createdJourney = await _creationService.SaveNewJourneyAsync(journey);

            //TODO get the below working to return a 201, not an OK. To be more RESTful
            //return CreatedAtRoute("GetSpecificByProduct", new { product = journey.Product, id = journey.Id }, journey);
            return Ok(createdJourney);
        }

        [HttpGet]
        public async Task<IEnumerable<Journey>> GetAsync()
        {
            return await _retrievalService.GetLatestJourneyForAllProductsAsync();
        }

        [HttpGet("GetLatestByProduct/{product}")]
        public Journey Get(string product)
        {
            return _retrievalService.GetJourneyByProductAsync(product);
        }

        [HttpGet("GetSpecificByProduct/{product}/{id}", Name = "GetSpecificByProduct")]
        public Journey Get(string product, string id)
        {
            return _retrievalService.GetJourneyByProductAndIdAsync(product, id);
        }
    }
}
