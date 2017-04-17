using Newtonsoft.Json;
using System.Collections.Generic;

namespace AnswerMe2017.Models
{
    public class ChoiceQuestion : Question
    {
        public override string Type { get; set; } = "ChoiceQuestion";

        public Dictionary<string, string> Options;

        [JsonIgnore]
        public string Answer;
    }
}