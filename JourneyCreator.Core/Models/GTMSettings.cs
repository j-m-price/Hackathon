using System.Collections.Generic;

namespace JourneyCreator.Core.Models
{
    public class GTMSettings
    {
        // will we push messages onBlur, onChange, on page transition?
        public string Frequency { get; set; }

        // questions that we don't want to send to GTM
        public IEnumerable<string> Excluded { get; set; }

        // Instead of Excluded, we might want to have a list of questions, with the gtm push object.
    }
}
