using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnswerMe2017.Models
{
    public class Answers
    {
        public IEnumerable<Answer> AnswerList { get; set; }
        public int UseTime { get; set; }
    }
}