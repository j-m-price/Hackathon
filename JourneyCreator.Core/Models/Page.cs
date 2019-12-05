using System.Collections.Generic;

namespace JourneyCreator.Core.Models
{
    public class Page
    {
        public string Title { get; set; }
        public IEnumerable<Question> Questions { get; set; }
    }
}
