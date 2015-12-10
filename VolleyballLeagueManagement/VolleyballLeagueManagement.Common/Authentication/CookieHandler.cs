using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace VolleyballLeagueManagement.Common.Authentication
{
    /// <summary>
    /// Class for operations on cookies
    /// </summary>
    public static class CookieHandler
    {
        /// <summary>
        /// Serialize UserData and add it to cookie
        /// </summary>
        /// <param name="user">user</param>
        /// <param name="rememberMe"></param>
        public static void Create(ApplicationUser user, bool rememberMe)
        {
            var serializeModel = new LeaguePrincipalSerializeModel
            {
                UserId = user.Id,
                Login = user.Login,
                Role = user.Role
            };

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string userData = serializer.Serialize(serializeModel);
            string cookiePath = "/";
            int durationInMinutes = 30;
            int ticketVersion = 1;

            var authTicket = new FormsAuthenticationTicket(
                ticketVersion,                               // version number
                user.Login,                                  // name of the cookie
                DateTime.Now,                                // issue date
                DateTime.Now.AddMinutes(durationInMinutes),  // expiration
                rememberMe,                                  // survives browser sessions
                userData,                                    // custom data (serialized)
                cookiePath);                                 // set acces path for cookie

            var ticket = FormsAuthentication.Encrypt(authTicket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticket);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// Remove cookie by change expiration date
        /// </summary>
        public static void Remove()
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
                return;

            authCookie.Expires = DateTime.Now.AddDays(-1d);
            HttpContext.Current.Response.Cookies.Add(authCookie);
        }

        /// <summary>
        /// Reading cookie and replacing HttpContext.User
        /// </summary>
        /// <param name="authCookie">cookie</param>
        public static void ReplaceCookieUser(HttpCookie authCookie)
        {
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket != null)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    var serializeModel = serializer.Deserialize<LeaguePrincipalSerializeModel>(authTicket.UserData);

                    var newUser = new LeaguePrincipal(
                        serializeModel.UserId, 
                        serializeModel.Login, 
                        serializeModel.Role
                    );

                    HttpContext.Current.User = newUser;
                }
            }
        }
    }
}
