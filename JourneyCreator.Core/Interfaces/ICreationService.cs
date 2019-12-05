using System.Threading.Tasks;

namespace JourneyCreator.Core.Interfaces
{
    public interface ICreationService
    {
        Task<bool> CreateAsync();
        Task<bool> DeleteAsync();
        Task<bool> ActivateAsync();
        Task<bool> DeactivateAsync();
    }
}
