using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoginLogoutWithSession.Startup))]
namespace LoginLogoutWithSession
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
