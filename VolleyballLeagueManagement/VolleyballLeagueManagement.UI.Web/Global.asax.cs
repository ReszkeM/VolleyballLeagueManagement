using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using VolleyballLeagueManagement.Common.Infrastructure;
using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.UI.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IBus MessageBus { get { return busFabric.Value; } }
        static readonly Lazy<IBus> busFabric = new Lazy<IBus>(() => new MessageBus());

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // initialize contexts

            BootstrapContexts();
        }

        private void BootstrapContexts()
        {
            // register handlers
        }
    }
}
