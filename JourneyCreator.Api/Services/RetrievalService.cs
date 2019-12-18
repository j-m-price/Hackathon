using System;
using System.Threading.Tasks;
using JourneyCreator.Core.Interfaces;
using JourneyCreator.Core.Models;
using System.Collections.Generic;

namespace JourneyCreator.Api.Services
{
    public class RetrievalService : IRetrievalService
    {
        public IEnumerable<Journey> GetLatestJourneyForAllProducts()
        {
            return new List<Journey>();
        }

        public Journey GetJourneyByProductAsync(string product)
        {
            return new Journey
            {
                Publisher = product
            };
        }

        public Journey GetJourneyByProductAndIdAsync(string product, int id)
        {
            return new Journey
            {
                Publisher = product,
                Id = id
            };
        }
    }
}
