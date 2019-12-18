using System.Threading.Tasks;
using JourneyCreator.Core.Models;
using System.Collections.Generic;

namespace JourneyCreator.Core.Interfaces
{
    public interface IRetrievalService
    {
        Task<IEnumerable<Journey>> GetLatestJourneyForAllProductsAsync();

        Journey GetJourneyByProductAsync(string product);

        Journey GetJourneyByProductAndIdAsync(string product, int id);
    }
}
