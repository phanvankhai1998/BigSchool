using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BigSc.Startup))]
namespace BigSc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
