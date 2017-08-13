using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_03_WebApplication.Startup))]
namespace _03_WebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
