using System;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using VolleyballLeagueManagement.Common.Authentication;
using VolleyballLeagueManagement.Common.Infrastructure;
using VolleyballLeagueManagement.Common.Interfaces.Messaging;
using VolleyballLeagueManagement.Management.Model;
using VolleyballLeagueManagement.UsersAccounts.Model;

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
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UserAccountDataContext, VolleyballLeagueManagement.UsersAccounts.Model.Migrations.Configuration>());
            userAccountDataContext.Database.Initialize(false);

            var managementDataContext = new ManagementDataContext();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ManagementDataContext, VolleyballLeagueManagement.Management.Model.Migrations.Configuration>());
            managementDataContext.Database.Initialize(false);

            BootstrapContexts();
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            CookieHandler.ReplaceCookieUser(authCookie);
        }

        private void BootstrapContexts()
        {
            var userAccountBootstrap = new BootstrapUserAccountContext(MvcApplication.MessageBus);
            userAccountBootstrap.RegisterCommandHandlers();
            userAccountBootstrap.RegisterEventHandlers();

            var managementBootstrap = new BootstrapManagementContext(MvcApplication.MessageBus);
            managementBootstrap.RegisterCommandHandlers();
            managementBootstrap.RegisterEventHandlers();
        }
    }
}
