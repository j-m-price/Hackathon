using System.Threading.Tasks;
using JourneyCreator.Core.Models;

namespace JourneyCreator.Core.Interfaces
{
    public interface IJourneyRepository
    {
        Task<Journey> GetAsync();
        Task<Journey> GetByIdAsync(int journeyId);
        Task<bool> SaveAsync(Journey journey);
        Task<bool> DeleteAsync(int journeyId);
    }
}
