using System;
using System.Threading.Tasks;
using JourneyCreator.Core.Interfaces;

namespace JourneyCreator.Core.Services
{
    public class CreationService : ICreationService
    {
        public Task<bool> ActivateAsync()
        {
            // take journeyId
            // attempt to update record to make active true
            // if error, return false -- return error?
            // if no error, return true -- return journey? or just id and active values?

            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync()
        {
            // take journey
            // attempt to save to db
            // if error, return false -- return error message?
            // if no error, return true -- maybe return journey? or new id?
            throw new NotImplementedException();
        }

        public Task<bool> DeactivateAsync()
        {
            // take journeyId
            // attempt to update record to make active false
            // if error, return false -- return error?
            // if no error, return true -- return journey? or just id and active values?
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync()
        {
            // take journeyId
            // attempt to remove record from db
            // if error, return false -- return error?
            // if no error, return true -- return deleted success message?
            throw new NotImplementedException();
        }

        public Task<bool> SaveNewJourneyAsync()
        {
            throw new NotImplementedException();
        }
    }
}
