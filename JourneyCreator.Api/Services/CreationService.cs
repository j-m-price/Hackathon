using System;
using System.Threading.Tasks;
using JourneyCreator.Core.Interfaces;
using JourneyCreator.Core.Models;

namespace JourneyCreator.Api.Services
{
    public class CreationService : ICreationService
    {
        IJourneyRepository _journeyRepository;

        public CreationService(IJourneyRepository journeyRepository)
        {
            _journeyRepository = journeyRepository;
        }
        public async Task<bool> SaveNewJourneyAsync(Journey journey)
        {
            await _journeyRepository.SaveNewJourney(journey);
            return true;
        }
    }
}
