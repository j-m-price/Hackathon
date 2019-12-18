using System.Collections.Generic;
using JourneyCreator.Core.Models;

namespace JourneyCreator.Core.Interfaces
{
    public interface IValidationService
    {
        List<string> Validate(Journey journey);
    }
}
