using System.Threading.Tasks;
using JourneyCreator.Core.Models;
using System.Collections.Generic;

namespace JourneyCreator.Core.Interfaces
{
    public interface IRetrievalService
    {
        Task<IEnumerable<Journey>> GetLatestJourneyForAllProductsAsync();

        Task<IEnumerable<Journey>> GetJourneyByProductAsync(string product);

        Task<IEnumerable<Journey>> GetJourneyByProductAndIdAsync(string product, string id);
    }
}
