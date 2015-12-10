using System.IO;
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

            //var logger = new LoggerConfiguration()
            //    .WriteTo.File(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "log.txt"))
            //    .MinimumLevel.Debug()
            //    .CreateLogger();
            //Log.Logger = logger;
        }
    }
}