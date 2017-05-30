using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QLXayDungWebMVC.Startup))]
namespace QLXayDungWebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
