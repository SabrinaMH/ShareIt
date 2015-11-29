using System.Web.Http;

namespace ShareIt
{
    public class WebApiConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration.MapHttpAttributeRoutes();
            GlobalConfiguration.Configuration.EnsureInitialized();
        }
    }
}