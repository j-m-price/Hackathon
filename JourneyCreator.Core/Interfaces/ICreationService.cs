using System.Threading.Tasks;

namespace JourneyCreator.Core.Interfaces
{
    public interface ICreationService
    {
        // Calls core validation
        // Then calls repo to save
        Task<bool> SaveNewJourneyAsync();
    }
}
