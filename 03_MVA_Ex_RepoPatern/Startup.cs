using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_03_MVA_Ex_RepoPatern.Startup))]
namespace _03_MVA_Ex_RepoPatern
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
