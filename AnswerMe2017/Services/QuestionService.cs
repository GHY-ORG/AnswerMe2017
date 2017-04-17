using AnswerMe2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnswerMe2017.Services
{
    public class QuestionService
    {
        private static QuestionService _instance = new QuestionService();
        public static QuestionService Instance { get { return _instance; } }

        public List<ChoiceQuestion> GenerateRandomChoiceQuestions(int count)
        {
            var result = new List<ChoiceQuestion>();

            using (var db = new dbEntities())
            {
                var questionQuery = (from o in db.QuesBank orderby Guid.NewGuid() select o).Take(count).ToList();
                result = questionQuery.Select(o => new ChoiceQuestion
                {
                    Class = o.Class,
                    Title = o.Ques,
                    Answer = o.Answer,
                    Id = o.ID,
                    Options = new Dictionary<string, string>
                    {
                        {"A",o.OptionA },
                        {"B",o.OptionB },
                        {"C",o.OptionC },
                        {"D",o.OptionD },
                    },
                }).ToList();
            }
            return result;
        }

        public List<Answer> ValidAnswers(IEnumerable<Answer> answers)
        {
            using (var db = new dbEntities())
            {
                int[] quesId = (from o in answers
                                select o.QuestionId).ToArray();
                var questions = (from o in db.QuesBank
                                 where quesId.Contains(o.ID)
                                 select o).ToList();
                var result = answers.ToList();
                result.ForEach(a =>
                {
                    a.IsCorrect = questions.Any(q => q.ID.Equals(a.QuestionId) && q.Answer.Equals(a.AnswerBody));
                });

                return result;
            }
        }

        public int GetRank(decimal grade)
        {
            using (var db = new dbEntities())
            {
                var userRank = db.User.Where(model => model.Grade > grade).Count() + 1;
                return userRank;
            }
        }
    }
}