using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibraryManegement.Startup))]
namespace LibraryManegement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
