using System;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using VolleyballLeagueManagement.Common.Infrastructure;
using VolleyballLeagueManagement.Common.Interfaces.Messaging;
using VolleyballLeagueManagement.UsersAccounts.Model;
using VolleyballLeagueManagement.UsersAccounts.Model.Migrations;

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

            var userAccountDataContext = new UserAccountDataContext();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UserAccountDataContext, Configuration>());
            userAccountDataContext.Database.Initialize(false);

            BootstrapContexts();
        }

        private void BootstrapContexts()
        {
            var userAccountBootstrap = new BootstrapUserAccountContext(MvcApplication.MessageBus);
            userAccountBootstrap.RegisterCommandHandlers();
            userAccountBootstrap.RegisterEventHandlers();
        }
    }
}
