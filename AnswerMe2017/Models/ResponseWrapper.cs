using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnswerMe2017.Models
{
    public class ResponseWrapper
    {
        public bool IsSuccessful { get; set; }

        public string ErrorMessage { get; set; }

        public object Body { get; set; }
    }
}