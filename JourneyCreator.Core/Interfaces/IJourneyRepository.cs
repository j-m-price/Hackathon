using System.Threading.Tasks;
using JourneyCreator.Core.Models;
using System.Collections.Generic;

namespace JourneyCreator.Core.Interfaces
{
    public interface IJourneyRepository
    {
        // get latest for all journeys
        Task<IEnumerable<Journey>> GetAsync();
        // get latest journey for product
        Task<Journey> GetJourneyByProductAsync(string product);
        // get specific joureny for product
        Task<Journey> GetJourneyByProductAndIdAsync(string product, string id);

        // If collection exists, save
        // If not, create that collection and then save
        Task<Journey> SaveNewJourney(Journey journey);
    }
}
