using System.Collections.Generic;
using JourneyCreator.Core.Enums;

namespace JourneyCreator.Core.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public QuestionType Type { get; set; }
        public string Label { get; set; }
        public string LabelField { get; set; }
        public string LabelReplace { get; set; }
        public string HelpText { get; set; }
        public bool Required { get; set; }
        public IEnumerable<Option> Options { get; set; }
        public DisplayCondition DisplayCondition { get; set; }
    }
}
