using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SurvApe.Startup))]
namespace SurvApe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
