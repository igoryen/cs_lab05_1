using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(INT422TestOne.Startup))]
namespace INT422TestOne
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
