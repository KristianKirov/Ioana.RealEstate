using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ioana.RealEstate.Startup))]
namespace Ioana.RealEstate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
