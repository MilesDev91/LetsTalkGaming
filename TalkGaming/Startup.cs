using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TalkGaming.Startup))]
namespace TalkGaming
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
