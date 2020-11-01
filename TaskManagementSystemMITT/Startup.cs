using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskManagementSystemMITT.Startup))]
namespace TaskManagementSystemMITT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
