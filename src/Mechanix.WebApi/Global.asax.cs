using System.Web.Http;

namespace Mechanix.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            GlobalConfiguration.Configure(AutofacConfig.Register);
        }
    }
}
