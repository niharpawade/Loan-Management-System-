using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LMSWeb.Startup))]
namespace LMSWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
