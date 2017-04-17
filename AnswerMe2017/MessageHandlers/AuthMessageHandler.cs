using AnswerMe2017.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace AnswerMe2017.MessageHandlers
{
    public class AuthMessageHandler : DelegatingHandler
    {
        private readonly string SCHEME = "Basic";
        private readonly string TOKEN = "Token";


        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            if (request.Headers.Authorization != null
                && SCHEME.Equals(request.Headers.Authorization.Scheme))
            {
                // 用户名密码登陆

                Encoding encoding = Encoding.GetEncoding("utf-8");
                string credentials = encoding.GetString(Convert.FromBase64String(request.Headers.Authorization.Parameter));
                string[] parts = credentials.Split(':');
                string userId = parts[0].Trim();
                string password = parts[1].Trim();

                IPrincipal principal;
                if (UserService.Instance.TryLogin(userId, password, out principal))
                {
                    var response = request.CreateResponse(HttpStatusCode.OK);

                    Thread.CurrentPrincipal = principal;
                    if (HttpContext.Current != null) HttpContext.Current.User = principal;
                    var cookie = new CookieHeaderValue(TOKEN, "");
                    cookie.HttpOnly = true;

                    response.Headers.AddCookies(new List<CookieHeaderValue> { cookie });
                    return await base.SendAsync(request, cancellationToken);
                }
                else
                {
                    return request.CreateResponse(HttpStatusCode.Unauthorized, "Token错误");
                }

            }
            else if (request.Headers.GetCookies(TOKEN) != null && HttpContext.Current != null)
            {
                // Cookie缓存登陆信息且当前用户
                return await base.SendAsync(request, cancellationToken);
            }

            // request 传递给 filter, controller
            return await base.SendAsync(request, cancellationToken);
        }

    }
}