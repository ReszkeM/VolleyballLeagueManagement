using System.Web;
using VolleyballLeagueManagement.Common.Authentication;

namespace VolleyballLeagueManagement.Common.Extensions
{
    public static class HttpContextExtensions
    {
        /// <summary>
        /// HttpContext.Current extension returns LeaguePrincipal instance
        /// </summary>
        public static LeaguePrincipal GetCurrentUser(this HttpContext context)
        {
            return context.User as LeaguePrincipal;
        }
    }
}
