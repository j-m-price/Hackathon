using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace JourneyCreator.Core.Models
{
    public class Journey
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string Publisher { get; set; }
        public string Product { get; set; }
        public IEnumerable<Page> Pages { get; set; }
        public GTMSettings GTMSettings { get; set; }
    }
}
