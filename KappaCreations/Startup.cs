using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KappaCreations.Startup))]
namespace KappaCreations
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}