using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NoBarriersWebApp.Startup))]
namespace NoBarriersWebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
