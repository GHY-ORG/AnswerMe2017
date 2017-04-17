using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnswerMe2017.Models
{
    public class AnswerResult
    {
        public decimal Grade { get; set; }
        public int UseTime { get; set; }
        public decimal BestGrade { get; set; }
        public int BestTime { get; set; }
        public int BestRank { get; set; }
    }
}