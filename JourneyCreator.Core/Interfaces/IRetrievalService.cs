using System.Threading.Tasks;
using JourneyCreator.Core.Models;
using System.Collections.Generic;

namespace JourneyCreator.Core.Interfaces
{
    public interface IRetrievalService
    {
        IEnumerable<Journey> GetLatestJourneyForAllProducts();

        Journey GetJourneyByProductAsync(string product);

        Journey GetJourneyByProductAndIdAsync(string product, int id);
    }
}
