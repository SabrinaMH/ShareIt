using System.Web.Http;
using ShareIt.Infrastructure;

namespace ShareIt.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected readonly Bus _bus;

        public BaseController()
        {
            _bus = Bus.Instance;
        }
    }
}