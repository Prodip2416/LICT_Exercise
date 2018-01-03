using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GridViewExercise.Startup))]
namespace GridViewExercise
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
