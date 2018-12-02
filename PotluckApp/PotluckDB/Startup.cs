using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PotluckDB.Startup))]
namespace PotluckDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
