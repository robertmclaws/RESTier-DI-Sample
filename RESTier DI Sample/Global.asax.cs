using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace RESTier_DI_Sample
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //GlobalConfiguration.Configure(DependencyConfig.Register);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
