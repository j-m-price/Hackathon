using JourneyCreator.Core.Models;

namespace JourneyCreator.Core.Interfaces
{
    public interface IValidationService
    {
        bool Validate(Journey journey);
    }
}
