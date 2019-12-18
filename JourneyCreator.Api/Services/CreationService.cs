using System;
using System.Threading.Tasks;
using JourneyCreator.Core.Interfaces;
using JourneyCreator.Core.Models;

namespace JourneyCreator.Api.Services
{
    public class CreationService : ICreationService
    {
        public Task<bool> SaveNewJourneyAsync(Journey journey)
        {
            throw new NotImplementedException();
        }
    }
}
