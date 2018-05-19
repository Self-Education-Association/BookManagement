using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookMng.Startup))]
namespace BookMng
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
