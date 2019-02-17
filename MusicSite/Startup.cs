using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MusicSite.Startup))]
namespace MusicSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
