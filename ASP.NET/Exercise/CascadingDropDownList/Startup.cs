using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CascadingDropDownList.Startup))]
namespace CascadingDropDownList
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
