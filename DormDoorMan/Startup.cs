using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DormDoorMan.Startup))]
namespace DormDoorMan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
