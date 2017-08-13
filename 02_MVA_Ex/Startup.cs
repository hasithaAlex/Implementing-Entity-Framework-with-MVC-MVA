using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_02_MVA_Ex.Startup))]
namespace _02_MVA_Ex
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
