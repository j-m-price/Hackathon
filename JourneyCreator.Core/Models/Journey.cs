using System.Collections.Generic;

namespace JourneyCreator.Core.Models
{
    public class Journey
    {
        // Todo: Add isTest
        public int Id { get; set; }
        public string Publisher { get; set; }
        public int ProductId { get; set; }
        public IEnumerable<Page> Pages { get; set; }
        public GTMSettings GTMSettings { get; set; }
    }
}
