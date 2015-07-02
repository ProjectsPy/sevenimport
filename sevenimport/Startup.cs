using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(sevenimport.Startup))]
namespace sevenimport
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
