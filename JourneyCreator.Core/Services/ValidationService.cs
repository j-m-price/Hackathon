using JourneyCreator.Core.Interfaces;
using JourneyCreator.Core.Models;
using JourneyCreator.Core.Enums;
using System.Collections.Generic;
using System.Linq;

namespace JourneyCreator.Core.Services
{
    public class ValidationService : IValidationService
    {

        List<string> errors;
        public ValidationService()
        {
            errors = new List<string>();
        }

        public List<string> Validate(Journey journey)
        {
            ValidateJourneyId(journey.Id);
            ValidateProduct(journey.Product);
            ValidatePublisher(journey.Publisher);
            ValidateQuestions(journey.Pages);

            // ValidateGTMSettings(journey.GTMSettings);

            return errors;
        }

        private void ValidateQuestions(IEnumerable<Page> pages)
        {
            foreach (var page in pages)
            {
                foreach (var question in page.Questions)
                {
                    var isSelect = question.Type == QuestionType.GcSelect;

                    if (isSelect && question.Options == null)
                    {
                        errors.Add($"{question.Name} must contains a list of options");
                    }
                    if (isSelect && question.Options != null)
                    {
                        var optionCount = question.Options.ToList().Count;
                        if (isSelect && optionCount == 0) errors.Add($"{question.Name} must have at least one option");
                    }

                    // add more rules here
                    if (question.Label.Length < 5) errors.Add($"{question.Name}'s label must be at least 5 characters");


                    // we could add a max and min length attribute
                    // and then check that if there is a min value, the max must be higher than the min, etc.
                }
            }
        }

        private void ValidateJourneyId(string id)
        {
            /*
                Journey Id will be generated by DB
                No need to validate, it'll be ignored
            */
        }

        private void ValidateProduct(string product)
        {
            var name = "Product";

            if (string.IsNullOrWhiteSpace(product)) errors.Add($"{name} must not be empty");
            if (product.Length <= 2) errors.Add($"{name} must be greater than 2 characters");
            if (product.Length >= 30) errors.Add($"{name} must be less than 30 characters");
        }

        private void ValidatePublisher(string publisher)
        {
            var name = "Publisher";

            if (string.IsNullOrWhiteSpace(publisher)) errors.Add($"{name} must not be empty");
            if (publisher.Length <= 2) errors.Add($"{name} must be greater than 2 characters");
            if (publisher.Length >= 30) errors.Add($"{name} must be less than 30 characters");
        }

        private void ValidateGTMSettings(GTMSettings settings)
        {
            /*
                To check:
                    - settings must not be null
                    - Excluded must not be null
                    - Frequency must not be null
                    - Frequency must not be whitespace only
                    - (Fill in more test cases)
            */

            var name = "GTMSettings";

            if (settings == null) errors.Add($"{name} must not be null");
            // if (settings.Excluded == null) errors.Add(new ValidationError(name, "excluded must not be null"));
            // if (string.IsNullOrWhiteSpace(settings.Frequency)) errors.Add(new ValidationError(name, "frequency must not be null or empty"));
        }
    }
}
