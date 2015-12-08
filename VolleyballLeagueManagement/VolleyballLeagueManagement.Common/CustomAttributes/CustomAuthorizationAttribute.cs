using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VolleyballLeagueManagement.Common.Enums;
using VolleyballLeagueManagement.Common.Extensions;

namespace VolleyballLeagueManagement.Common.CustomAttributes
{
    public class CustomAuthorizationAttribute : AuthorizeAttribute
    {
        public Role Role { get; set; }

        public CustomAuthorizationAttribute(Role role)
        {
            Role = role;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authCookie = httpContext.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie == null)
                return false;

            var user = HttpContext.Current.GetCurrentUser();

            if (user == null)
                return false;

            return user.IsInRole(Role);
        }
    }
}
