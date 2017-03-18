using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DealerVehicle.Startup))]
namespace DealerVehicle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
