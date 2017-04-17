using AnswerMe2017.Models;
using AnswerMe2017.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace AnswerMe2017.Controllers
{
    [RoutePrefix("api/question")]
    public class QuestionController : ApiController
    {
        [Route("choicequestion")]
        [HttpGet]
        public ResponseWrapper GetRandomChoiceQuestionsCollection([FromUri]int count)
        {

            var cookie = Request.Headers.GetCookies("Token").FirstOrDefault();
            if (cookie == null)
                return new ResponseWrapper
                {
                    IsSuccessful = false,
                    ErrorMessage = "未登录",
                };

            var userInfo = UserService.Instance.ValidToken(cookie["Token"].Value);
            if (userInfo == null)
                return new ResponseWrapper
                {
                    IsSuccessful = false,
                    ErrorMessage = "未登录",
                };


            var result = QuestionService.Instance.GenerateRandomChoiceQuestions(count);
            return new ResponseWrapper
            {
                IsSuccessful = true,
                Body = result
            };
        }

        [Route("answer")]
        [HttpPost]
        public ResponseWrapper SubmitAnswer(Answers answers)
        {
            var cookie = Request.Headers.GetCookies("Token").FirstOrDefault();
            if (cookie == null)
                return new ResponseWrapper
                {
                    IsSuccessful = false,
                    ErrorMessage = "未登录",
                };

            var userInfo = UserService.Instance.ValidToken(cookie["Token"].Value);
            if (userInfo == null)
                return new ResponseWrapper
                {
                    IsSuccessful = false,
                    ErrorMessage = "未登录",
                };

            var result = QuestionService.Instance.ValidAnswers(answers.AnswerList);
            decimal grade = (decimal)answers.AnswerList.Count(a => a.IsCorrect) / answers.AnswerList.Count();
            if (grade > userInfo.Grade)
            {
                userInfo.Grade = grade;
                userInfo.Time = answers.UseTime;
            }

            UserService.Instance.RegisterOrUpdate(userInfo);
            // 更新用户成绩

            return new ResponseWrapper
            {
                IsSuccessful = true,
                Body = new AnswerResult
                {
                    Grade = grade,
                    UseTime = answers.UseTime,
                    BestGrade = userInfo.Grade,
                    BestTime = userInfo.Time,
                    BestRank = QuestionService.Instance.GetRank(userInfo.Grade)
                }
            };
        }
    }
}