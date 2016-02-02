using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoginBlog.Startup))]
namespace LoginBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            ConfigureAuth(app);
        }
    }
}
