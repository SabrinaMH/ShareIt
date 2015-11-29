using System.Web.Http;
using Owin;
using ShareIt.Infrastructure;

namespace ShareIt
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register();
            app.UseWebApi(httpConfiguration);
            Bus.Bootstrap();
            Actors.Bootstrap();
        }
    }
}