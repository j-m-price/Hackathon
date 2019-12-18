using System.Collections.Generic;

namespace JourneyCreator.Core.Models
{
    public class Journey
    {
        public int Id { get; set; }
        public string Publisher { get; set; }
        public string Product { get; set; }
        public IEnumerable<Page> Pages { get; set; }
        public GTMSettings GTMSettings { get; set; }
    }
}
