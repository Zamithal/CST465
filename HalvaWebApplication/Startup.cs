using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HalvaWebApplication.Startup))]
namespace HalvaWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}