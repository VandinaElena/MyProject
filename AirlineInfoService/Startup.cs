using Microsoft.Owin;

[assembly: OwinStartup(typeof(AirlineInfoService.App_Start.StartupIdentity))]

namespace CarShop.WebApp
{
    using Owin;

    /// <summary>
    /// The startup.
    /// </summary>
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Configuration(app);
        }
    }
}