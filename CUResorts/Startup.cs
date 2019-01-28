using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CUResorts.Startup))]
namespace CUResorts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
