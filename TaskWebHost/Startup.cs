using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskWebHost.Startup))]
namespace TaskWebHost
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
