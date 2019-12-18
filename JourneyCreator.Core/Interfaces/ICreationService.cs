using System.Threading.Tasks;
using JourneyCreator.Core.Models;

namespace JourneyCreator.Core.Interfaces
{
    public interface ICreationService
    {
        // Calls core validation
        // Then calls repo to save
        Task<bool> SaveNewJourneyAsync(Journey journey);
    }
}
