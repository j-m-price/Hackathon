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

        [HttpPost("Create")]
        public async Task<ActionResult> Create(Journey journey)
        {
            if (!_validationService.Validate(journey)) return BadRequest();

            //var success = await _creationService.SaveNewJourneyAsync(journey);

            return Ok(journey);
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

        [HttpGet("GetSpecificByProduct/{product}/{id}")]
        public Journey Get(string product, int id)
        {
            return _retrievalService.GetJourneyByProductAndIdAsync(product, id);
        }
    }
}
