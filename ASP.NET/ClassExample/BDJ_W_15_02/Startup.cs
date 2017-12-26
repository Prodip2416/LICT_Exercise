using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BDJ_W_15_02.Startup))]
namespace BDJ_W_15_02
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
