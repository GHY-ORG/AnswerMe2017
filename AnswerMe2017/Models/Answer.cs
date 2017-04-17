using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnswerMe2017.Models
{
    public class Answer
    {
        public int QuestionId { get; set; }

        public string AnswerBody { get; set; }

        public bool IsCorrect { get; set; }
    }
}