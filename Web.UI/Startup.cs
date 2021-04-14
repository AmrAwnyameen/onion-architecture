using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web.UI.Startup))]
namespace Web.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
