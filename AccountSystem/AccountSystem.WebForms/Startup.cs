using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AccountSystem.WebForms.Startup))]
namespace AccountSystem.WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
