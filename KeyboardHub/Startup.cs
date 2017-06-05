using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KeyboardHub.Startup))]
namespace KeyboardHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
