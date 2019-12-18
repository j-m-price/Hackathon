using JourneyCreator.Core.Interfaces;
using JourneyCreator.Core.Models;

namespace JourneyCreator.Core.Services
{
    public class ValidationService : IValidationService
    {
        // Use FluentValidation? It looks pretty cool.

        public bool Validate(Journey journey)
        {
            // we'll want to return a custom error type here.
            // Bool is just a placeholder obviously.
            // if (!ValidateJourneyId(journey.Id)) return false;
            // if (!ValidateProductId(journey.ProductId)) return false;
            // if (!ValidatePublisher(journey.Publisher)) return false;
            // if (!ValidateGTMSettings(journey.GTMSettings)) return false;

            return true;
        }

        private bool ValidateJourneyId(int id)
        {
            /*
                To check:
                    - Id must not be null
                    - Id must not be 0
                    - Id must not be less than 0
                    - Id must not already exist? (Does this belong elsewhere?)
            */

            return id > 0;
        }

        private bool ValidateProductId(int id)
        {
            /*
                To check:
                    - Id must not be null
                    - Id must not be 0
                    - Id must not be less than 0
                    - Id must match to an active product? (Or do we allow someone to generate a new journey TYPE here?)
            */

            return id > 0;
        }

        private bool ValidatePublisher(string publisher)
        {
            /*
                To check:
                    - string must not be null
                    - string must not be empty
                    - string must not be whitespace only
                    - string must be at least 3 characters? (Fill in more here to build test cases)
            */

            return !string.IsNullOrWhiteSpace(publisher);
        }

        private bool ValidateGTMSettings(GTMSettings settings)
        {
            /*
                To check:
                    - settings must not be null
                    - Excluded must not be null
                    - Frequency must not ne null
                    - Frequency must not be whitespace only
                    - (Fill in more test cases)
            */

            if (settings == null) return false;
            if (settings.Excluded == null) return false;
            if (string.IsNullOrWhiteSpace(settings.Frequency)) return false;

            return true;
        }
    }
}
