using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MedDiagnositc.Startup))]
namespace MedDiagnositc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
