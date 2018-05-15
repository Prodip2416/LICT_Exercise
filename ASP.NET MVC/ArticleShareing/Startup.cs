using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BDJArticle15.Startup))]
namespace BDJArticle15
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
