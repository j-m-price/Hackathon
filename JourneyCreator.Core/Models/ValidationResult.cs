using System.Collections.Generic;

namespace JourneyCreator.Core.Models
{
    public class ValidationResult
    {
        public bool isValid { get; set; }
        public IEnumerable<ValidationError> Errors { get; set; }
    }
}
