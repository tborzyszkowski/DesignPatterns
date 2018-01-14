using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarsCms.Startup))]
namespace CarsCms
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
