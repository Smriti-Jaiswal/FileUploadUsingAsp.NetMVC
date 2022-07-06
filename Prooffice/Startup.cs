using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Prooffice.Startup))]
namespace Prooffice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
