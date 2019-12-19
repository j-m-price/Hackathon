using System.Threading.Tasks;
using JourneyCreator.Core.Models;
using System.Collections.Generic;

namespace JourneyCreator.Core.Interfaces
{
    public interface IRetrievalService
    {
        Task<IEnumerable<Journey>> GetLatestJourneyForAllProductsAsync();

        Task<Journey> GetJourneyByProductAsync(string product);

        Task<Journey> GetJourneyByProductAndIdAsync(string product, string id);
    }
}
