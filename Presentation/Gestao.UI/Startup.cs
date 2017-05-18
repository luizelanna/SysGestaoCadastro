using Gestao.UI;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
//[assembly: OwinStartupAttribute(typeof(Gestao.UI.Startup))]
namespace Gestao.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
