using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelpACoder.Startup))]
namespace HelpACoder
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
