using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace AnswerMe2017.Models
{
    public class UserPrincipal : IPrincipal
    {
        private IIdentity _identity;

        public IIdentity Identity { get { return _identity; } }

        public UserInfo UserInfo { get; set; }

        public UserPrincipal(UserInfo userInfo)
        {
            UserInfo = userInfo;
            _identity = new GenericIdentity(userInfo.Name);
        }

        public bool IsInRole(string role)
        {
            return true;
        }
    }
}