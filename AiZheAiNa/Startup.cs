using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AiZheAiNa.Startup))]
namespace AiZheAiNa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
