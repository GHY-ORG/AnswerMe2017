using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnswerMe2017.Models
{
    public class Question
    {
        public virtual int Id { get; set; }
        
        public virtual string Type { get; set; }

        public virtual string Class { get; set; }

        public virtual string Title { get; set; }
    }
}