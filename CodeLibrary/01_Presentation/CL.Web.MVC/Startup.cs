using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CL.Web.MVC.Startup))]
namespace CL.Web.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
