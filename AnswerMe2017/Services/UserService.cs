using AnswerMe2017.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Web;

namespace AnswerMe2017.Services
{
    public class UserService
    {
        private static UserService _instance = new UserService();
        public static UserService Instance { get { return _instance; } }

        public bool TryLogin(string userId, string pwd, out IPrincipal principal)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userId),
                new Claim(ClaimTypes.AuthenticationMethod, AuthenticationMethods.Password)
            };
            principal = new ClaimsPrincipal(new[] { new ClaimsIdentity(claims, "Basic") });
            return true;
        }


        public List<UserInfo> GetTop10User()
        {
            using (var db = new dbEntities())
            {
                return db.User.OrderByDescending(u => u.Grade).Take(10).Select(u => new UserInfo
                {
                    Name = u.Name,
                    StudentNumber = u.StuNum,
                    Phone = u.Phone,
                    Grade = u.Grade,
                    Time = u.Time
                }).ToList();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns>token</returns>
        public string RegisterOrUpdate(UserInfo userInfo)
        {
            using (var db = new dbEntities())
            {
                var user = db.User.Where(u => u.StuNum == userInfo.StudentNumber).FirstOrDefault();
                if (user != null)
                {
                    try
                    {
                        user.Name = userInfo.Name;
                        user.StuNum = userInfo.StudentNumber;
                        user.Phone = userInfo.Phone;
                        user.Grade = userInfo.Grade;
                        user.Time = userInfo.Time;
                        db.SaveChanges();
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        db.User.Add(new User
                        {
                            Name = userInfo.Name,
                            StuNum = userInfo.StudentNumber,
                            Phone = userInfo.Phone,
                            Grade = userInfo.Grade
                        });
                        db.SaveChanges();
                    }
                    catch { }
                }
            }
            return GenerateToken(userInfo);
        }

        public UserInfo GetUserInfo(string StudentNumber)
        {
            using (var db = new dbEntities())
            {
                var user = db.User.Where(u => u.StuNum.Equals(StudentNumber)).FirstOrDefault();
                if (user == null) return null;
                else
                {
                    return new UserInfo
                    {
                        StudentNumber = user.StuNum,
                        Name = user.Name,
                        Phone = user.Phone,
                        Grade = user.Grade,
                        Time = user.Time
                    };
                }

            }
        }

        public string GenerateToken(UserInfo userInfo)
        {
            var stamp = DateTime.UtcNow;
            string userinfoCombine = userInfo.Name + userInfo.Phone + userInfo.StudentNumber + stamp.ToString();
            string base64token = Convert.ToBase64String(Encoding.UTF8.GetBytes(userInfo.StudentNumber + "|" + stamp.ToString() + "|" + GetMd5Hash(userinfoCombine)));
            return HttpUtility.UrlEncode(base64token);
        }

        public UserInfo ValidToken(string token)
        {
            token = HttpUtility.UrlDecode(token);
            var str = Encoding.UTF8.GetString(Convert.FromBase64String(token));
            var slice = str.Split('|');
            var userInfo = GetUserInfo(slice[0]);
            if (userInfo != null)
            {
                string userinfoCombine = userInfo.Name + userInfo.Phone + userInfo.StudentNumber + slice[1].ToString();

                if (slice[2].Equals(GetMd5Hash(userinfoCombine)))
                {
                    return userInfo;
                }
            }

            return null;

        }

        static string GetMd5Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }

        }

        static bool VerifyMd5Hash(string input, string hash)
        {
            string hashOfInput = GetMd5Hash(input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}