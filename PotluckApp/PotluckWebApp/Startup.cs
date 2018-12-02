using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PotluckWebApp.Startup))]
namespace PotluckWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
