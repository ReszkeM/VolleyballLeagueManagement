using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VolleyballLeagueManagement.UI.Web.Startup))]
namespace VolleyballLeagueManagement.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
