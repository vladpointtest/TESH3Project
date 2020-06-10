using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TESH3Project.Startup))]
namespace TESH3Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
