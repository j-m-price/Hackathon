using System;
using System.Threading.Tasks;
using JourneyCreator.Core.Interfaces;
using JourneyCreator.Core.Models;
using System.Collections.Generic;

namespace JourneyCreator.Api.Services
{
    public class RetrievalService : IRetrievalService
    {
        IJourneyRepository _journeyRepository;

        public RetrievalService(IJourneyRepository journeyRepository)
        {
            _journeyRepository = journeyRepository;
        }

        public async Task<IEnumerable<Journey>> GetLatestJourneyForAllProductsAsync()
        {
            var journeys = await _journeyRepository.GetAsync();

            return journeys;
        }

        public async Task<Journey> GetJourneyByProductAsync(string product)
        {
            var journey = await _journeyRepository.GetJourneyByProductAsync(product);

            return journey;
        }

        public async Task<Journey> GetJourneyByProductAndIdAsync(string product, string id)
        {
            var journey = await _journeyRepository.GetJourneyByProductAndIdAsync(product, id);

            return journey;
        }
    }
}
