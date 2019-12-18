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

        public Journey GetJourneyByProductAsync(string product)
        {
            return new Journey
            {
                Publisher = product
            };
        }

        public Journey GetJourneyByProductAndIdAsync(string product, string id)
        {
            return new Journey
            {
                Publisher = product,
                Id = id
            };
        }
    }
}
