using AnswerMe2017.Models;
using AnswerMe2017.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace AnswerMe2017.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {

        // POST api/<controller>
        [Route("login")]
        [HttpPost]
        public ResponseWrapper PostUserInfo(UserInfo userInfo)
        {
            if (ModelState.IsValid == false)
            {
                string errorMessages = string.Empty;

                foreach (var value in ModelState.Values)
                    foreach (var error in value.Errors)
                    {
                        errorMessages += error.ErrorMessage;
                        errorMessages += Environment.NewLine;
                    }
                return new ResponseWrapper
                {
                    IsSuccessful = false,
                    ErrorMessage = errorMessages,
                };
            }
            var token = UserService.Instance.RegisterOrUpdate(userInfo);
            var cookie = new HttpCookie("Token", token);
            cookie.Expires = DateTime.UtcNow + TimeSpan.FromDays(7);
            cookie.HttpOnly = true;

            HttpContext.Current.Response.SetCookie(cookie);
            return new ResponseWrapper
            {
                IsSuccessful = true,
            };
        }

        [Route("valid")]
        [HttpGet]
        public ResponseWrapper ValidUserCookie()
        {
            var cookie = Request.Headers.GetCookies("Token").FirstOrDefault();
            if (cookie != null)
            {
                var userInfo = UserService.Instance.ValidToken(cookie["Token"].Value);
                if (userInfo != null)
                    return new ResponseWrapper
                    {
                        IsSuccessful = true,
                        Body = new UserInfo
                        {
                            Name = userInfo.Name,
                            Phone = userInfo.Phone,
                            StudentNumber = userInfo.StudentNumber
                        }
                    };
            }
            return new ResponseWrapper { IsSuccessful = false };
        }


        [Route("top10")]
        [HttpGet]
        public ResponseWrapper GetTop10User()
        {
            return new ResponseWrapper
            {
                IsSuccessful = true,
                Body = UserService.Instance.GetTop10User()
            };
        }

        //[Route("/exit")]
        //[HttpGet]
        //public ResponseWrapper Exit()
        //{

        //}
    }
}