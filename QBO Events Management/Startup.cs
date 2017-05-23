using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QBO_Events_Management.Startup))]
namespace QBO_Events_Management
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
