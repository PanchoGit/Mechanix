using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Mechanix.Web.Startup))]

namespace Mechanix.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            WebApiConfig.Register(config);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            var container = AutofacConfig.Register(config);

            app.UseAutofacMiddleware(container);

            app.UseWebApi(config);
        }
    }
}
